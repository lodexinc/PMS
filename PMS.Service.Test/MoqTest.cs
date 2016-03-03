using Moq;
using PMS.Service.Test.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PMS.Service.Test
{
    public class MoqTest : ContextSpecification
    {
        private Order order;
        private Mock<IFileWriter> mockFileWriter;
        private OrderWriter orderWriter;

        public override void EstablishContext()
        {
            order = new Order();
            order.OrderId = 1001;
            order.OrderTotal = 10.53M;

            mockFileWriter = new Mock<IFileWriter>();
            orderWriter = new OrderWriter(mockFileWriter.Object);
        }

        public override void Because()
        {
            orderWriter.WriteOrder(order);
        }

        [Fact]
        public void it_should_pass_data_to_file_writer()
        {
            //mockFileWriter.Verify(fw => fw.WriteLine("1001,10.53"), Times.Exactly(1));
            //mockFileWriter.Verify(fw => fw.WriteLine(It.IsAny<string>()), Times.Exactly(1));
            //mockFileWriter.Verify(fw => fw.WriteLine(It.IsRegex("^1001")), Times.Exactly(1));
            //mockFileWriter.Verify(fw => fw.WriteLine(It.Is<string>(s => s.Length > 3)), Times.Exactly(1));
            //mockFileWriter.Verify(fw => fw.WriteLine(It.Is<string>(s => s.StartsWith("1001"))), Times.Exactly(1));

            //string expectedValue = "1001,10.53";
            //mockFileWriter.Verify(fw => fw.WriteLine(It.Is<string>(s => s.StartsWith(expectedValue))), Times.Exactly(1));

            mockFileWriter.Setup(fw => fw.IsWritten()).Returns(false);

        }

        [Fact]
        public void it_should_set_file_name()
        {
            mockFileWriter.VerifySet(fw => fw.FileName = "1001.txt");

            //int calls = 0;
            //List<string> callss = new List<string>();
            //mockFileWriter.Setup(foo => foo.WriteLine("test")).Callback(() => calls++);
            //mockFileWriter.Setup(foo => foo.WriteLine("test")).Callback((string ss) => callss.Add(ss));
        }
    }
}
