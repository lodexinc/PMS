using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Service
{
    // Facade Design Pattern
    public class Mongo : IMongo
    {
        static MongoDatabase _database = null;

        const String ServerHost = "localhost";
        const Int32 Port = 27017;
        const String BooksDatabase = "BooksDB";
        const String BooksCollection = "books";

        public Mongo()
        {
        }

        // Singlton Design Pattern
        public static MongoDatabase database
        {
            get
            {
                if (_database == null)
                {
                     // Create server settings to pass connection string, timeout, etc.
                    MongoServerSettings settings = new MongoServerSettings();
                    settings.Server = new MongoServerAddress(ServerHost, Port);
                    // Create server object to communicate with our server
                    MongoServer server = new MongoServer(settings);
                    // Get our database instance to reach collections and data
                    _database = server.GetDatabase(BooksDatabase);
                }
                return _database;
            }
        }

        public bool IsConnected()
        {

            bool IsConnected = false;
            if (database.Server.State == MongoServerState.Connected)
                IsConnected = true;
            else
                IsConnected = false;

            return IsConnected;
        }

        public void SaveBook(Book b)
        {
            var books = database.GetCollection(BooksCollection);
            var result = books.Insert(b);
        }

        public List<Book> GetAllBooks()
        {
            MongoCollection<Book> books = database.GetCollection<Book>(BooksCollection);
            var results = books.FindAll().SetSortOrder(SortBy.Descending("CreationTimeStamp"));
            return results.ToList();
        }

        public List<Book> FindBookByAuthor(String Author)
        {
            var query = Query.And(
                Query.EQ("Author", BsonValue.Create(Author)));

            MongoCollection<Book> books = database.GetCollection<Book>(BooksCollection);
            MongoCursor<Book> cursor = books.Find(query);
            return cursor != null ? cursor.ToList() : null;
        }
    }
}
