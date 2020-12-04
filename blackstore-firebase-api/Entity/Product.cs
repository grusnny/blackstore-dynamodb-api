using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackstore_firebase_api.Entity
{
    [DynamoDBTable("Products")]
    public class Product
    {
        [DynamoDBHashKey]
        public string id { get; set; }
        [DynamoDBProperty]
        public string name { get; set; }
        [DynamoDBProperty]
        public string brand { get; set; }
        [DynamoDBProperty]
        public string thumbnail { get; set; }
        [DynamoDBProperty]
        public List<string> pictures { get; set; }
        [DynamoDBProperty]
        public City city { get; set; }
        [DynamoDBProperty]
        public Seller seller { get; set; }
        [DynamoDBProperty]
        public string description { get; set; }
        [DynamoDBProperty]
        public float price { get; set; }
        [DynamoDBProperty]
        public string currency { get; set; }
        [DynamoDBProperty]
        public float rating { get; set; }

    }
}