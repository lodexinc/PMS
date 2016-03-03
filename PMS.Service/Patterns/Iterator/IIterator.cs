using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Service.Patterns.Iterator
{
    public interface IIterator
    {
        Book First();
        Book Next();

        Book Current
        {
            get;
        }

        bool IsDone
        {
            get;
        }
    }
}