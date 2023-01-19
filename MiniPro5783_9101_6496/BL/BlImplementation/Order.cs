using BO;
using Dal;
using DalApi;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection.Emit;

namespace BlImplementation
{
    internal class Order : BlApi.IOrder
    {
        //We created a data layer variable that we will use for all functions
        DalApi.IDal? dal = DalApi.Factory.Get();
        public IEnumerable<BO.OrderForList?> GetOrderForListsManager()
        {
            //Returns the list of orders for an admin screen
            IEnumerable <DO.Order?> orders = dal.Order.GetAll();

            return from DO.Order item in orders
                   select new BO.OrderForList()
                   {
                       ID = item.ID,
                       CustomerName = item.CustomerName,
                       AmountOfItem = dal.OrderItem.GetAll().Where(x => x?.OrderID == item.ID).Count(),
                       status = GetStatus(item),
                       TotalPrice = dal.OrderItem.GetAll().Where(x => x?.OrderID == item.ID).Sum(x => x?.Amount * x?.Price  ?? 0)
                   };
        }

        private OrderStatus GetStatus(DO.Order order)
        {
            return order.DeliveryDate != null ? OrderStatus.Supplied : order.ShipDate != null ? OrderStatus.Sent : OrderStatus.Confirmation;
        }

        public OrderTracking OrderTracking(int orderId)
        {
            //Order Status Tracking for Admin Order Management Screen
            DO.Order order;

            // We try to get the value from the data layer and if not we throw an exception
            try
            {
                order = dal.Order.GetByID(orderId);
            }
            catch (DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            //return the position-status of the order
            return new OrderTracking
            {
                ID = order.ID,
                Status = getStatus(order),
                OrderTrackings = new List<(DateTime?, OrderStatus)>
                {
                    (order.OrderDate, OrderStatus.Confirmation),
                    (order.ShipDate, OrderStatus.Sent),
                    (order.DeliveryDate, OrderStatus.Supplied),
                }
            };
        }

        public BO.Order OrderDetails(int id)//Returns the order details for admin screen and buyer screen
        {
            //A correctness check on the identity number and if it incorrect data throws an exception
            if (id < 0)
                throw new NagtiveNumberException("negative number of id");

            //Returns the order from the data layer with the appropriate ID number
            DO.Order order;
            try
            {
                order = dal.Order.GetByID(id);

            }
            catch (DO.NotExist ex)//If an error occurred while returning the order from the data layer
            {
                throw new BO.NotExist(ex);
            }

            IEnumerable<DO.OrderItem?> orderItems = dal.OrderItem.GetAll().Where(orderItem => orderItem?.OrderID  == id );
            BO.Order boOrder = new BO.Order()
            {
                ID = order.ID,

                CustomerName = order.CustomerName,
                DeliveryDate = order.DeliveryDate!.Value,
                OrderDate = order.OrderDate!.Value,
                CustomerAdress = order.CustomerAdress,
                ShipDate = order.ShipDate!.Value,
                PaymentDate = order.OrderDate.Value,
                CustomerEmail = order.CustomerEmail,
                Status = getStatus(order),
                Items = orderItems.Select(orderItem => new BO.OrderItem
                {
                    ID= dal.OrderItem.GetByID(orderItem?.ProductID ?? 0).ID,
                    ProductName = dal.Product.GetByID(orderItem?.ProductID ?? 0).Name,
                    Amount = orderItem?.Amount ?? 0,
                    Price = orderItem?.Price ?? 0,
                    ProductID = orderItem?.ProductID ?? 0,
                    TotalPrice = orderItem?.Price * orderItem?.Amount ?? 0,
                }).ToList()!
            };
            boOrder.TotalPrice = boOrder.Items.Sum(item => item.TotalPrice);
            return boOrder;
            
        }

        public BO.OrderForList OrderInList(DO.Order order)
        {
            BO.OrderForList orderForList = new BO.OrderForList();
            orderForList.ID = order.ID;
            orderForList.CustomerName = order.CustomerName;
            orderForList.status = getStatus(order);
            return orderForList;

        }

        private BO.OrderStatus getStatus(DO.Order order)
        {
            //check the current status of the order and return it 
            return order.DeliveryDate != DateTime.MinValue ? OrderStatus.Supplied : order.ShipDate
                != DateTime.MinValue ? OrderStatus.Sent : OrderStatus.Confirmation;
        }

        public BO.Order UpdateSentOrder(int orderId)
        {
            //Order Shipping Update Admin Order Management Screen
            try
            {
                DO.Order order = dal.Order.GetByID(orderId);

                order.ShipDate = DateTime.Now;
                dal.Order.Update(order);

                return OrderDetails(orderId);
            }
            catch (DO.NotExist ex)
            {

                throw new BO.NotExist(ex);
            }
        }

        public BO.Order UpdateSuppliedOrder(int orderId)
        {
            //Order Delivery Update Admin Order Management screen
            try
            {
                //Update the details
                DO.Order order = dal.Order.GetByID(orderId);
                order.DeliveryDate = DateTime.Now;
                dal.Order.Update(order);

                return OrderDetails(orderId);
            }
            catch (DO.NotExist ex)
            {

                throw new BO.NotExist(ex);
            }
        }

    }
}
