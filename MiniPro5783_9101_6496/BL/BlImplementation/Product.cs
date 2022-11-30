using BO;
using Dal;
using DalApi;
//using MDalFacade.DalApi;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        IDal dal = new DalList();

        public IEnumerable<BO.ProductForList> GetList()
        {
            IEnumerable<DO.Product> DOProduct = dal.Product.GetAll();

            return from DO.Product item in DOProduct
                   select new BO.ProductForList()
                   {
                       ID = item.ID,
                       Name = item.Name,
                       Category = (BO.Category)item.Category,
                       Price = item.Price,
                   };
        }

        public BO.Product GetProductManeger(int id)
        {
            if (id < 0)
                throw new NagtiveNumberException("negative number of id");

            DO.Product product;
            try
            {
                product = dal.Product.GetByID(id);
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }


            return new BO.Product()
            {
                ID = product.ID,
                Name = product.Name,
                Category = (BO.Category)product.Category,
                InStock = product.InStock,
                Price = product.Price
            };

        }

        public ProductItem GetProductClient(int id, BO.Cart cart)
        {
            if (id < 0)
                throw new NagtiveNumberException("negative number of id");
            DO.Product product;
            try
            {
                product = dal.Product.GetByID(id);
            }
            catch (BO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }
            BO.ProductItem item = new BO.ProductItem()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Category)product.Category,
                InStock = product.InStock,
                Amount = cart.Items.Count,
            };
            return item;
        }

        public void Add(BO.Product product)
        {

            if (product.ID < 0)
                throw new NagtiveNumberException("negative number of id");
            if (product.Name == "")
                throw new EmptyString("empty name");
            if (product.InStock < 1)
                throw new NagtiveNumberException("negative number of amount in stock");
            if (product.Price < 0)
                throw new NagtiveNumberException("negative number of price");
            DO.Product product1 = new DO.Product()
            {
                ID = product.ID,
                Name = product.Name,
                InStock = product.InStock,
                Price = product.Price,
                Category = (DO.Category)product.Category,

            };
            dal.Product.Add(product1);


        }

        public void Update(BO.Product product)
        {
            if (product.ID < 0 )
                throw new NagtiveNumberException("Nagtive Number Of ID");
            if (product.Name == "")
                throw new EmptyString(" Empty Name");
            if(product.InStock < 1)
                throw new NagtiveNumberException("Nagtive Number Of Amount In Stock");
            if (product.Price < 0)
                throw new NagtiveNumberException("Nagtive Number Of Price");
            DO.Product product1 = new DO.Product()
            {
                ID = product.ID,
                Name = product.Name,
                InStock = product.InStock,
                Price = product.Price,
                Category = (DO.Category)product.Category,

            };
            try
            {
                dal.Product.Update(product1);
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }
        }

        public void Delete(int id)
        {
            List<DO.OrderItem> OIDal = (List<DO.OrderItem>)dal.OrderItem.GetAll();
            foreach (DO.OrderItem o in OIDal)
                if (o.ProductID == id)
                    throw new BO.AlredyExist("cant delete the product is already exists");
            try
            {
                dal.Product.Delete(id);
            }
            catch (DO.AlredyExist ex)    
            {
                throw new BO.AlredyExist(ex);
            }
        }


    }


}
