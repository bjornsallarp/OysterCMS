using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using OysterCMS.PropertyControls;

namespace OysterCMS.PageTypes
{
    public abstract class PageTypeBase
    {
        public Guid Id
        {
            get;
            set;
        }

        public Guid ParentId
        {
            get;
            set;
        }

        public DateTime Created
        {
            get;
            set;
        }

        public DateTime Updated
        {
            get;
            set;
        }

        [PageTypeProperty(
            EditCaption = "Page name",
            EditDescription = "Name of the page to be displayed in the edit tree",
            SortOrder = 1, 
            PropertyType = typeof(PropertyTextBoxControl))
        ]
        public string PageName { get; set; }
    }
}
