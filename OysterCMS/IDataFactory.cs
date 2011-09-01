using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OysterCMS.PageTypes;

namespace OysterCMS
{
    public interface IDataFactory
    {
        void AddPage(object newPage);
        T FindPage<T>(Guid id) where T : PageTypeBase;
        IList<T> FindChildPages<T>(Guid pageId) where T : PageTypeBase;
        void UpdatePage<T>(T modifiedPage) where T : PageTypeBase;
        bool DeletePage(Guid pageId);
    }
}
