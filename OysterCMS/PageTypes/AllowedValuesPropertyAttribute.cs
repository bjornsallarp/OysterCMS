using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS.PageTypes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowedPropertyValuesAttribute : Attribute
    {
        public List<string> Values { get; private set; }
        public List<string> SelectedValues { get; private set; }

        public AllowedPropertyValuesAttribute(params string[] values)
        {
            Values = new List<string>(values);
        }
        
        public AllowedPropertyValuesAttribute(string[] values, string[] selectedValues)
        {
            Values = new List<string>(values);
            SelectedValues = new List<string>(selectedValues);
        }
    }
}
