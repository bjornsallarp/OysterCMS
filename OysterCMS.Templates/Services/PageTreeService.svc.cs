using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using OysterCMS.PageTypes;

namespace OysterCMS.Templates.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PageTreeService : IPageTreeService
    {
        [WebInvoke(
            Method = "POST", 
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "children"
            )]
        public List<PageTreeItem> GetChildren(Guid parent)
        {
            List<PageTreeItem> tree = new List<PageTreeItem>();

            foreach (var page in DataFactory.Instance.FindChildPages<PageTypeBase>(parent))
            {
                bool hasChildren = DataFactory.Instance.FindChildPages<PageTypeBase>(page.Id).Count > 0;
                tree.Add(new PageTreeItem() { Id = page.Id, data = page.PageName, state = hasChildren ? "closed" : null });
            }

            return tree;
        }
    }
}
