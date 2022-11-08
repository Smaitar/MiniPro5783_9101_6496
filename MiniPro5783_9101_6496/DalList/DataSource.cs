using System;
using System.Collections.Generic;

namespace Dal;

internal class DalSource
{
    public static int readonly=0 ;
    internal public List<Order>=new List<Order>();
   internal public List<OrderItem>=new List<OrderItem>();
   internal public List<Product>=new List<Product>();
   //public override string ToString() =>
    static DalSource()
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
    Array order = Enum.GetValues(typeof(Status));
}

private static void s_InitializOrderItem();

private static void s_InitializProduct();

}
