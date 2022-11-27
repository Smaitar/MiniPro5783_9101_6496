using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBL
    {
        public IProduct Iproduct { get; }
        public ICart ICart { get; }
        public IOrder IOrder { get; }
        bool GetEmail(string email);
    }
}
