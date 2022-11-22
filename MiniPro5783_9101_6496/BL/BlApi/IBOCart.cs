using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBOCart
    {
        public Cart AddProduct(Cart cart,int id );    
        public Cart UpdateCart(Cart cart, int id,int amount);
        public bool AprrovedCart(Cart cart, string name, string mail, string adress);
    }
}
