
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using blackstore_firebase_api.Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace blackstore_firebase_api.Configuration
{
    public class DynamoDbConfiguration
    {

            private readonly static DynamoDbConfiguration _instance = new DynamoDbConfiguration();
            private string accessKey = "";
            private string secretKey = "";
            string tableName = "Products";
            string hashKey = "id";
            private AmazonDynamoDBClient client;
            IConfigurationRoot Configuration;

            public DynamoDbConfiguration()
            {

                Configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();
                accessKey = Configuration["AWS:AccessKey"];
                secretKey = Configuration["AWS:SecretKey"];

                Console.WriteLine("Creating credentials and initializing DynamoDB client");
                var credentials = new BasicAWSCredentials(accessKey, secretKey);
                client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
            }

        public static DynamoDbConfiguration Instance
        {
            get
            {
                return _instance;
            }
        }
        public async Task<String> createTable()
        {

            Console.WriteLine("Verify table => " + tableName);
            var tableResponse = await client.ListTablesAsync();
            Console.WriteLine(tableResponse.TableNames);
            if (!tableResponse.TableNames.Contains(tableName))
            {
                Console.WriteLine("Table not found, creating table => " + tableName);
                await client.CreateTableAsync(new CreateTableRequest
                {
                    TableName = tableName,
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 3,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = hashKey,
                            KeyType = KeyType.HASH
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { AttributeName = hashKey, AttributeType=ScalarAttributeType.S }
                    }
                });

                bool isTableAvailable = false;
                while (!isTableAvailable)
                {
                    Console.WriteLine("Waiting for table to be active...");
                    Thread.Sleep(5000);
                    var tableStatus = await client.DescribeTableAsync(tableName);
                    isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
                }
            }
            return "The table already exists!";

        }

        public async Task<Product> AddProduct(Product product)
        {
            product.name = product.name.ToLower();
            var context = new DynamoDBContext(client);
            await context.SaveAsync<Product>(product);
            List<ScanCondition> conditions = new List<ScanCondition>();
            conditions.Add(new ScanCondition("id", ScanOperator.Equal, product.id));
            var allDocs = await context.ScanAsync<Product>(conditions).GetRemainingAsync();
            var savedState = allDocs.FirstOrDefault();

            if (JsonConvert.SerializeObject(savedState) == JsonConvert.SerializeObject(product))
                return product;
            else
                return new Product();

        }

        public async Task<List<Product>> GetAllProducts()
        {

            var context = new DynamoDBContext(client);
            var conditions = new List<ScanCondition>();
            var allDocs = await context.ScanAsync<Product>(conditions).GetRemainingAsync();
            return allDocs;
        }


        public async Task<Product> GetProductById(string id)
        {

            var context = new DynamoDBContext(client);
            Product product = await context.LoadAsync<Product>(id);

            return product;

        }
    }
}
