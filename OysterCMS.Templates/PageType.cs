using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using OysterCMS.PageTypes;
using OysterCMS.PropertyControls;

namespace OysterCMS
{
    public class NormalPage : PageTypeBase
    {
        [PageTypeProperty(EditCaption = "Caption", SortOrder = 2, PropertyType = typeof(PropertyTextBoxControl))]
        public string MainHeading { get; set; }

        [PageTypeProperty(EditCaption = "Articles to list", SortOrder = 3, PropertyType = typeof(PropertyNumberControl))]
        public int NewsArticlesToList { get; set; }

        [PageTypeProperty(EditCaption = "Name of the page editor", SortOrder = 4, PropertyType = typeof(PropertyTextBoxControl))]
        public string EditorName { get; set; }

        [PageTypeProperty(EditCaption = "Edit body", SortOrder = 5, PropertyType = typeof(PropertyXhtmlControl))]
        public string EditorBody { get; set; }
    }
}
