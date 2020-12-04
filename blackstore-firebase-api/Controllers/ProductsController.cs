using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blackstore_firebase_api.Entity;
using blackstore_firebase_api.Configuration;
using Microsoft.AspNetCore.Cors;

namespace blackstore_firebase_api.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ProductsController : Controller
    {
        DynamoDbConfiguration configuracion = DynamoDbConfiguration.Instance;

     

        [HttpGet("/api/createtable")]
        public async Task<String> CreateTable()
        {

            return await configuracion.createTable();

        }

       

      

    }
}