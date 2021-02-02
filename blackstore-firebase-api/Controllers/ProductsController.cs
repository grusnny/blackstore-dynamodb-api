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
        [HttpGet("/")]
        public String Bienvenido()
        {

            return "¡Bienvenido! se ha conectado con la API de BlackStore.";

        }

        [HttpGet("/api")]
        public async Task<List<Product>> GetAll()
        {

            return await configuracion.GetAllProducts();

        }
      
        [HttpGet("/api/item/{id}")]
        public async Task<Product> DetailProduct(string id)
        {
            return await configuracion.GetProductById(id);
        }


        [HttpPost("/api")]
        public async Task<Product> Post([FromBody] Product product)
        {
            return await configuracion.AddProduct(product);
        }


        [HttpDelete("/api/{id}")]
        public async Task<String> Delete(String id)
        {
            return await configuracion.DeleteProductById(id);
        }

        [HttpGet("/api/search")]
        public async Task<Result> Search([FromQuery] String q)
        {
            return await configuracion.GetProductWhereName(q);
        }



    }
}