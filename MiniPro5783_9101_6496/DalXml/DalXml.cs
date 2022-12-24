using Dal;
using DalApi;

namespace Dal
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