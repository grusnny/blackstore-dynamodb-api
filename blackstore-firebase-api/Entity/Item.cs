using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackstore_firebase_api.Entity
{
    public class Item
    {

        public string id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string thumbnail { get; set; }
        public City city { get; set; }
        public int price { get; set; }
        public string currency { get; set; }
        public int rating { get; set; }

    }
}
