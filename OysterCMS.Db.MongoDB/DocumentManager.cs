using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;
using OysterCMS.PageTypes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Reflection;

namespace OysterCMS.Templates.Db.MongoDB
{
    public class DocumentManager : IDataFactory
    {
        private MongoServer server = null;
        private MongoDatabase db = null;
        private static readonly string PAGECOLLECTION = "Pages";

        public DocumentManager()
        {
            server = MongoServer.Create();
            db = server.GetDatabase("OysterCMS");

            // Register the page type baseclass and map the id property.
            BsonClassMap.RegisterClassMap<PageTypeBase>(cm => { cm.SetIsRootClass(true); cm.AutoMap(); cm.MapIdProperty("Id"); });

            // In order for serialization to work properly all objects that inherit PageTypeBase must be mapped, otherwise
            // they cannot be deserialized complaining that the abstract baseclass cannot be instanciated
            AppDomain MyDomain = AppDomain.CurrentDomain;
            Assembly[] AssembliesLoaded = MyDomain.GetAssemblies();

            // We need reflection to call the RegisterClassMap function because we get types from the assemblys when
            // the method needs a class.
            var registerClassMapDefinition = typeof(BsonClassMap).GetMethod("RegisterClassMap", new Type[0]);

            foreach (Assembly loadedAssembly in AssembliesLoaded)
            {
                // Find all classes that derive from PageTypeBase
                foreach (var derivedClass in loadedAssembly.GetTypes().Where(type => type.IsSubclassOf(typeof(PageTypeBase))))
                {
                    var registerClassMapInfo = registerClassMapDefinition.MakeGenericMethod(derivedClass);
                    registerClassMapInfo.Invoke(null, new object[0]);
                }
            }
        }

        public void AddPage(object newPage)
        {
            db.GetCollection(PAGECOLLECTION).Insert(newPage);
        }

        public T FindPage<T>(Guid pageId) where T : PageTypeBase
        {
            var pageCollection = db.GetCollection<T>(PAGECOLLECTION);
            var query = Query.EQ(@"_id", pageId);
            return pageCollection.FindOneAs<T>(query);
        }

        public IList<T> FindChildPages<T>(Guid pageId) where T : PageTypeBase
        {
            var pageCollection = db.GetCollection<T>(PAGECOLLECTION);
            var query = Query.EQ("ParentId", pageId);
            return pageCollection.FindAs<T>(query).ToList();
        }

        public void UpdatePage<T>(T modifiedPage) where T : PageTypeBase
        {
            db.GetCollection<T>(PAGECOLLECTION).Save(modifiedPage);
        }

        public bool DeletePage(Guid pageId)
        {
            if (FindChildPages<PageTypeBase>(pageId).Count != 0)
                return false;

            db.GetCollection(PAGECOLLECTION).Remove(Query.EQ("_id", pageId));
            return true;
        }
    }
}
