using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service.Test
{
    public class FakeAccountRepository : IRepository<Account>
    {
        public FakeAccountRepository()
        {
        }

        public FakeAccountRepository(ICollection<Account> accountList)
        {
            Data = accountList;
        }

        
    }
}
