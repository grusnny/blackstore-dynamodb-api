using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

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

        }
}
