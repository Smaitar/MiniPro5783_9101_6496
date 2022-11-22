using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Cart
    {
        public string CustomerName { get; set; }//CustomerName
        public string CustomerEmail { get; set; }//CustomerEmail
        public string CustomerAdress { get; set; }//CustomerAdress
        public IEnumerable< OrderItem> Items { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return $@"
           Cart Details:
           Customer Name {CustomerName},
    	   Customer Email: {CustomerEmail},
    	   Customer Adress: {CustomerAdress},
           Total Price: {TotalPrice}'
           Items: ";
            string s =null;  
            foreach (var item in Items)
            {
                s = s + item;
            }
            return s;   
        }
    }
}
