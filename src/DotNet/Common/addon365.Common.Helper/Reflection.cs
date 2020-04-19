using System;

namespace addon365.Common.Helper
{
    public static class  Reflection
    {
        public static string GetPropFullName(object src, string propName)
        {
            string FullName = "";
            try
            {
                FullName = src.GetType().FullName + "." + src.GetType().GetProperty(propName).Name;
            }
            catch
            {
                FullName = "";
            }
            return FullName;
        }
        public static string GetFullName(object src)
        {
            string FullName = "";
            try
            {
                FullName = src.GetType().FullName;
            }
            catch
            {
                FullName = "";
            }
            return FullName;
        }
    }
}
