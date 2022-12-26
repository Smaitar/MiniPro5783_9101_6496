
using DalXml;
using DO;
using System.Data.SqlTypes;

namespace Dal;

internal class DataSource
{

    static DataSource()
    {
        s_Initialize();
    }
    private static DalApi.IDal dalXml = new DalXml.DalXml();

    internal static class Config
    {
        //a run number 
        internal static int orderitemID = 1000000;
        internal static int productID = 1000000;
        internal static int orderID = 1000000;
        public static int ProductID => productID++;
        public static int OrderitemID => orderitemID++;
        public static int OrderID => orderID++;
    }
    private static string[] arrNames = new string[5] { "moshe", "shira", "neta", "haim", "michal" };
    private static string[] arrFamilys = new string[5] { "bnei brak", "tel aviv", "ramat gan", "givhat shmuel", "beit shemesh" };
    internal static readonly Random random = new();

    internal const int NumProduct = 15;
    private const int NumOrder = 50;
    private const int NumOrderItem = 100;
    internal static List<OrderItem?> orderitemsList = new List<OrderItem?>();
    internal static List<Product?> ProductsList = new List<Product?>();
    public static List<Order?> OrdersList = new List<Order?>();

    private static void s_Initialize()
    {
        s_InitializOrder();
        s_InitializProduct();
        s_InitializOrderItem();
      
       
    }
    private static void s_InitializOrder()
    {
        Array values = Enum.GetValues(typeof(Category));

        for (int i = 0; i < NumOrder; i++)
        {
            Order order = new Order();
            {
                order.ID = Config.OrderID;
                order.CustomerName = arrNames[random.Next(5)];
                order.CustomerEmail = arrNames[random.Next(5)] + "@gmail.com";
                order.CustomerAdress = arrFamilys[random.Next(5)];
                order.OrderDate = DateTime.Now;
                order.ShipDate = DateTime.Now;
                order.DeliveryDate = DateTime.Now;
            }
            OrdersList.Add(order);
        }

        foreach (Order item in OrdersList)
            dalXml.Order.Add(item);
    }

    private static void s_InitializOrderItem()
    {

        for (int i = 0; i < NumOrder; i++)
        {
            OrderItem orderitem = new OrderItem();
            Product? product = ProductsList[random.Next(ProductsList.Count)];

            orderitem.ID = random.Next(100000000, 999999999);
            orderitem.ProductID = product?.ID ?? 0;
            if (i < 50)
                orderitem.OrderID = OrdersList[i]?.ID ?? 0;
            else
                orderitem.OrderID = OrdersList[random.Next(OrdersList.Count)]?.ID ?? 0;
            orderitem.Price = product?.Price ?? 0;
            orderitem.Amount = random.Next(1, 10);
            orderitemsList.Add(orderitem);
        }
        foreach (OrderItem item in orderitemsList)
            dalXml.OrderItem.Add(item);
    }

    private static void s_InitializProduct()
    {
        Array values = Enum.GetValues(typeof(Category));
        for (int i = 0; i < NumProduct; i++)
        {
            Product stu = new Product();
            {
                stu.ID = random.Next(100000, 1000000);
                stu.Name = "product" + i;
                stu.Category = (Category)values.GetValue(random.Next(values.Length));
                stu.InStock = random.Next(100, 200);
                stu.Price = 100;
            }
            ProductsList.Add(stu);
        }

        foreach (Product item in ProductsList)
            dalXml.Product.Add(item);
    }
}