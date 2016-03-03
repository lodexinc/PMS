using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Service
{
    public class MongoSeed
    {
        public void Seed()
        {
            for (int i = 0; i < 100; i++)
            {
                new Mongo().SaveBook(new Book() { Subject = SubjectEnum.ComputerScience.ToString(), Title = "Book Title " + i, Author = "Author " + i, PublishYear = DateTime.Now.Year - i, CreationTimeStamp = DateTime.Now });
            }
        }
    }
}
