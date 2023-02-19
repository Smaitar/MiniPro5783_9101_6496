using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct
{
    public enum Category { ring, bracelet, necklace, earring, sets };
    public class Product
    {
        public int ID { get; set; }//product ID
        public string Name { get; set; }
        public Category Category { get; set; }
        public int InStock { get; set; }
        public double Price { get; set; }
    }
    public class ProductForList
    {
        public int ID { get; set; }//product ID
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
    }

}
