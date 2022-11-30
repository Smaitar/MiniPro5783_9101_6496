using BlApi;
using Dal;
using DalApi;
using System.ComponentModel.DataAnnotations;

namespace BlImplementation
{
    internal class Cart : ICart
    {

        IDal dal = new DalList();

        public BO.Cart AddProduct(BO.Cart cart, int id)
        {
            DO.Product product;

            try
            {
                product = dal.Product.GetByID(id);//אם מוצר לא קיים תיזרק חריגה
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            if (product.InStock < 1)
                throw new BO.NagtiveNumberException("not exist in stock");

            int index = cart.Items.FindIndex(x => x.ProductID == id);

            if (index == -1)// כרגע לא קיים מוצר כזה בסל
            {
                if (cart.Items is null)
                    cart.Items = new List<BO.OrderItem>();
                BO.OrderItem boOrderItem = new BO.OrderItem();
                boOrderItem.ProductID = id;
                boOrderItem.ProductName = dal.Product.GetByID(id).Name;
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

            return cart;
        }

        public BO.Cart UpdateCart(BO.Cart cart, int id, int amount)
        {
            int index;
            try
            {
                index = cart.Items.FindIndex(x => x.ProductID == id);
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            if (cart.Items[index].Amount == amount)
                return cart;

            DO.Product product = new DO.Product();
            product = dal.Product.GetByID(id);
            int amount1;

            if (cart.Items[index].Amount < amount)
            {
                amount1 = amount - cart.Items[index].Amount;
                cart.Items[index].Amount = amount;
                cart.Items[index].TotalPrice += amount1 * product.Price;
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
            if (cart.Items.Any())
            {
                if (cart.CustomerName == "")
                    throw new BO.EmptyString("Empty Customer Name");

                if (cart.CustomerAdress == "")
                    throw new BO.EmptyString("Empty Customer Adress");

                if (!GetEmail(cart.CustomerEmail))
                    throw new BO.EmptyString("Empty Customer Email");

                foreach (BO.OrderItem item in cart.Items)
                {
                    if (item.Amount < 1)
                        throw new BO.NagtiveNumberException("negative amount in order item");
                    DO.Product product1;
                    try
                    {
                        product1 = dal.Product.GetByID(item.ProductID);//אם מוצר לא קיים תיזרק חריגה
                    }
                    catch (DO.NotExist ex)
                    {
                        throw new BO.NotExist(ex);
                    }

                    if (product1.InStock < item.Amount)
                        throw new BO.NagtiveNumberException("their is not enough amount in stock");
                }

                // אם הכל היה תקין אנחנו נאשר את הסל
                DO.Order order = new DO.Order()
                {
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

                    DO.Product product = dal.Product.GetByID(item.ProductID);
                    product.InStock -= item.Amount;
                    dal.Product.Update(product);
                }
                ClearItems(cart);
            }

            return true;
        }

        bool GetEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public void ClearItems(BO.Cart cart)
        {
            cart.Items.Clear();
            cart.TotalPrice = 0;
        }
    }
}
