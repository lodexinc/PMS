using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    // Unit of Work Design Pattern
    public class DemandsManager : BaseEntityManager<BookDemands>
    {
        public DemandsManager()
        {
            
        }

        public DemandsManager(PMSContext dbContext) : base(dbContext)
        {
        }

        #region Demands
        public void PlaceDemand(BookDemands d)
        {
            Insert(d);
        }

        public IEnumerable<BookDemands> GetMyDemands(Guid MemberId)
        {
            //return this.GetAll("Member,Publisher").Where(d => d.MemberId == MemberId);
            var results = from d in CurrentContext.BookDemands.Include("Member").Include("Publisher")
                          //where d.MemberId == MemberId
                          select d;
            return results;
        }

        #endregion
    }
}
