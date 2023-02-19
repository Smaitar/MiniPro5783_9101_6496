using BO;

namespace BlApi
{
    public interface IOrder
    {
        IEnumerable<OrderForList?> GetOrderForListsManager();
        OrderTracking OrderTracking(int orderId);
        Order OrderDetails(int ID);
        Order UpdateSuppliedOrder(int orderId);
        Order UpdateSentOrder(int orderId);
        Order GetTheOldOne();
    }
}
