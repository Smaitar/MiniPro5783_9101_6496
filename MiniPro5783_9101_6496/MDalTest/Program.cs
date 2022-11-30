
using Dal;
using DO;
namespace DalTest;
using DalApi;

internal class Program
{
    //define three kind of objects
    static private IDal dal = new DalList();

    public static void Main(string[] args)
    {
        Console.WriteLine("To Order press 1");
        Console.WriteLine("To OrderItem press 2");
        Console.WriteLine("To Product press 3");
        Console.WriteLine("To Exit press 0");
        int choice1 = int.Parse(Console.ReadLine());
        while (choice1 != 0)
        {
            switch (choice1)
            {
                case 1:
                    OrderOption();
                    Console.WriteLine("To Order press 1");
                    Console.WriteLine("To OrderItem press 2");
                    Console.WriteLine("To Product press 3");
                    Console.WriteLine("To Exit press 0");
                    choice1 = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    OrderItemOption();
                    Console.WriteLine("To Order press 1");
                    Console.WriteLine("To OrderItem press 2");
                    Console.WriteLine("To Product press 3");
                    Console.WriteLine("To Exit press 0");
                    choice1 = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    ProdectOption();
                    Console.WriteLine("To Order press 1");
                    Console.WriteLine("To OrderItem press 2");
                    Console.WriteLine("To Product press 3");
                    Console.WriteLine("To Exit press 0");
                    choice1 = int.Parse(Console.ReadLine());
                    break;
                default:
                    break;
            }
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
                        dal.Order.Add(or);
                        break;
                    case "b":
                        int word;
                        Console.WriteLine("enter ID:");
                        word = int.Parse(Console.ReadLine());
                        Console.WriteLine(dal.Order.GetByID(word));
                        break;
                    case "c":
                        foreach (Order ob in dal.Order.GetAll())
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
                        dal.Order.Update(orb);
                        break;
                    case "e":
                        int ore;
                        Console.WriteLine("enter ID:");
                        ore = int.Parse(Console.ReadLine());
                        dal.Order.Delete(ore);
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
    public static void OrderItemOption()//if the user chose orderItem
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
                        dal.OrderItem.Add(or);
                        break;
                    case "b":
                        int word;
                        Console.WriteLine("enter ID:");
                        word = int.Parse(Console.ReadLine());
                        Console.WriteLine(dal.OrderItem.GetByID(word));
                        break;
                    case "c":
                        foreach (var ob in dal.OrderItem.GetAll())
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
                        dal.OrderItem.Update(orb);
                        break;
                    case "e":
                        int ore;
                        Console.WriteLine("enter ID:");
                        ore = int.Parse(Console.ReadLine());
                        dal.OrderItem.Delete(ore);
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
                    dal.Product.Add(pro);
                    break;
                case "b":
                    int word;
                    Console.WriteLine("enter ID:");
                    word = int.Parse(Console.ReadLine());
                    Console.WriteLine(dal.Product.GetByID(word));
                    break;
                case "c":
                    foreach (var ob in dal.Product.GetAll())
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
                    dal.Product.Update(orb);
                    break;
                case "e":
                    int ore;
                    Console.WriteLine("enter ID:");
                    ore = int.Parse(Console.ReadLine());
                    dal.Product.Delete(ore);
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
