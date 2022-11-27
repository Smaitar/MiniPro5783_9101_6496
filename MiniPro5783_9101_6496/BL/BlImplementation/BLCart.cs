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
    internal class BLCart:IBOCart
    {
        
        IDal dal = new DalList();
        public Cart AddProduct(Cart cart, int id)
        {
            int index = cart.Items.FindIndex(x => x.ProductID == id);

            DO.Product product = new DO.Product();

            product = dal.Product.GetByID(id);//אם מוצר לא קיים תיזרק חריגה

            if (product.InStock < 1)
                throw new System.Exception();

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

        public Cart UpdateCart(Cart cart, int id, int amount)
        {
            int index = cart.Items.FindIndex(x => x.ProductID == id);
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


        public bool AprrovedCart(Cart cart)
        {
            foreach (BO.OrderItem item in cart.Items)
                if (item.Amount < 1 || dal.Product.GetByID(item.ProductID).InStock < item.Amount)
                    throw new System.Exception();

            if(cart.CustomerName=="" || cart.CustomerAdress==""|| GetEmail(cart.CustomerEmail))
                throw new System.Exception();

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

            //for(int i = 1; i < email.Length; i++)
            //{
            //    if (email[i] == '@')
            //    {
            //        email = email.Substring(i, email.Length);
            //        if (email == "gmail.com" ||email == "acad.jct.ac.il")
            //            return true;
            //    }
            //}
            //return false;
        }
    }
}
