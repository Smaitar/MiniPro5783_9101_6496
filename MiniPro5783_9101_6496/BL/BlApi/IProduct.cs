using BO;

namespace BlApi
{
    public interface IProduct
    {
         IEnumerable<BO.ProductForList> GetList();
         Product GetProductManeger(int id);
         ProductItem GetProductClient(int id, BO.Cart cart);
         void Add(Product product);
         void Update(Product product);    
         void Delete(int id);    

    }
}
