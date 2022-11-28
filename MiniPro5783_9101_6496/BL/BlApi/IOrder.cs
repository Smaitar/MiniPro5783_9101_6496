using BO;

namespace BlApi
{
    public interface IOrder
    {
        IEnumerable<OrderForList> GetOrderForListsManager();
        OrderTracking OrderTracking(int orderId);
        Order OrderDetails(int ID);
        Order GetOrder();
        void Update(int OrderID);
        bool GetByID(int word);
        IEnumerable<Order> GetAll();
        void Update(Order orb);
        void Delete(int ore);
    }
}
