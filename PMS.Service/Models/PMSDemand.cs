using PMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Service
{
    public class PMSDemand
    {
        public System.Guid Id { get; set; }
        public System.Guid MemberId { get; set; }
        public System.Guid PublisherId { get; set; }
        public string BookId { get; set; }
        public string BookName { get; set; }
        public int PublishYear { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DemandDate { get; set; }

        public string MemberName { get; set; }
        public string PublisherName { get; set; }

        public PMSDemand()
        {
        }

        public PMSDemand(BookDemands d)
        {
            this.Id = d.Id;
            this.MemberId = d.MemberId;
            this.PublisherId = d.PublisherId;
            this.BookId = d.BookId;
            this.BookName = d.BookName;
            this.PublishYear = d.PublishYear;
            this.Quantity = d.Quantity;
            this.DemandDate = d.DemandDate;
            this.MemberName = d.Member.UserName;
            this.PublisherName = d.Publisher.Name;
        }

        public PMSDemand(BookDemands d, Member m, Publisher p) : this(d)
        {
            d.Member = m;
            d.Publisher = p;
        }
    }
}
