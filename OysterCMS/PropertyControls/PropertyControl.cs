using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using OysterCMS.PageTypes;

namespace OysterCMS.PropertyControls
{
    public abstract class PropertyControl : WebControl
    {
        public string PropertyName { get; set; }
        public string EditCaption { get; set; }
        public string EditDescription { get; set; }
        public abstract object Value { get; set; }
        public Type PageType { get; set; }

        public virtual void PopulateFromAttributeSettings(PageTypePropertyAttribute settings, Type pageType)
        {
            this.PropertyName = settings.PropertyName;
            this.EditCaption = settings.EditCaption;
            this.EditDescription = settings.EditDescription;
            this.PageType = pageType;
        }

        public abstract void CreateChildControls(Control container);
        public abstract string InputControlId { get; }
    }
}
