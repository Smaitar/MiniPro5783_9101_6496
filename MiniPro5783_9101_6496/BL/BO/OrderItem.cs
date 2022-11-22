using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderItem
    {
        public int ID { get; set; }//OrderItem ID
        public int ProductID { get; set; }//ProductID
        public int OrderID { get; set; }//OrderID
        public double Price { get; set; }// Price
        public int Amount { get; set; }//Amount
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return $@"
           Order Item Details:
           Orders Item ID: {ID}, 
           Product ID: {ProductID},
    	   OrderID: {OrderID},
    	   Price: {Price},
           Amount: {Amount},
           Total Price: {TotalPrice}.";
        }
    }
}
