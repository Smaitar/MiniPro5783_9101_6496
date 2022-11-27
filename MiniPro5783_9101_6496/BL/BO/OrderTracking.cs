using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//OrderID

        public OrderStatus Status { get; set; }

        public List<(DateTime?, OrderStatus)> OrderTrackings { get; set; }  

        public override string ToString()
        {
            return $@"
           OrderTracking Details:
           Order ID: {ID}, 
           Order Status:";
            string s = null;
            foreach (var item in OrderTrackings)
            {
                s += item;   
            }
            return s;   
        }
    }
}
