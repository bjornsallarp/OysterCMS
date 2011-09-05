using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OysterCMS.PropertyControls
{
    public class PropertyXhtmlControl : PropertyControl
    {
        private TextBox inputBox = new TextBox();

        public override void CreateChildControls(Control container)
        {
            inputBox.ID = PropertyName;
            inputBox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            inputBox.Text = Value as string;

            inputBox.CssClass = "xhtmledit";

            container.Controls.Add(inputBox);
        }

        public override object Value
        {
            get { return inputBox.Text; }
            set { inputBox.Text = value == null ? string.Empty : value.ToString(); }
        }

        public override string InputControlId
        {
            get { return inputBox.ID; }
        }
    }
}
