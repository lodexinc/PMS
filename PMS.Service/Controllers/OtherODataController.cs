using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace PMS.Service.Controllers
{
    public class OtherODataController : ODataController
    {
        [HttpGet]
        [ODataRoute("GetGoldRate(Country={country})")]
        public IHttpActionResult GetGoldRate([FromODataUri] string country)
        {
            double rate = 56;  // Use a fake number for the sample.
            return Ok(rate);
        }

    }
}
