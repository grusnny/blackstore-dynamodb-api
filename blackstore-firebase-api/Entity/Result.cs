using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackstore_firebase_api.Entity
{
    public class Result
    {
        public string query { get; set; }
        public int total { get; set; }
        public Seller seller { get; set; }
        public List<Item> items { get; set; }

    }
}
