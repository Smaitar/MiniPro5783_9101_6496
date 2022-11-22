using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal class OrderForList
    {
        public int ID { get; set; }//OrderID
        public string CustomerName { get; set; }//CustomerName
        public int AmountOfItem { get; set; }
        public BO.Enums.OrderStatus status { get; set; }
        public double  TotalPrice { get; set; }

        public override string ToString()
        {
            return $@"
           OrderForList Details:
           Order ID: {ID}, 
           Customer Name {CustomerName},
           AmountOfItem: {AmountOfItem},
           Order Status:  {status},
           Total Price: {TotalPrice}.";
        }
    }
}
