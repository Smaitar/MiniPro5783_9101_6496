using Dal;
using DalApi;

namespace DalXml
{
    public class DalXml :IDal
    {
        public DalXml() { }
        public static IDal Instance { get; } = new DalXml();

        public IProduct Product { get; } = new dalProduct();
        public IOrder Order { get; } = new dalOrder();
        public IOrderItem OrderItem { get; } = new dalOrderItem();

    }
}