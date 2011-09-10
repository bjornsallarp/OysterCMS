using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OysterCMS.PageTypes;

namespace OysterCMS
{
    public class OysterPage<T> : System.Web.UI.Page where T : PageTypeBase
    {
        private bool _currentPageIsLoaded = false;
        private T _currentPage = null;
        public T CurrentPage 
        {
            get
            {
                if (!_currentPageIsLoaded)
                {
                    Guid pageGuid = Guid.Empty;
                    if (Request.QueryString["pageid"] != null && Guid.TryParse(Request.QueryString["pageid"], out pageGuid))
                    {
                        _currentPage = DataFactory.Instance.FindPage<T>(pageGuid);
                    }
                    else
                        _currentPage = DataFactory.Instance.FindChildPages<T>(Guid.Empty).FirstOrDefault();

                    _currentPageIsLoaded = true;
                }

                return _currentPage;
            }
        }

    }
}
