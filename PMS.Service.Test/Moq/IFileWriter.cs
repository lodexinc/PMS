using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test.Moq
{
    public interface IFileWriter
    {
        string FileName { get; set; }
        void WriteLine(string line);
        bool IsWritten();
    }
}
