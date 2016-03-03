using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public class ExceptionHelper
    {
        public static string GetMessageFromException(Exception exception)
        {
            if (exception == null) return string.Empty;

            string exceptionMessage = exception.Message;
            while (exception.InnerException != null)
            {
                exceptionMessage += Environment.NewLine + exception.InnerException.Message;
                exception = exception.InnerException;
            }
            exceptionMessage += exception.StackTrace;
            return exceptionMessage;
        }

    }
}
