using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace PMS.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCaseInsensitive(true);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<BookDemands>("BookDemands");
            builder.EntitySet<Member>("Members");
            builder.EntitySet<Publisher>("Publishers");

            builder.Namespace = "ODataService";
            //Action : Post http://localhost:10104/odata/BookDemands(dfdd892f-0dd3-4c36-b82c-206adacc67de)/ODataService.CancelDemand
            builder.EntityType<BookDemands>()
                   .Action("CancelDemand")
                   .Parameter<string>("Reason");

            //Function : Get http://localhost:10104/odata/BookDemands/ODataService.MostWanted
            builder.EntityType<BookDemands>()
                   .Collection
                   .Function("MostWanted")
                   .Returns<string>();

            // Unbound Function  : http://localhost:10104/odata/GetGoldRate(Country='Pakistan')
            builder.Function("GetGoldRate")
                   .Returns<double>()
                   .Parameter<string>("Country");

            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}