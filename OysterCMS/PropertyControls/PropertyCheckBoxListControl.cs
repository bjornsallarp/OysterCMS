using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using OysterCMS.PageTypes;

namespace OysterCMS.PropertyControls
{
    public class PropertyCheckBoxListControl : PropertyControl
    {
        private CheckBoxList listBox = new CheckBoxList();

        public override void CreateChildControls(Control container)
        {
            PropertyInfo pi = PageType.GetProperty(PropertyName);

            var prop = pi.GetCustomAttributes(typeof (AllowedPropertyValuesAttribute), true).FirstOrDefault() as AllowedPropertyValuesAttribute;
            
            if (prop != null && prop.Values != null)
            {
                var selected = selectedValues ?? prop.SelectedValues;

                foreach (string s in prop.Values)
                {
                    var item = new ListItem(s);
                    if (selected != null)
                    {
                        item.Selected = selected.Contains(s);
                    }

                    listBox.Items.Add(item);
                }
            }
           
            container.Controls.Add(listBox);
        }

        private List<string> selectedValues;
        public override object Value
        {
            get
            {
                selectedValues = new List<string>();
                foreach (ListItem item in listBox.Items)
                {
                    if (item.Selected)
                    {
                        selectedValues.Add(item.ToString());
                    }
                }

                return selectedValues;
            }

            set { selectedValues = value as List<string>; }
        }

        public override string InputControlId
        {
            get { return listBox.ID; }
        }
    }
}
