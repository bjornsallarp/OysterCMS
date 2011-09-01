using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace OysterCMS.PropertyControls
{
    public class PropertyNumberControl : PropertyControl
    {
        private TextBox inputBox = new TextBox();

        public override void CreateChildControls(Control container)
        {
            inputBox.ID = PropertyName;
            inputBox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            inputBox.Text = Value as string;

            container.Controls.Add(inputBox);
        }

        public override object Value 
        {
            get 
            { 
                int value = 0;
                if(int.TryParse(inputBox.Text, out value))
                    return value;

                return null;
            }
            set { if (value != null) { inputBox.Text = value.ToString(); } } 
        }
    }
}
