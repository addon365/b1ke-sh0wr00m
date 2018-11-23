using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ViewModel
{
  
        public static class MyExtensions
        {
            public static int WordCount(this String str)
            {
                return str.Split(new char[] { ' ', '.', '?' },
                                 StringSplitOptions.RemoveEmptyEntries).Length;
            }
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

    }
    
}
