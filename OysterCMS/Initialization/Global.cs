using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS.Initialization
{
    public class Global : System.Web.HttpApplication
    {
        protected virtual void Application_Start(object sender, EventArgs e)
        {
            InitializationEngine.Initialize();
        }
    }
}
