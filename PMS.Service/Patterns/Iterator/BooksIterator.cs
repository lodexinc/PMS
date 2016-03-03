using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Service.Patterns.Iterator
{
    public class BooksIterator : IIterator
    {
        private BooksCollection _collection;
        private int _current = 0;
        private int _step = 1;

        public BooksIterator(BooksCollection myCollection)
        {
            this._collection = myCollection;
        }

        public int Step
        {
           get
            {
                return _step;
            }

            set
            {
                _step = value;
            }
        }

        public Book Current
        {
            get
            {
                return _collection[_current] as Book;
            }
        }

        public bool IsDone
        {
            get
            {
                return _current >= _collection.MyCollectionCount;
            }
        }

        public Book First()
        {
            _current = 0;
            return _collection[_current] as Book;
        }

        public Book Next()
        {
            _current += _step;

            if (!IsDone)
                return _collection[_current] as Book;
            else
                return null;
        }
    }
}