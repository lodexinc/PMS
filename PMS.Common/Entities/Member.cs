using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public class Member : iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string University { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<BookDemands> BookDemands { get; set; }

        public Member()
        {
            BookDemands = new HashSet<BookDemands>();
        }
    }
}
