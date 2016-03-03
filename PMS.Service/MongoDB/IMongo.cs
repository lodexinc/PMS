using System.Collections.Generic;

namespace PMS.Service
{
    public interface IMongo
    {
        List<Book> FindBookByAuthor(string Author);
        List<Book> GetAllBooks();
        bool IsConnected();
        void SaveBook(Book b);
    }
}