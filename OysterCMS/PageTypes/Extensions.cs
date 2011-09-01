using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OysterCMS.PageTypes
{
    public static class Extensions
    {
        public static bool HasAttribute(this MemberInfo memberInfo, Type attributeType)
        {
            return memberInfo.GetCustomAttributes(attributeType, false).Length > 0;
        }

        public static PropertyInfo[] GetPublicOrPrivateProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public static IEnumerable<PageTypePropertyAttribute> PageTypePropertyAttributes(this Type type)
        {
            IEnumerable<PropertyInfo> attributes = type.GetPublicOrPrivateProperties().Where(p => p.HasAttribute(typeof(PageTypePropertyAttribute)));

            List<PageTypePropertyAttribute> retVal = new List<PageTypePropertyAttribute>();
            foreach (var attribute in attributes)
            {
                PageTypePropertyAttribute attr = attribute.GetCustomAttributes(typeof(PageTypePropertyAttribute), true).FirstOrDefault() as PageTypePropertyAttribute;
                if (attr != null)
                {
                    attr.PropertyName = attribute.Name;
                    retVal.Add(attr);
                }
            }

            return retVal;
        }
    }
}
