using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DalApi;

namespace BlApi
{
    public interface IBOProduct
    {
        public IEnumerable<ProductForList> GetList();
        public Product GetProductMeneger();
        public Product GetProductClient();
        public int Add(Product product);
        public void Update(Product product);    
        public int Delete(int id);    

    }
}
