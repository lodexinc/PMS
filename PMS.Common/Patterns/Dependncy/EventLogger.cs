using PMS.Common.Patterns.Dependncy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public class EventLogger : EventLog, ILogger
    {
        public EventLogger()
        {
            this.Log = ConfigurationManager.AppSettings["LogName"];
        }

        public bool ifExists()
        {
            return EventLog.SourceExists(this.Log);
        }

        public void error(string logMessage)
        {
            doLog(logMessage, EventLogEntryType.Error);
        }

        public void warn(string logMessage)
        {
            doLog(logMessage, EventLogEntryType.Warning);
        }

        public void log(string logMessage)
        {
            doLog(logMessage, EventLogEntryType.Information);
        }

        private void doLog(string logMessage, EventLogEntryType currentType)
        {
            try
            {
                Source = Log;
                WriteEntry(logMessage, currentType);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
