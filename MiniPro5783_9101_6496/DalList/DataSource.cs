

using System;
using System.Collections.Generic;
namespace Dal;

internal class DataSource
{
    public static int readonly=0;
    public const int NumProduct=150;
    public const int NumOrder=100;
    public const int NumOrderItem=200;
    internal public List<Order> order =new List<Order>();
   internal public List<OrderItem>orderitem=new List<OrderItem>();
   internal public List<Product>product=new List<Product>();
   //public override string ToString() =>
    static DataSource()
    {
        s_Initialize();
    }
    private static void s_Initialize();
    {
        s_InitializOrder();
        s_InitializOrderItem();
        s_InitializProduct();
    }
private static void s_InitializOrder()
{
 
      // Array rder = Enum.GetOrder(typeof(Status));
    for(int i=0,i<NumOrder,i++)
    {
        
         = new DalOrder();


    }

    

}

private static void s_InitializOrderItem()
{
    Array OrderItem = Enum.GetOrderItems(typeof(Status));
    DalOrderItem s = new DalOrderItem();
}

private static void s_InitializProduct()
{
    Array Product = Enum.GetProduct(typeof(Status));
    DalProducts = new DalProduct();
}

}
