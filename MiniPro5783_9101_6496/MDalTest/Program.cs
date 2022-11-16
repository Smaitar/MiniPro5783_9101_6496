
using Dal;
using DO;
using Microsoft.VisualBasic;
using System;
namespace DalTest;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

internal class Program
{
    //define three kind of objects
    static DalOrder order1 = new DalOrder();
    static DalOrderItem order2 = new DalOrderItem();
    static DalProduct order3 = new DalProduct();

    public static void Main(string[] args)
    {

        Console.WriteLine("To Order press 1");
        Console.WriteLine("To OrderItem press 2");
        Console.WriteLine("To Product press 3");
        Console.WriteLine("To Exit press 0");
        int choice1 = int.Parse(Console.ReadLine());
        switch (choice1)
        {
            case 1:
                OrderOption();
                break;
            case 2:
                OrderItemOption();
                break;
            case 3:
                ProdectOption();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("ERROR");
                break;
        }
    }
    public static void OrderOption()//if the user chose to order
    {
        //the options the user can make
        Console.WriteLine("To Add press a");
        Console.WriteLine("To Print press b");
        Console.WriteLine("To PrintAll press c");
        Console.WriteLine("To update press d");
        Console.WriteLine("To delete press e");
        Console.WriteLine("To exit press f");
        string choice2 = Console.ReadLine();
        while (choice2 != "f")
        {
            try
            {
                switch (choice2)
                {
                    case "a":
                        Order or = new Order();
                        Console.WriteLine("enter ID:");
                        or.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Customer Name:");
                        or.CustomerName = Console.ReadLine();
                        Console.WriteLine("enter Customer Email:");
                        or.CustomerEmail = Console.ReadLine();
                        Console.WriteLine("enter Customer Adress:");
                        or.CustomerAdress = Console.ReadLine();
                        Console.WriteLine("enter Order Date:");
                        or.OrderDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter Ship Date:");
                        or.ShipDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter Delivery Date:");
                        or.DeliveryDate = DateTime.Parse(Console.ReadLine());
                        order1.AddOrder(or);
                        break;
                    case "b":
                        int word;
                        Console.WriteLine("enter ID:");
                        word = int.Parse(Console.ReadLine());
                        Console.WriteLine(order1.GetById(word));
                        break;
                    case "c":
                        foreach (var ob in order1.GetAll())
                            Console.WriteLine(ob);
                        break;
                    case "d":
                        Order orb = new Order();
                        Console.WriteLine("enter ID:");
                        orb.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Customer Name:");
                        orb.CustomerName = Console.ReadLine();
                        Console.WriteLine("enter Customer Email:");
                        orb.CustomerEmail = Console.ReadLine();
                        Console.WriteLine("enter Customer Adress:");
                        orb.CustomerAdress = Console.ReadLine();
                        Console.WriteLine("enter Order Date:");
                        orb.OrderDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter Ship Date:");
                        orb.ShipDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter Delivery Date:");
                        orb.DeliveryDate = DateTime.Parse(Console.ReadLine());
                        order1.UpdateOrder(orb);
                        break;
                    case "e":
                        int ore;
                        Console.WriteLine("enter ID:");
                        ore = int.Parse(Console.ReadLine());
                        order1.DeleteOrder(ore);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("To Add press a");
            Console.WriteLine("To Print press b");
            Console.WriteLine("To PrintAll press c");
            Console.WriteLine("To update press d");
            Console.WriteLine("To delete press e");
            Console.WriteLine("To exit press f");
            choice2 = Console.ReadLine();
        }
    }
    public static void  OrderItemOption()//if the user chose orderItem
    {
        //the options the user can make
        Console.WriteLine("To Add press a");
        Console.WriteLine("To Print press b");
        Console.WriteLine("To PrintAll press c");
        Console.WriteLine("To update press d");
        Console.WriteLine("To delete press e");
        Console.WriteLine("To exit press f");
        string choice2 = Console.ReadLine();
        while (choice2 != "f")
        {
            try
            {
                switch (choice2)
                {
                    case "a":
                        OrderItem or = new OrderItem();
                        Console.WriteLine("enter ID:");
                        or.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Product ID:");
                        or.ProductID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Order ID:");
                        or.OrderID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Price:");
                        or.Price = double.Parse(Console.ReadLine());
                        Console.WriteLine("enter Amount:");
                        or.Amount = int.Parse(Console.ReadLine());
                        order2.AddOrderItem(or);
                        break;
                    case "b":
                        int word;
                        Console.WriteLine("enter ID:");
                        word = int.Parse(Console.ReadLine());
                        Console.WriteLine(order2.GetById(word));
                        break;
                    case "c":
                        foreach (var ob in order2.GetAll())
                            Console.WriteLine(ob);
                        break;
                    case "d":
                        OrderItem orb = new OrderItem();
                        Console.WriteLine("enter ID:");
                        orb.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Product ID:");
                        orb.ProductID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Order ID:");
                        orb.OrderID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Price:");
                        orb.Price = double.Parse(Console.ReadLine());
                        Console.WriteLine("enter Amount:");
                        orb.Amount = int.Parse(Console.ReadLine());
                        order2.UpdateOrder(orb);
                        break;
                    case "e":
                        int ore;
                        Console.WriteLine("enter ID:");
                        ore = int.Parse(Console.ReadLine());
                        order2.DeleteOrderitem(ore);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("To Add press a");
            Console.WriteLine("To Print press b");
            Console.WriteLine("To PrintAll press c");
            Console.WriteLine("To update press d");
            Console.WriteLine("To delete press e");
            Console.WriteLine("To exit press f");
            choice2 = Console.ReadLine();
        }
    }
   public static void ProdectOption()//if the user chose Product
    {
        //the options the user can make
        Console.WriteLine("To Add press a");
        Console.WriteLine("To Print press b");
        Console.WriteLine("To PrintAll press c");
        Console.WriteLine("To update press d");
        Console.WriteLine("To delete press e");
        Console.WriteLine("To exit press f");
        string choice2 = Console.ReadLine();
        while (choice2 != "f")
        {
            //try
            //{
                switch (choice2)
                {
                    case "a":
                        Product pro = new Product();
                        Console.WriteLine("enter ID:");
                        pro.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Name:");
                        pro.Name = Console.ReadLine();
                        Console.WriteLine("enter Category:");
                        int x = int.Parse(Console.ReadLine());
                        pro.Category = (Category)(x);
                        Console.WriteLine("enter InStock:");
                        pro.InStock = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Price:");
                        pro.Price = double.Parse(Console.ReadLine());
                        order3.AddProduct(pro);
                        break;
                    case "b":
                        int word;
                        Console.WriteLine("enter ID:");
                        word = int.Parse(Console.ReadLine());
                        Console.WriteLine(order3.GetById(word));
                        break;
                    case "c":
                        foreach (var ob in order3.GetAll())
                            Console.WriteLine(ob);
                        break;
                    case "d":
                        Product orb = new Product();
                        Console.WriteLine("enter ID:");
                        orb.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Name:");
                        orb.Name = Console.ReadLine();
                        Console.WriteLine("enter Category:");
                        int y = int.Parse(Console.ReadLine());
                        orb.Category = (Category)(y);
                        Console.WriteLine("enter InStock:");
                        orb.InStock = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter Price:");
                        orb.Price = double.Parse(Console.ReadLine());
                        order3.UpdateOrder(orb);
                        break;
                    case "e":
                        int ore;
                        Console.WriteLine("enter ID:");
                        ore = int.Parse(Console.ReadLine());
                        order3.DeleteOrder(ore);
                        break;
                }
        //}
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
            Console.WriteLine("To Add press a");
            Console.WriteLine("To Print press b");
            Console.WriteLine("To PrintAll press c");
            Console.WriteLine("To update press d");
            Console.WriteLine("To delete press e");
            Console.WriteLine("To exit press f");
            choice2 = Console.ReadLine();
        }

    }

}
