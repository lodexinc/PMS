using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.Http.OData.Routing;
using PMS.Common;

namespace PMS.Service.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using PMS.Common;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<BookDemands>("BookDemands");
    builder.EntitySet<Member>("Members"); 
    builder.EntitySet<Publisher>("Publishers"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BookDemandsController : ODataController
    {
        private PMSContext db = new PMSContext();

        // GET: odata/BookDemands
        [EnableQuery]
        public IQueryable<BookDemands> GetBookDemands()
        {
            return db.BookDemands;
        }

        // GET: odata/BookDemands(5)
        [EnableQuery]
        public SingleResult<BookDemands> GetBookDemands([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.BookDemands.Where(bookDemands => bookDemands.Id == key));
        }

        // PUT: odata/BookDemands(5)
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<BookDemands> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BookDemands bookDemands = await db.BookDemands.FindAsync(key);
            if (bookDemands == null)
            {
                return NotFound();
            }

            patch.Put(bookDemands);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDemandsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bookDemands);
        }

        // POST: odata/BookDemands
        public async Task<IHttpActionResult> Post(BookDemands bookDemands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookDemands.Add(bookDemands);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookDemandsExists(bookDemands.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(bookDemands);
        }

        // PATCH: odata/BookDemands(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<BookDemands> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BookDemands bookDemands = await db.BookDemands.FindAsync(key);
            if (bookDemands == null)
            {
                return NotFound();
            }

            patch.Patch(bookDemands);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDemandsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(bookDemands);
        }

        // DELETE: odata/BookDemands(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            BookDemands bookDemands = await db.BookDemands.FindAsync(key);
            if (bookDemands == null)
            {
                return NotFound();
            }

            db.BookDemands.Remove(bookDemands);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/BookDemands(5)/Member
        [EnableQuery]
        public SingleResult<Member> GetMember([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.BookDemands.Where(m => m.Id == key).Select(m => m.Member));
        }

        // GET: odata/BookDemands(5)/Publisher
        [EnableQuery]
        public SingleResult<Publisher> GetPublisher([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.BookDemands.Where(m => m.Id == key).Select(m => m.Publisher));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookDemandsExists(Guid key)
        {
            return db.BookDemands.Count(e => e.Id == key) > 0;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CancelDemand([FromODataUri] Guid key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await Task.Run(() => { Console.WriteLine("test"); } );

            string reason = (string)parameters["Reason"];

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public IHttpActionResult MostWanted()
        {
            var bd = db.BookDemands.Max(x => x.BookName).First();
            return Ok(bd);
        }
    }
}
