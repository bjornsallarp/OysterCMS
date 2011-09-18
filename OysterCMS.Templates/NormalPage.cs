using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using OysterCMS.PageTypes;
using OysterCMS.PropertyControls;

namespace OysterCMS
{
    [PageType(Name = "Normalsida", FileName = "~/Default.aspx", SortOrder = 0)]
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

        [AllowedPropertyValues("Red", "Green", "Blue")]
        [PageTypeProperty(EditCaption = "Choose color", SortOrder = 6, PropertyType = typeof(PropertyDropDownListControl))]
        public string EditorChooseColor { get; set; }

        [DefaultValue(true)]
        [PageTypeProperty(EditCaption = "IsTrue", SortOrder = 7, PropertyType = typeof(PropertyCheckBoxControl))]
        public bool IsChecked { get; set; }

        [AllowedPropertyValues( new string[] {"Red", "Green", "Blue"}, new string[] {"Red", "Blue"})]
        [PageTypeProperty(EditCaption = "Check one or more", SortOrder = 8, PropertyType = typeof(PropertyCheckBoxListControl))]
        public List<string> CheckMania { get; set; }
    }
}
