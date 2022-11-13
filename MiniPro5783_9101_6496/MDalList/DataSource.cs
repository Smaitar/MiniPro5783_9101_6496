
using DO;
namespace Dal;

internal class DataSource
{

    static DataSource()
    {
        s_Initialize();
    }

    internal static class Config
    {

        internal static int orderitemID = 0;
        internal static int productID = 0;

        public static int ProductID => productID++;
        public static int OrderitemID => orderitemID++;
    }

    internal static readonly Random random = new();

    internal const int NumProduct = 10;
    private const int NumOrder = 100;
    private const int NumOrderItem = 40;
    internal static List<OrderItem> orderitemsList = new List<OrderItem>();
    internal static List<Product> ProductsList = new List<Product>();
    internal static List<Order> OrdersList = new List<Order>();

    private static void s_Initialize()
    {
            s_InitializOrder();
            s_InitializOrderItem();
            s_InitializProduct();
    }
    private static void s_InitializOrder()
    {
        Array values = Enum.GetValues(typeof(Category));

        for (int i = 0; i < NumOrder; i++)
        {
            Order order = new Order();
            {
                order.ID = i;
                order.CustomerName = Nullable;
                order.CustomerEmail = Nullable;
                order.CustomerAdress = Nullable;
                order.OrderDate = DateTime.Now;
                order.ShipDate = DateTime.Now;
                order.DeliveryDate = DateTime.Now;
            }
            OrdersList.Add(order);
        }

    }

    private static void s_InitializOrderItem()
    {
        for(int i = 0; i < NumOrder; i++)
        {
            OrderItem orderitem = new OrderItem();
            {
                orderitem.ID= random.Next(100000000, 999999999);
                orderitem.ProductID = Config.ProductID;
                orderitem.OrderID= Config.OrderitemID;
                orderitem.Price = 100;
                orderitem.Amount = random.Next(200);
            }
            orderitemsList.Add(orderitem);
        }
    }

    private static void s_InitializProduct()
    {
        Array values = Enum.GetValues(typeof(Category));
        for (int i = 0; i < NumProduct; i++)
        {
            Product stu = new Product();
            {
                stu.ID = random.Next(100000000, 999999999);
                stu.Name ="product"+i;
                stu.Category = (Category)values.GetValue(random.Next(4));
                stu.InStock = (InStock)Category.GetValue(random.Next(0, 50);
                stu.Price = 100;
            }
            ProductsList.Add(stu);
        }
    }
}