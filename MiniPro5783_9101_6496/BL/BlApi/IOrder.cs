using BO;

namespace BlApi
{
    public interface IOrder
    {
        IEnumerable<OrderForList> GetOrderForListsManager();
        OrderTracking OrderTracking(int orderId);
        Order OrderDetails(int ID);
        Order GetOrder();
        void Updatae(int OrderID);
    }
}
