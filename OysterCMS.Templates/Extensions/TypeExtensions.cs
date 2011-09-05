using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.UI;

namespace OysterCMS.Templates.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<ValidationAttribute> ValidationAttributes(this Type type, string propertyName)
        {
            PropertyInfo pageTypePropInfo = type.GetProperty(propertyName);
            return pageTypePropInfo.GetCustomAttributes(typeof(ValidationAttribute), true).Cast<ValidationAttribute>();
        }

        public static bool HasValidationAttributes(this Type type, string propertyName)
        {
            return type.ValidationAttributes(propertyName).Count() > 0;
        }

        public static string ValidationPropertyName(this Type type)
        {
            ValidationPropertyAttribute attr = type.GetCustomAttributes(typeof(ValidationPropertyAttribute), true).FirstOrDefault() as ValidationPropertyAttribute;
            return attr != null ? attr.Name : null;
        }
    }
}