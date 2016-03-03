using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Common.Patterns.Dependncy
{
    public class ExceptionLogger
    {
        // Dependency Injection Design Pattern : constructor with logger
        static ILogger logger;
        
        public ExceptionLogger(ILogger loger)
        {
            logger = loger;
        }

        public void LogException(Exception ex, string entityName, string methodName)
        {
            string message = "Entity Manager. Entity name <" + entityName + ">. Method <" + methodName + ">\n";
            message += ExceptionHelper.GetMessageFromException(ex);
            SaveToLog(message);
            throw new Exception(message);
        }

        public void SaveSQLsToLog(string command)
        {
            try
            {
                SaveToLog(command);
            }
            catch
            {
            }
        }

        public void SaveToLog(string logMessage)
        {
            logger.log(logMessage);
        }

    }
}
