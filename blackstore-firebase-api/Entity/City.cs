using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackstore_firebase_api.Entity
{
    [FirestoreData]
    public class City
    {
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string code { get; set; }
    }
}

