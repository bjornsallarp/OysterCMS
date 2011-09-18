using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OysterCMS.PropertyControls
{
    public class PropertyCheckBoxControl : PropertyControl
    {
        private CheckBox box = new CheckBox();

        public override void CreateChildControls(Control container)
        {
            if (initalValue == null)
            {
                PropertyInfo pi = PageType.GetProperty(PropertyName);
                var dva = pi.GetCustomAttributes(typeof(DefaultValueAttribute), true).FirstOrDefault() as DefaultValueAttribute;

                if (dva != null)
                {
                    if (dva.Value is bool)
                    {
                        box.Checked = (bool)dva.Value;
                    }
                }
            }
            else
            {
                box.Checked = initalValue.Value;
            }
           

            container.Controls.Add(box);
        }

        private bool? initalValue = null;
        public override object Value
        {
            get { return box.Checked; }
            set
            {
                if (value != null)
                {
                    initalValue = (bool)value;
                }
            }
        }

        public override string InputControlId
        {
            get { return box.ID; }
        }
    }
}
