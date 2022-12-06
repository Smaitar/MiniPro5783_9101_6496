using BlApi;
using Dal;
using DalApi;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlImplementation
{
    internal class Cart : ICart
    {

        IDal dal = new DalList();
        //Adds a new product
        public BO.Cart AddProduct(BO.Cart cart, int id)
        {
            DO.Product product;
            
            try
            {
                product = dal.Product.GetByID(id);//if the product doesnt exist
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            if (product.InStock < 1)//A correctness check on the instock in case of incorrect data throws an exception
                throw new BO.NagtiveNumberException("not exist in stock");

            int index;
            try
            {
                 index = cart.Items.FindIndex(x => x.ProductID == id);
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            if (index == -1)// the product not exist in the cart now
            {
                if (cart.Items is null)
                    cart.Items = new List<BO.OrderItem>()!;
                BO.OrderItem boOrderItem = new BO.OrderItem();
                boOrderItem.ProductID = id;
                boOrderItem.ProductName = dal.Product.GetByID(id).Name;
                boOrderItem.Price = product.Price;
                boOrderItem.TotalPrice = product.Price;
                boOrderItem.Amount = 1;

                //try to add the order items
                try
                {
                    cart.Items.Add(boOrderItem);
                }
                catch (DO.AlredyExist ex)
                {
                    throw new BO.AlredyExist(ex);
                }

                cart.TotalPrice += product.Price;
                return cart;

            }

            // this product exist and we need to change the amount

            cart.Items[index]!.Amount++;
            cart.Items[index]!.Price += product.Price;
            cart.TotalPrice += product.Price;

            return cart;
        }

        public BO.Cart UpdateCart(BO.Cart cart, int id, int amount)
        {
            //Updating the quantity of a product in the shopping cart for the shopping cart screen
            
            int index;
            try
            {
                index = cart.Items.FindIndex(x => x.ProductID == id);
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            if (cart.Items[index]!.Amount == amount)
                return cart;

            DO.Product product = new DO.Product();
            try { product = dal.Product.GetByID(id); }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }
            
            int amount1;

            if (cart.Items[index]!.Amount < amount)
            {
                amount1 = amount - cart.Items[index]!.Amount;
                cart.Items[index]!.Amount = amount;
                cart.Items[index]!.TotalPrice += amount1 * product.Price;
                cart.Items[index]!.Price += amount1 * product.Price;
                return cart;
            }

            if (amount == 0)
            {
                cart.TotalPrice = cart.TotalPrice - cart.Items[index]!.Price;
                try { cart.Items.RemoveAt(index); }
                catch (DO.NotExist ex)
                {
                    throw new BO.NotExist(ex);
                }
                return cart;
            }

            if (cart.Items[index]!.Amount > amount)
            {
                amount1 = cart.Items[index]!.Amount - amount;
                cart.Items[index]!.Amount = amount;
                cart.Items[index]!.TotalPrice -= amount1 * product.Price;
                cart.Items[index]!.Price -= amount1 * product.Price;
                return cart;
            }

            return cart;
        }


        public bool AprrovedCart(BO.Cart cart)
        {
            //Confirm basket for order \ placing an order for shopping basket screen or order completion screen
            if (cart.Items.Any())
            {
                //A correctness check on the CustomerName and the CustomerAdress and the CustomerEmail in case of incorrect data throws an exception
                if (cart.CustomerName == "")
                    throw new BO.EmptyString("Empty Customer Name");

                if (cart.CustomerAdress == "")
                    throw new BO.EmptyString("Empty Customer Adress");

                if (!GetEmail(cart.CustomerEmail!))
                    throw new BO.EmptyString("Empty Customer Email");

                foreach (BO.OrderItem item in cart.Items)
                {
                    if (item!.Amount < 1)
                        throw new BO.NagtiveNumberException("negative amount in order item");
                    DO.Product product1;
                    try
                    {
                        product1 = dal.Product.GetByID(item.ProductID);//if the product not exist we throw a 
                    }
                    catch (DO.NotExist ex)
                    {
                        throw new BO.NotExist(ex);
                    }

                    if (product1.InStock < item.Amount)
                        throw new BO.NagtiveNumberException("their is not enough amount in stock");
                }

                // If everything was correct we will confirm the basket
                DO.Order order = new DO.Order()
                {
                    CustomerName = cart.CustomerName!,
                    CustomerAdress = cart.CustomerAdress!,
                    CustomerEmail = cart.CustomerEmail!,
                    OrderDate = DateTime.Now,
                    ShipDate = null,
                    DeliveryDate = null
                };


                // add the order
                int orderId = dal.Order.Add(order);

                foreach (BO.OrderItem ?item in cart.Items)
                {
                    try
                    {
                        dal.OrderItem.Add(new DO.OrderItem()
                        {
                            ProductID = item!.ProductID,
                            OrderID = orderId,
                            Price = item.Price,
                            Amount = item.Amount
                        });
                    }
                    catch (DO.AlredyExist ex)
                    {
                        throw new BO.AlredyExist(ex);
                    }

                    dal.OrderItem.Add(new DO.OrderItem()
                    {
                        ProductID = item.ProductID,
                        OrderID = orderId,
                        Price = item.Price,
                        Amount = item.Amount
                    });

                    DO.Product product = dal.Product.GetByID(item.ProductID);
                    product.InStock -= item.Amount;
                    try
                    {
                        dal.Product.Update(product);
                    }
                    catch (DO.NotExist ex)
                    {
                        throw new BO.NotExist(ex);
                    }
                    
                }
                ClearItems(cart);
            }

            return true;
        }

        bool GetEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public void ClearItems(BO.Cart cart) //clear the cart
        {
            cart.Items.Clear();
            cart.TotalPrice = 0;
        }
    }
}
