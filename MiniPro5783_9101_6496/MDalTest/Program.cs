using Dal;
using DO;
using Microsoft.VisualBasic;
using System;
namespace DalTest;

class Program
{
    private static DalOrder order1 = new DalOrder();
    private static DalOrderItem order2 = new DalOrderItem();
    private static DalProduct order3 = new DalProduct();
    
    static void Main(string[]args)
    {
        Console.WriteLine("To Order press 1");
        Console.WriteLine("To OrderItem press 2");
        Console.WriteLine("To Product press 3");
        Console.WriteLine("To Exit press 0");
        int choice1 = int.Parse( Console.ReadLine());
        switch(choice1)
        {
        case 1:
            OrderOption();
        break;
        case 2:
            OrderOItemption();
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
    void OrderOption()
    {
        Console.WriteLine("To Add press a");
        Console.WriteLine("To Print press b");
        Console.WriteLine("To PrintAll press c");
        Console.WriteLine("To update press d");
        Console.WriteLine("To delete press e");
        string choice2 = Console.ReadLine();
        switch (choice2)
        {
            case "a":
                Order or =new Order();  
                Console.WriteLine("enter ID:");
                or.ID= int.Parse(Console.ReadLine());
                Console.WriteLine("enter Customer Name:");
                or.CustomerName = Console.ReadLine();
                Console.WriteLine("enter Customer Email:");
                or.CustomerEmail  = Console.ReadLine();
                Console.WriteLine("enter Customer Adress:");
                or.CustomerAdress = Console.ReadLine();
                Console.WriteLine("enter Order Date:");
                or.OrderDate = DateTime.Parse( Console.ReadLine());
                Console.WriteLine("enter Ship Date:");
                or.ShipDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("enter Delivery Date:");
                or.DeliveryDate = DateTime.Parse(Console.ReadLine());
                order1.AddOrder(or);





                break;
            case 'b':
                DeleteOrder();
            break;
            case 'c':
                UpdateOrder();
            break;
            case 'd':
                Console.WriteLine();
            break;
            case 'e':

            break;
        }
    }


}

