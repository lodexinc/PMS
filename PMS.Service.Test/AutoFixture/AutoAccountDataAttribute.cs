namespace PMS.Service.Test
{
    using System.Linq;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Xunit2;

    internal class AutoAccountDataAttribute : AutoDataAttribute
    {
        public AutoAccountDataAttribute()
        {
            Fixture.RepeatCount = 10;
            var accountList = Fixture.CreateMany<Account>().ToList();
            Fixture.Register<IRepository<Account>>(() => new FakeAccountRepository(accountList));
        }
    }
}