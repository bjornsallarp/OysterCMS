using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS.PageTypes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PageTypePropertyAttribute : Attribute
    {
        public string EditDescription { get; set; }
        public int SortOrder { get; set; }
        public string EditCaption { get; set; }
        public Type PropertyType { get; set; }

        public string PropertyName { get; internal set; }
    }
}
