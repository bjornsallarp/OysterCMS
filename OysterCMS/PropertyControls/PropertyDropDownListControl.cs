using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.UI;
using OysterCMS.PageTypes;

namespace OysterCMS.PropertyControls
{
    public class PropertyDropDownListControl : PropertyControl
    {
        private DropDownList list = new DropDownList();

        public override void CreateChildControls(Control container)
        {
            PropertyInfo pi = PageType.GetProperty(PropertyName);

            foreach (var obj in pi.GetCustomAttributes(true))
            {
                if (obj is AllowedPropertyValuesAttribute)
                {
                    AllowedPropertyValuesAttribute value = obj as AllowedPropertyValuesAttribute;
                    foreach (string s in value.Values)
                    {
                        var item = new ListItem(s);
                        if (item.Value == initalValue)
                            item.Selected = true;

                        list.Items.Add(item);
                    }
                }
            }
            
            container.Controls.Add(list);
        }

        private string initalValue; 
        public override object Value
        {
            get { return list.SelectedValue; }
            set { initalValue = value as string; }
        }

        public override string InputControlId
        {
            get { return list.ID; }
        }
    }
}
