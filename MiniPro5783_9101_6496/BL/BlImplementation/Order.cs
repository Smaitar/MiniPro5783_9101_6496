using BlApi;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using BO;
using System.Data;
using DO;

namespace BlImplementation
{
    internal class Order: BlApi.IOrder
    {
        //We created a data layer variable that we will use for all functions
        IDal dal = new DalList();
        public IEnumerable<BO.OrderForList> GetOrderForListsManager()
        {
            //Returns the list of orders for an admin screen
            IEnumerable <DO.Order> orders = dal.Order.GetAll();

            return from DO.Product item in orders
                   select new BO.OrderForList()
                   {
                       ID = item.ID,
                       CustomerName=item.Name,
                       AmountOfItem=item.InStock,
                       status=item.
            
                   };
        }  

        public OrderTracking OrderTracking(int orderId)
        {
            //Order Status Tracking for Admin Order Management Screen
            DO.Order order;

            // We try to get the value from the data layer and if not we throw an exception
            try
            {
                order= dal.Order.GetByID(orderId);
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

        public BO.Order OrderDetails(int id)
        {
            if (id < 0)
                throw new NagtiveNumberException("negative number of id");

            DO.Order order;
            try
            {
                order = dal.Order.GetByID(id);
            }
            catch(DO.NotExist ex)
            {
                throw new BO.NotExist(ex);
            }

            return new BO.Order()
            {
                ID = order.ID,

                CustomerName = order.CustomerName,
     
               
            };
    
        }
       
        public BO.OrderForList OrderInList(DO.Order order)
        {
            BO.OrderForList orderForList = new BO.OrderForList();   
            orderForList.ID = order.ID;
            orderForList.CustomerName=order.CustomerName;
            orderForList.status = getStatus(order);
            return orderForList; 

        }

        private BO.OrderStatus getStatus(DO.Order order)
        {
            return order.DeliveryDate != DateTime.MinValue ? OrderStatus.Supplied : order.ShipDate
                != DateTime.MinValue ? OrderStatus.Sent : OrderStatus.Confirmation;
        }

        public BO.Order UpdateSentOrder(int orderId)
        {
            try
            {
                DO.Order order = dal.Order.GetByID(orderId);

                order.ShipDate = DateTime.Now;
                dal.Order.Update(order);

                return OrderDetails(orderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BO.Order UpdateSuppliedOrder(int orderId)
        {
            try
            {
                DO.Order order = dal.Order.GetByID(orderId);

                order.DeliveryDate = DateTime.Now;
                dal.Order.Update(order);

                return OrderDetails(orderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
