using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PMS.Common
{
    public class BookDemands : iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }
        public System.Guid MemberId { get; set; }
        public System.Guid PublisherId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DemandDate { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }

        public virtual Member Member { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
