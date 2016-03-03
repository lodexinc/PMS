using Moq;
using Moq.Language;
using Moq.Language.Flow;
using PMS.Service.Test.AutoFixtureAutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PMS.Service.Test
{
    public class Class2
    {
        [Theory(Skip ="Skip it")]
        [InlineData(Roles.Guest | Roles.User | Roles.Editor, new[] { "Guest", "User", "Editor" })]
        [InlineData(Roles.Administrator, new[] { "Administrator" })]
        [InlineData(Roles.Guest | Roles.Editor, new[] { "Guest", "Editor" })]
        [InlineData(Roles.Editor | Roles.Guest, new[] { "Guest", "Editor" })]
        public void GetRolesIsOk(Roles roles, string[] expected)
        {
            var account = new Account(Guid.NewGuid(), "John Doe") { Roles = roles };
            var repository = new FakeAccountRepository();
            repository.Add(account);
            var foundRoles = (repository.Get() as Account).Roles.ToString();
            Assert.Equal(string.Join(", ",expected), foundRoles);
        }

        [Theory(Skip = "Skip it"), AutoAccountData]
        public void CountIsOk(FakeAccountRepository accountList)
        {
            Assert.Equal(10, accountList.Data.Count);
        }

        [Theory(Skip ="Skip it"), AutoMoqData]
        public void It_Should_Mock(Mock<IRepository<IEntity>> serviceMock, Mock<IEntity> entityMock)
        {
            var entity = entityMock.Object;
            var service = serviceMock.Object;
            //serviceMock.Setup(s => s.Exists(entity.ID)).Returns(true);
            serviceMock.Verify(s => s.Exists(entity.ID), Times.Exactly(1));

            //var raisedEvents = new List<string>();
            //Assert.Equal("Updating", raisedEvents[0]);
            //Assert.Equal("Updated", raisedEvents[1]);
        }
    }
}
