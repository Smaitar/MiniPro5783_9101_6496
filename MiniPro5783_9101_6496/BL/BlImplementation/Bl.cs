using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    public class Bl :IBL
    {
        public ICart Cart => new Cart();
        public IOrder Order => new Order();
        public IProduct Product => new Product();
    }
}
