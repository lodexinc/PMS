using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public class Publisher : iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BookDemands> BookDemands { get; set; }

        public Publisher()
        {
            BookDemands = new HashSet<BookDemands>();
        }
    }
}
