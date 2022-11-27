using BO;

namespace BlApi
{
    public interface IProduct
    {
        public IEnumerable<BO.ProductForList> GetList();
        public Product GetProductManeger();
        public Product GetProductClient();
        public void Add(Product product);
        public void Update(Product product);    
        public void Delete(int id);    

    }
}
