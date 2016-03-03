using Microsoft.OData.Client;
using PMS.ODataClient.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri serviceUri = new Uri("http://localhost:10104/odata/");
            var container =  new Container(serviceUri);

            foreach (var p in container.BookDemands)
            {
                Console.WriteLine("{0} {1} ", p.BookName, p.DemandDate);
            }

            Uri actionUri = new Uri(serviceUri, "BookDemands(dfdd892f-0dd3-4c36-b82c-206adacc67de)/ODataService.CancelDemand");
            var actionResult = container.Execute<string>(actionUri, "POST", true, new BodyOperationParameter("Reason", "Good"));

            Uri functionUri = new Uri(serviceUri, "BookDemands/ODataService.MostWanted");
            var functionResult = container.Execute<string>(functionUri, "GET", true);

            var result = container.GetGoldRate("Pakistan");

            Console.ReadLine();
        }

        static void AddBookDemand(Container container, ODataClient.PMS.Common.BookDemands bd)
        {
            container.AddToBookDemands(bd);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }
    }
}
