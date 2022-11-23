using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBL
    {
        public IBOProduct Iproduct { get; }
        public IBOCart ICart { get; }
        public IBOOrder IOrder { get; }
        bool GetEmail(string email);
    }
}
