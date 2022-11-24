using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Enums;

namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//OrderID
        public OrderStatus status { get; set; }
        List<Tuple<DateTime, OrderStatus>> orders { get; set; }  
        public override string ToString()
        {
            return $@"
           OrderTracking Details:
           Order ID: {ID}, 
           Order Status:";
            string s = null;
            foreach (var item in orders)
            {
                s += item;   
            }
            return s;   
        }
    }
}
