using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class Order
    {
        public int ID { get; set; }//OrderID
        public string CustomerName { get; set; }//CustomerName
        public string CustomerEmail { get; set; }//CustomerEmail
        public string CustomerAdress { get; set; }//CustomerAdress
        public DateTime OrderDate { get; set; }//OrderDate
        public DateTime ShipDate { get; set; }//ShipDate
        public DateTime DeliveryDate { get; set; }//DeliveryDate
        public BO.Enums.OrderStatus status { get; set; }
        public DateTime PaymentDate { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return $@"
           Order Details:
           Order ID: {ID}, 
           Customer Name {CustomerName},
    	   Customer Email: {CustomerEmail},
    	   Customer Adress: {CustomerAdress},
           Order Date: {OrderDate},
           ShipDate: {ShipDate},
           Delivery Date: {DeliveryDate}
           Order Status:  {status},
           Payment Date: {PaymentDate},
           Total Price: {TotalPrice},
           Items:";
            string s = null;
            foreach (var item in Items)
            {
                s += item;
            }
            return s;
        }
   }
}
