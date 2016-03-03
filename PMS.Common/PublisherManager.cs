using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    // Unit of Work Design Pattern
    public class PublisherManager : BaseEntityManager<Publisher>
    {
        public PublisherManager(PMSContext dbContext) : base(dbContext)
        {
        }

        #region Publisher

        public Publisher GetByName(string name)
        {
            var publisher = from p in CurrentContext.Publishers
                            where p.Name.ToLower().Contains(name.ToLower())
                            select p;
            return publisher.FirstOrDefault();
        }
        #endregion
    }
}
