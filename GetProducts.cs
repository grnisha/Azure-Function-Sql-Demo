using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Demo
{
    public static class GetProducts
    {
        [FunctionName("GetProducts")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "getproducts")] HttpRequest req,
            [Sql("select * from Products", "SqlConnectionString")] IEnumerable<Product> products,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function retrieved {products.Count()} products.");

            return new OkObjectResult(products);
        }
    }
}
