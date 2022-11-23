using BO;

namespace BlApi
{
    public interface IBOOrder
    {
        public IEnumerable<BO.OrderForList> GetOrderForListsManager();
        public IEnumerable<BO.OrderTracking> orderTrackings();
        public Order OrderDetails(int ID);
        public Order GetOrder();
        public void Updatae(int OrderID);
        
    }
}
