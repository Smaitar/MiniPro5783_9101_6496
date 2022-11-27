using BlApi;
using BO;
using Dal;
using DalApi;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
                       Category = (Category)item.Category,
                       Price = item.Price,
                   };
        }

        public BO.Product GetProductManeger(int id)
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
        public ProductItem GetProductClient(int id, BO.Cart cart)
        {
            if (id < 0)
                throw new System.Exception();
            DO.Product product = new DO.Product();
            product = dal.Product.GetByID(id);
            BO.ProductItem item = new BO.ProductItem()
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Category)product.Category,
                InStock = product.InStock,
                Amount=cart.Items.Count,    
            };
            return item;
        }
        public void Add(BO.Product product)
        {
            try
            {
                if (product.ID < 0 || product.Name == "" || product.InStock < 1 || product.Price < 0)
                    throw new NagtiveNumberException();

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
            catch ()
            {

                throw;
            }
        }
        public void Update(BO.Product product)
        {
            if (product.ID < 0 || product.Name == "" || product.InStock < 1 || product.Price < 0)
                throw new System.Exception();
            DO.Product product1 = new DO.Product()
            {
                ID = product.ID,
                Name = product.Name,
                InStock = product.InStock,
                Price = product.Price,
                Category = (DO.Category)product.Category,

            };
            dal.Product.Update(product1);
        }
        public void Delete(int id)
        {
            List<DO.OrderItem> OIDal = (List<DO.OrderItem>)dal.OrderItem.GetAll();
            foreach (DO.OrderItem o in OIDal)
                if (o.ProductID == id)
                    throw new System. Exception();
            dal.Product.Delete(id);

        }


    }

  
}
