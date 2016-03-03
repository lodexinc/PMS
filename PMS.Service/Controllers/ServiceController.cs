using Nelibur.ObjectMapper;
using PMS.Common;
using PMS.Service.Patterns.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace PMS.Service.Controllers
{
    /// <summary>
    /// Facade Design Pattern, accessing all functionality through Service Controller
    /// </summary>
    //[Authorize]
    [RoutePrefix("api")]
    public class ServiceController : ApiController
    {
        readonly IMongo mongo;
        readonly PMSContext context;

        // Dependency Injection using Unit IoC
        public ServiceController(IMongo mongo, PMSContext context)
        {
            //new MongoSeed().Seed();
            this.mongo = mongo;
            this.context = context;
        }
        /// <summary>
        /// Returns a list of books
        /// </summary>
        /// <returns>list of book objects</returns>
        [Route("books")]
        public IEnumerable<object> GetAll()
        {
            var mongoBooks = mongo.GetAllBooks();

            // Iterator Design Pattern
            List<Book> books = new List<Book>();
            BooksCollection myBooksCollection = new BooksCollection(new ArrayList(mongoBooks) );
            BooksIterator it = new BooksIterator(myBooksCollection);
            it.Step = 10;
            for (Book b = it.First(); !it.IsDone;)
            {
                books.Add(b);
                b = it.Next();
            }
            return books;
        }

        /// <summary>
        /// returns list of publishers
        /// </summary>
        /// <returns>list of publishers</returns>
        [Route("publishers")]
        public IEnumerable<Publisher> GetPublishers()
        {
            PublisherManager pmm = new PublisherManager(context);
            var publishers = pmm.GetAll().ToList();
            return publishers;
        }

        /// <summary>
        /// Get demands
        /// </summary>
        /// <returns></returns>
        [Route("demands")]
        public IEnumerable<PMSDemand> GetDemands()
        {
            DemandsManager mgr = new DemandsManager(context);
            Guid UserIdGuid = Guid.NewGuid();
            //var demands = mgr.GetMyDemands(UserIdGuid).Select(bd => new PMS.Service.PMSDemand(bd)).ToList();
            List<PMS.Service.PMSDemand> demands = new List<PMSDemand>();
            foreach (var d in mgr.GetMyDemands(UserIdGuid))
            {
                PMS.Service.PMSDemand pmsd = TinyMapper.Map<PMS.Service.PMSDemand>(d);
                demands.Add(pmsd);
            }
            return demands;
        }

        /// <summary>
        /// places demand using passed book demand object
        /// </summary>
        /// <param name="demand">Book Demand object</param>
        /// <returns></returns>
        [Route("demands/place")]
        public HttpResponseMessage PlaceDemand(BookDemands demand)
        {
            PublisherManager pm = new PublisherManager(context);
            MembersManager mm = new MembersManager();
            DemandsManager dm = new DemandsManager();
            demand.Id = Guid.NewGuid();
            demand.DemandDate = DateTime.Now;
            demand.MemberId = mm.GetAll().FirstOrDefault().Id;
            demand.PublisherId = pm.GetAll().FirstOrDefault().Id;
            dm.PlaceDemand(demand);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        /// <summary>
        /// returns publisher by given publisher name
        /// </summary>
        /// <param name="publisherName">string</param>
        /// <returns></returns>
        [Route("publisher/getbyname")]
        public Publisher GetPublishers(string publisherName)
        {
            PublisherManager pmm = new PublisherManager(context);
            var publisher = pmm.GetByName(publisherName);
            return publisher;
        }
        
    }
}
