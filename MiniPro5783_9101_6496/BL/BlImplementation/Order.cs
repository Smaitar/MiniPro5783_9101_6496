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

namespace BlImplementation
{
    internal class Order: BlApi.IOrder
    {
        IDal dal = new DalList();
        public IEnumerable<BO.OrderForList> GetOrderForListsManager()
        {
            IEnumerable<DO.Order> orders = dal.Order.GetAll();

            return from order in orders
                   select OrderInList(order);   
        }  

        public OrderTracking OrderTracking(int orderId)
        {
            DO.Order order = dal.Order.GetByID(orderId);

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
                throw new NagtiveNumberException("michal\n");

            DO.Order order = new DO.Order();
            order = dal.Order.GetByID(id);
         

            return new BO.Order()
            {
                ID = order.ID,

                CustomerName = order.CustomerName,
     
               
            };
    
        }
        public BO.Order GetOrder()
        {
            return null;
        }
        public void Updatae(int OrderID)
        {

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

    
    }
}
