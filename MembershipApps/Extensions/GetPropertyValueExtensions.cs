using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MembershipApps.Extensions
{
    public static class GetPropertyValueExtensions
    {
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType()
                .GetProperty(propertyName)
                .GetValue(item, null).ToString();
        }
    }
}