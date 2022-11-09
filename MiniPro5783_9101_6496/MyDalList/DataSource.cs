
using DO;
using System;
using System.Collections.Generic;
namespace Dal;

internal class DataSource
{
    //public int readonly ran=0;
    public const int NumProduct = 150;
    public const int NumOrder = 100;
    public const int NumOrderItem = 200;
    internal List<Order> orders = new List<Order>();
    internal List<OrderItem> orderitems = new List<OrderItem>();
    internal List<Product> products = new List<Product>();
    //public override string ToString() =>
    static DataSource()
    {
        s_Initialize();
    }
    private static void s_Initialize()
    {
        s_InitializOrder();
        s_InitializOrderItem();
        s_InitializProduct();
}
private static void s_InitializOrder()
{
    //public Order o = new Order();
    //// Array rder = Enum.GetOrder(typeof(Status));
    //for (int i = 0, i< NumOrder, i++)
    //{
        
    //}
}

private static void s_InitializOrderItem()
{
    //Array OrderItem = Enum.GetOrderItems(typeof(Status));
    //DalOrderItem s = new DalOrderItem();
}

private static void s_InitializProduct()
{
    //Array Product = Enum.GetProduct(typeof(Status));
}

}
