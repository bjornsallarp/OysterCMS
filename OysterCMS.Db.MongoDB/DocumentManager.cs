using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;
using OysterCMS.PageTypes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

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
            BsonClassMap.RegisterClassMap<PageTypeBase>(cm => { cm.AutoMap(); cm.MapIdProperty("Id"); });
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
            db.GetCollection(PAGECOLLECTION).Save(modifiedPage);
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
