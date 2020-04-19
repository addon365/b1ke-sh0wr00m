using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Common.Helper
{
    public static class ExceptionHelper
    {
        public static Exception GetRootException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
