using BlApi;
using BO;
using Dal;
using DalApi;
using DO;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using Unipluss.Sign.Common.Rest.URLs;
//using MDalFacade.DalApi;

namespace BlImplementation
{
    internal class Product : BlApi.IProduct
    {
        //We created a data layer variable that we will use for all functions
        IDal dal = new DalList();

        public IEnumerable<BO.ProductForList> GetList()
        {
            //we created a collection to return if for an admin screen and for a buyer's catalog screen
            IEnumerable<DO.Product> DOProduct = dal.Product.GetAll();

            //Update the data from DO to new IEnumerable in BO and return it
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
            //Returns strange information for admin screen
            if (id < 0)
                throw new System.Exception();

            // We try to get the value from the data layer and if not we throw an exception
            DO.Product product;
                        try
            {
                product = dal.Product.GetByID(id);
            }
            catch(DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            // Returns the product details according to the ID received
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
            //Returns product details for a buyer screen - from the catalog
            if (id < 0)
                throw new System.Exception();
            DO.Product product;// We try to get the value from the data layer and if not we throw an exception
            try
            {
                product = dal.Product.GetByID(id);
            }
            catch(BO.NotExist ex)   
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
                InStock = product.InStock,
                Amount=cart.Items.Count,//update the amount of the items in the cart
            };
            return item;
        }

        public void Add(BO.Product product)
        {
            //add new product into data layer
            // Correctness check for identity number, name, and email,and price
                        if (product.ID < 0) 
                    throw new NagtiveNumberException("negative number of id");
                if(product.Name == "")
                    throw new EmptyString("empty name");
                if (   product.InStock < 1)
                    throw new NagtiveNumberException("negative number of amount in stock");
                if (product.Price < 0)
                    throw new NagtiveNumberException("negative number of price");
                DO.Product product1 = new DO.Product()//creat a new product from data layer
                {
                    ID = product.ID,
                    Name = product.Name,
                    InStock = product.InStock,
                    Price = product.Price,
                    Category = (DO.Category)product.Category,

                };
                dal.Product.Add(product1);
                // After we have created an item and put appropriate values ​​in it, add the product


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

        //delete product from the list
        public void Delete(int id)
        {
            List<DO.OrderItem> OIDal = (List<DO.OrderItem>)dal.OrderItem.GetAll();
            foreach (DO.OrderItem o in OIDal)//search the object in the list which have the same id
                if (o.ProductID == id)
                    throw new BO.AlredyExist("cant delete the product is already exists");
            dal.Product.Delete(id);
            //the delete will be from the data layer

        }


    }

  
}
