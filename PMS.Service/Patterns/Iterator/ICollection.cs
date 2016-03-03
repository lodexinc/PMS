using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Service.Patterns.Iterator
{
    public interface ICollection
    {
        BooksIterator CreateIterator();
    }
}