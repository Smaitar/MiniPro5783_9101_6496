using BlApi;
using BO;
using Dal;
using DalApi;
//using MDalFacade.DalApi;

namespace BlImplementation
{
    internal class BLProduct :IBOProduct
    {
        IDal dal = new DalList();
        public IEnumerable<BO.ProductForList> GetList()
        {
            List <DO.Product> DOProduct = (List<DO.Product>)dal.Product.GetAll();
            return from DO.Product item in DOProduct
                   select new BO.ProductForList()
                   {
                       ID = item.ID,
                       Name = item.Name,
                       Category = (Category)item.Category,
                       Price = item.Price,
                   };
        }

        public Product GetProductManeger(int id)
        {
            if (id < 0)
                throw new System.Exception();

            DO.Product product = new DO.Product();
            product = dal.Product.GetByID(id);

            return  new BO.Product(){ 
            ID = product.ID,
            Name=product.Name,
            Category=(BO.Category)product.Category,
            InStock=product.InStock,
            Price=product.Price
            };

        }
        public Product GetProductClient(int id,Cart cart)
        {
            if (id < 0)
                throw new System.Exception();
            DO.Product product = new DO.Product();
            product = dal.Product.GetByID(id);
          //  BO.ProductItem.
        }
        public int Add(Product product)
        {

        }
        public void Update(Product product)
        {

        }
        public int Delete(int id)
        {

        }


    }
}
