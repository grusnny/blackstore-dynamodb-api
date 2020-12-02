using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackstore_firebase_api.Entity
{
    [FirestoreData]
    public class Product
    {
        [FirestoreProperty]
        public string id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string brand { get; set; }
        [FirestoreProperty]
        public string thumbnail { get; set; }
        [FirestoreProperty]
        public List<string> pictures { get; set; }
        [FirestoreProperty]
        public City city { get; set; }
        [FirestoreProperty]
        public Seller seller { get; set; }
        [FirestoreProperty]
        public string description { get; set; }
        [FirestoreProperty]
        public int price { get; set; }
        [FirestoreProperty]
        public string currency { get; set; }
        [FirestoreProperty]
        public int rating { get; set; }

    }
}
