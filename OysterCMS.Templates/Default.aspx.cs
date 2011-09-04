using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using OysterCMS.PageTypes;
using OysterCMS.PropertyControls;

namespace OysterCMS
{
    public partial class _Default : System.Web.UI.Page
    {
        List<PropertyControl> myEditControls = new List<PropertyControl>();

        protected void Page_Init(object sender, EventArgs e)
        {
            PageType page = null;
            if (Request.QueryString["createnew"] == null && Request.QueryString["pageid"] != null)
            {
                page = DataFactory.Instance.FindPage<PageType>(Guid.Parse(Request.QueryString["pageid"]));
            }

            IEnumerable<PageTypePropertyAttribute> properties = typeof(PageType).PageTypePropertyAttributes().OrderBy(a => a.SortOrder);

            int insertIndex = 0;
            foreach (PageTypePropertyAttribute attr in properties)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell());
                row.Cells.Add(new TableCell());
                EditControls.Rows.AddAt(insertIndex, row);
                
                PropertyControl c = Activator.CreateInstance(attr.PropertyType) as PropertyControl;
                c.PopulateFromAttributeSettings(attr);

                if (page != null)
                {
                    c.Value = typeof(PageType).GetProperty(attr.PropertyName).GetValue(page, null) as string;
                }
                
                myEditControls.Add(c);
                c.CreateChildControls(row.Cells[1]);

                Label captionLabel = new Label();
                captionLabel.Text = c.EditCaption;
                captionLabel.ToolTip = c.EditDescription;

                row.Cells[0].Controls.Add(captionLabel);
                
                insertIndex++;
            }

            btn_Save.Click += new EventHandler(btn_Save_Click);
        }

        void btn_Save_Click(object sender, EventArgs e)
        {
            PageType page = null;

            if (Request.QueryString["createnew"] == null && Request.QueryString["pageid"] != null)
            {
                page = DataFactory.Instance.FindPage<PageType>(Guid.Parse(Request.QueryString["pageid"]));
            }
            else
            {
                page = new PageType();
                page.Created = DateTime.Now;
                page.ParentId = Request.QueryString["pageid"] != null ? Guid.Parse(Request.QueryString["pageid"]) : Guid.Empty;
            }

            page.Updated = DateTime.Now; 

            
            Type typeInfo = page.GetType();
            foreach (PropertyControl ctrl in myEditControls)
            {
                PropertyInfo info =  typeInfo.GetProperty(ctrl.PropertyName);
                if(info != null) 
                {
                    info.SetValue(page, ctrl.Value, null);
                }
            }

            if (page.Id == Guid.Empty)
                DataFactory.Instance.AddPage(page);
            else
                DataFactory.Instance.UpdatePage<PageType>(page);
        }
    }
}