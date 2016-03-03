using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Common.Patterns.Dependncy
{
    public interface ILogger
    {
        void log(string logMessage);
        void error(string errorMessage);
        void warn(string errorMessage);

        bool ifExists();
    }
}
