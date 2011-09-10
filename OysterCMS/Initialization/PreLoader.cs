using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS.Initialization
{
    public class PreLoader : System.Web.Hosting.IProcessHostPreloadClient
    {
        public void Preload(string[] parameters)
        {
            InitializationEngine.Initialize();
        }
    }
}
