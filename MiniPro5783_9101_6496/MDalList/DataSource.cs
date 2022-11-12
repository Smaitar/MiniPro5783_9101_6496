
using DO;
using System;
using System.Collections.Generic;

namespace MDalList;

internal class DataSource
{
    internal static readonly Random random = new Random();

    internal const int NumProduct = 10;
    private const int NumOrder = 100;
    private const int NumOrderItem = 200;
    internal static List<OrderItem> orderitems = new List<OrderItem>();
    internal static List<Product> products = new List<Product>();
    internal static List<Order> Orders  = new List<Order>();


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

    //private static void s_InitializProduct()
    //{
    //    throw new NotImplementedException();
    //}

    //private static void s_InitializOrderItem()
    //{
    //    throw new NotImplementedException();
    //}

    //private static void s_InitializOrder()
    //{
    //    throw new NotImplementedException();
    //}
}
private static void InitializOrder()
{
    Array Category = Enum.GetValues(typeof(Category));

    for (int i = 0; i<NumOrder ; i++)
    {
        nameof
    }

}

private static void s_InitializOrderItem()
{
    //Array OrderItem = Enum.GetOrderItems(typeof(Status));
    //DalOrderItem s = new DalOrderItem();
}

private static void s_InitializProduct()
{
    Array Category = Enum.GetValues(typeof(Category));
    for (int i = 0; i < NumProduct; i++)
    {

    }
}

}
