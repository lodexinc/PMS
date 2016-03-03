using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Service
{
    public class Book
    {
        public ObjectId id { get; set; }

        [BsonElementAttribute("Title")]
        public string Title { get; set; }

        [BsonElementAttribute("Subject")]
        public string Subject { get; set; }

        [BsonElementAttribute("Author")]
        public string Author { get; set; }

        [BsonElementAttribute("PublishYear")]
        public int PublishYear { get; set; }

        [BsonElementAttribute("CreationTimeStamp")]
        public DateTime CreationTimeStamp { get; set; }
        
    }

    public enum SubjectEnum
    { 
        ComputerScience,
        Physics,
        Chemistry,
        Mathematics,
        Biology,
        SocialScience
    }

}
