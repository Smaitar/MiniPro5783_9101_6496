using AutoMapper.QueryableExtensions.Impl;
using BlApi;
using BO;
using Dal;
using DalApi;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Transactions;

namespace BlImplementation
{
    internal class Cart:ICart
    {
       
        IDal dal = new DalList();

        public BO.Cart AddProduct(BO.Cart cart, int id)
        {
            int index = cart.Items.FindIndex(x => x.ProductID == id);

            DO.Product product = new DO.Product();

            try
            {
                product = dal.Product.GetByID(id);//אם מוצר לא קיים תיזרק חריגה
            }
            catch (DalApi.ex)
            {
                throw ;
            }

            if (product.InStock < 1)
                throw new  NagtiveNumberException("not exist in stock");

            DO.OrderItem dalOrderItem = new DO.OrderItem();
            List<DO.OrderItem> OIDal = dal.OrderItem.GetAll().ToList();

            if (index!= -1) // כרגע לא קיים מוצר כזה בסל
            {
                BO.OrderItem boOrderItem = new BO.OrderItem();
                boOrderItem.ProductID = id;
                boOrderItem.OrderID = cart.Items[0].OrderID;
                boOrderItem.Price = product.Price;
                boOrderItem.TotalPrice = product.Price;
                boOrderItem.Amount = 1;
                cart.Items.Add(boOrderItem);
                cart.TotalPrice += product.Price;// סיום  חישובים לוגים
                return cart;
            }
            // קיים מוצר כזה בסל וצריך לעדכן את הכמות

            cart.Items[index].Amount++;
            cart.Items[index].Price += product.Price;
            cart.TotalPrice += product.Price;

            dalOrderItem = OIDal.Find(x => x.OrderID == cart.Items[0].OrderID && x.ProductID == id);
            dalOrderItem.Amount++;

            return cart;
        }

        public BO.Cart UpdateCart(BO.Cart cart, int id, int amount)
        {
            int index = cart.Items.FindIndex(x => x.ProductID == id);
                throw new Exception
            if (cart.Items[index].Amount == amount)
                return cart;

            DO.Product product = new DO.Product();
            product = dal.Product.GetByID(id);
            int amount1;

            if (cart.Items[index].Amount < amount)
            {
                amount1 = amount-cart.Items[index].Amount;
                cart.Items[index].Amount = amount;
                cart.Items[index].TotalPrice+= amount1*product.Price;
                cart.Items[index].Price += amount1 * product.Price;
                return cart;
            }

            if (amount == 0)
            {
                cart.TotalPrice = cart.TotalPrice - cart.Items[index].Price;
                cart.Items.RemoveAt(index);
                return cart;
            }

            if (cart.Items[index].Amount > amount)
            {
                amount1 = cart.Items[index].Amount - amount;
                cart.Items[index].Amount = amount;
                cart.Items[index].TotalPrice -= amount1 * product.Price;
                cart.Items[index].Price -= amount1 * product.Price;
                return cart;
            }

            return cart;
        }


        public bool AprrovedCart(BO.Cart cart)
        {
            foreach (BO.OrderItem item in cart.Items) 
            {
                if (item.Amount < 1)
                    throw new NagtiveNumberException("negative amount in order item");

                if (dal.Product.GetByID(item.ProductID).InStock < item.Amount)
                    throw new NagtiveNumberException("their is not enough amount in stock");

                if (cart.CustomerName == "")
                     throw new EmptyString("Empty Customer Name");

                if (cart.CustomerAdress == "")
                    throw new EmptyString("Empty Customer Adress");

                if (GetEmail(cart.CustomerEmail))
                    throw new EmptyString("Empty Customer Email");
            try
            {
                if (cart.CustomerName == "" || cart.CustomerAdress == "" || GetEmail(cart.CustomerEmail))
                    throw new System.Exception();
              
            }
            catch(Exception ex)
            {

            }
            }

                    // אם הכל היה תקין אנחנו נאשר את הסל
                    DO.Order order = new DO.Order() {
                CustomerName = cart.CustomerName,
                CustomerAdress = cart.CustomerAdress,
                CustomerEmail = cart.CustomerEmail,
                OrderDate = DateTime.Now,
                ShipDate = null,
                DeliveryDate = null
            };
            
            int orderId = dal.Order.Add(order);   

            foreach (BO.OrderItem item in cart.Items)
            {
                dal.OrderItem.Add(new DO.OrderItem()
                {
                    ProductID = item.ProductID,
                    OrderID = orderId, 
                    Price = item.Price,
                    Amount = item.Amount
                });

                DO.Product product  = dal.Product.GetByID(item.ProductID);
                product.InStock -= item.Amount;
                dal.Product.Update(product);
            }

            return true;
        }

        bool GetEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
