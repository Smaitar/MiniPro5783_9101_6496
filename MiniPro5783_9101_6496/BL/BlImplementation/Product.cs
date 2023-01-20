using BlApi;
using BO;
using Dal;
using DalApi;
using System.Reflection.Emit;
using System.Security.Principal;
//using MDalFacade.DalApi;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        //We created a data layer variable that we will use for all functions
        DalApi.IDal? dal = DalApi.Factory.Get();

        public IEnumerable<BO.ProductForList> GetList(Func<ProductForList, bool> func = null)
        {
            IEnumerable<DO.Product?> DOProduct = dal.Product.GetAll();
          
            
                //we created a collection to return if for an admin screen and for a buyer's catalog screen
                //Update the data from DO to new IEnumerable in BO and return it
                IEnumerable<BO.ProductForList> dList = from DO.Product item in DOProduct
                                                       select new BO.ProductForList()
                                                       {
                                                           ID = item.ID,
                                                           Name = item.Name,
                                                           Category = (BO.Category)item.Category,
                                                           Price = item.Price,
                                                       };
                return func is null ? dList : dList.Where(func);
            
        }

        public IEnumerable<BO.ProductItem> GetListToClient(BO.Cart NewCart)
        {
            IEnumerable<DO.Product?> DOProduct = dal.Product.GetAll();
            IEnumerable<BO.ProductItem> productItems = from item in DOProduct
                                                       select new BO.ProductItem()
                                                       {
                                                           ID = item?.ID ?? 0,
                                                           Name = item?.Name,
                                                           Category = (BO.Category)item?.Category,
                                                           Price = item?.Price ?? 0,
                                                           InStock = item?.InStock > 0 ? true : false,
                                                           Amount = (from orderItem in NewCart.Items
                                                                     where orderItem.ID == item?.ID
                                                                     select orderItem.Amount).FirstOrDefault(0) //אם עושה שגיאת ריצה להפוך את זה ללינקיו
                                                       };
            return productItems;
        }

        public BO.Product GetProductManeger(int id)
        {
            //Returns strange information for admin screen
            if (id < 0)
                throw new NagtiveNumberException("negative number of id");

            // We try to get the value from the data layer and if not we throw an exception
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
                Price = product.Price,
            };

        }

        public ProductItem GetProductClient(int id, BO.Cart cart)
        {
            //Returns product details for a buyer screen - from the catalog
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

            // Returns the product details according to the ID and cart received
            BO.ProductItem item = new BO.ProductItem()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Category)product.Category,
                InStock =product.InStock > 0 ? true : false,
                Amount = cart.Items.Count,
            };
            return item;
        }

        public void Add(BO.Product product)//Adds a new product
        {
            //A correctness check on the name and the identity number and the email in case of incorrect data throws an exception
            if (product.ID < 0)
                throw new NagtiveNumberException("negative number of id");
            if (product.Name == "")
                throw new EmptyStringName("empty name");
            if (product.InStock < 1)
                throw new NagtiveNumberException("negative number of amount in stock");
            if (product.Price < 0)
                throw new NagtiveNumberException("negative number of price");
            //If the entered data is correct, create a product from the data layer and transfer all the details into it, then add to the products
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
        //Updates product amount for shopping cart screen
        public void Update(BO.Product product)
        {
            //A correctness check on the name and the identity number and the stock and price in case of incorrect data throws an exception
            if (product.ID < 0)
                throw new NagtiveNumberException("Nagtive Number Of ID");
            if (product.Name == "")
                throw new EmptyStringName(" Empty Name");
            if (product.InStock < 1)
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

        //delete product from the list
        public void Delete(int id)
        {
            List<DO.OrderItem> OIDal = (List<DO.OrderItem>)dal.OrderItem.GetAll();
            foreach (DO.OrderItem o in OIDal)//search the object in the list which have the same id
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
        public BO.Product GetById(int id)
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
            BO.Product item = new BO.Product()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Category)product.Category,
                InStock = product.InStock,
            };
            return item;

        }

    }


}
