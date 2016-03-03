using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Service.Patterns.Iterator
{
    public class BooksCollection : ICollection
    {
        private ArrayList _items = new ArrayList();

        public BooksCollection(ArrayList items)
        {
            _items = items;
        }

        public BooksIterator CreateIterator()
        {
            return new BooksIterator(this);
        }

        public int MyCollectionCount
        {
            get
            {
                return _items.Count;
            }
        }

        public object this[int index]
        {
            get {
                return _items[index];
            }
            set {
                _items.Add(value);
            }
        }

    }
}