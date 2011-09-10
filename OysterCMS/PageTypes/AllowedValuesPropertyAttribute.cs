using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS.PageTypes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AllowedPropertyValuesAttribute : Attribute
    {
        public List<string> Values { get; private set; }

        public AllowedPropertyValuesAttribute(params string[] values)
        {
            Values = new List<string>(values);
        }
    }
}
