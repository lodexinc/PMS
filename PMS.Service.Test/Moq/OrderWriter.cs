using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test.Moq
{
    public class OrderWriter
    {
        private bool _isWritten;
        private readonly IFileWriter fileWriter;

        public OrderWriter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void WriteOrder(Order order)
        {
            fileWriter.FileName = order.OrderId + ".txt";
            fileWriter.WriteLine(String.Format("{0},{1}", order.OrderId, order.OrderTotal));
        }

        public bool IsWritten()
        {
            _isWritten = _isWritten ? true : false;
            return _isWritten;
        }
    }
}
