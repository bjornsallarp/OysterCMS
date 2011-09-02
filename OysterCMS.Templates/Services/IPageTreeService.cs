using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OysterCMS.Templates.Services
{
    [ServiceContract(Namespace = "")]
    public interface IPageTreeService
    {
        [OperationContract]
        List<PageTreeItem> GetChildren(Guid parent);
    }

    [DataContract]
    public class PageTreeItem
    {
        [DataMember]
        public string data { get; set; }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string state { get; set; }
    }
}
