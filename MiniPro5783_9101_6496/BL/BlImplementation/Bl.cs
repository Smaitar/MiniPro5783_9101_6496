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
        ICart Cart => new Cart();
        IOrder Order => new Order();
        IProduct Product => new Product();
    }
}
