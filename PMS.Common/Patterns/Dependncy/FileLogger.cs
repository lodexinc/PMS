using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Common.Patterns.Dependncy
{
    public class FileLogger : ILogger
    {
        string basePath = string.Empty;

        public FileLogger()
        {
            this.basePath = ConfigurationManager.AppSettings["LogPath"];
        }

        public void error(string errorMessage)
        {
            logToFile(errorMessage);
        }

        public bool ifExists()
        {
            return File.Exists(this.basePath);
        }

        public void log(string logMessage)
        {
            logToFile(logMessage);
        }

        public void warn(string errorMessage)
        {
            logToFile(errorMessage);
        }

        private void logToFile(string logMessage)
        {
            var f = System.Web.HttpContext.Current.Server.MapPath(this.basePath + "\\Application.log");
            var fs = new FileStream(f, System.IO.FileMode.Append);
            using (StreamWriter file = new StreamWriter(fs))
            {
                file.WriteLine(logMessage);
                file.Flush();
                file.Close();
            }
        }
    }
}
