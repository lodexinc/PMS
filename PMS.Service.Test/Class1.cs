using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PMS.Service.Test
{
    public class Class1
    {
        [Fact(Skip="Skipping")]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact(Skip = "Skipping")]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory(Skip = "Skipping")]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
