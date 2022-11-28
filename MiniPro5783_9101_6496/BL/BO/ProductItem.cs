using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductItem
    {
        public int ID { get; set; }//product ID
        public string? Name { get; set; }
        public Category Category { get; set; }
        public int InStock { get; set; }
        public double Price { get; set; }
        public int Amount{ get; set; }

        public override string ToString()
        {
            return $@"
           ProductItem Details:
           Product ID: {ID}, 
           Product Name: {Name},
    	   Product Category: {Category},
    	   InStock: {InStock},
           Price: {Price},
           Amount:{Amount}.";
        }
    }
}
