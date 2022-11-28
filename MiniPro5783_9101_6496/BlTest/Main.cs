
using BlApi;
using DalApi;
using BO;
using BlImplementation; 
namespace BlTest
{
    internal class Program
    {
        private static IBL _bl = new Bl();

        private static Cart _cart = new Cart();

        public static void Main(string[] args)
        {
            int choice = tryParseInt();

            while (choice != 0)
            {
                Console.WriteLine("To Order press 1");
                Console.WriteLine("To OrderItem press 2");
                Console.WriteLine("To Product press 3");
                Console.WriteLine("To Exit press 0");

                choice = tryParseInt();

                try
                {
                    switch (choice)
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

                        default:
                            break;
                    }
                }

                catch (BO.NagtiveNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch(BO.EmptyString ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (BO.AlredyExist ex) when (ex.InnerException is not null) 
                {
                    Console.WriteLine(ex.Message + " " + ex.InnerException!.Message);
                }

                catch (BO.NotExist ex) when (ex.InnerException is not null)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static int tryParseInt()
        {
            int number;

            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Wrong number enter again");
            }
            return number;  
        }

        public static void OrderOption()//if the user chose to order
        {
            //IEnumerable<OrderForList> GetOrderForListsManager();
            //OrderTracking OrderTracking(int orderId);
            //Order OrderDetails(int ID);
            //Order GetOrder();
            //void Updatae(int OrderID);
            //the options the user can make

            Console.WriteLine("To get list press a");
            Console.WriteLine("To Print press b");
            Console.WriteLine("To PrintAll press c");
            Console.WriteLine("To update press d");
            Console.WriteLine("To delete press e");
            Console.WriteLine("To exit press f");

            string choice = Console.ReadLine()!;

            while (choice != "f")
            {
                try
                {
                    switch (choice)
                    {
                        case "a":

                            Console.WriteLine("enter Customer Name:");
                            _cart.CustomerName = Console.ReadLine()!;

                            Console.WriteLine("enter Customer Email:");
                            _cart.CustomerEmail = Console.ReadLine()!;

                            Console.WriteLine("enter Customer Adress:");
                            _cart.CustomerAdress = Console.ReadLine()!;
                            break;

                        case "b":

                            int id;
                            Console.WriteLine("enter ID:");
                            id = tryParseInt(); 
                            Console.WriteLine(_bl.Order.OrderDetails(id));
                            break;
                        case "c":
                            foreach(OrderForList ob in _bl.Order.GetOrderForListsManager())
                                Console.WriteLine(ob);
                            break;
                        case "d":
                            BO.Order orb = new BO.Order();
                            Console.WriteLine("enter ID:");
                            orb.ID = int.Parse(Console.ReadLine()!);
                            Console.WriteLine("enter Customer Name:");
                            orb.CustomerName = Console.ReadLine()!;
                            Console.WriteLine("enter Customer Email:");
                            orb.CustomerEmail = Console.ReadLine()!;
                            Console.WriteLine("enter Customer Adress:");
                            orb.CustomerAdress = Console.ReadLine()!;
                            Console.WriteLine("enter Order Date:");
                            orb.OrderDate = DateTime.Parse(Console.ReadLine()!);
                            Console.WriteLine("enter Ship Date:");
                            orb.ShipDate = DateTime.Parse(Console.ReadLine()!);
                            Console.WriteLine("enter Delivery Date:");
                            orb.DeliveryDate = DateTime.Parse(Console.ReadLine()!);
                          //  _bl.Order.Update(orb);
                            break;
                        case "e":
                            int ore;
                            Console.WriteLine("enter ID:");
                            ore = int.Parse(Console.ReadLine()!);
                            //_bl.Order.Delete(ore);
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
                choice = Console.ReadLine()!;
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
            string choice2 = Console.ReadLine()!;
            while (choice2 != "f")
            {
                try
                {
                    switch (choice2)
                    {
                        case "a":
                            BO.OrderItem or = new BO.OrderItem();
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
                            //_bl.OrderItem.Add(or);
                            break;
                        case "b":
                            int word;
                            Console.WriteLine("enter ID:");
                            word = int.Parse(Console.ReadLine());
                           // Console.WriteLine(_bl.OrderItem.GetByID(word));
                            break;
                        case "c":
                            //foreach (var ob in _bl.OrderItem.GetAll())
                            //    Console.WriteLine(ob);
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
                           // _bl.OrderItem.Update(orb);
                            break;
                        case "e":
                            int ore;
                            Console.WriteLine("enter ID:");
                            ore = int.Parse(Console.ReadLine());
                           // _bl.OrderItem.Delete(ore);
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
                        BO.Product pro = new BO.Product();
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
                        _bl.Product.Add(pro);
                        break;
                    case "b":
                        int word;
                        Console.WriteLine("enter ID:");
                        word = int.Parse(Console.ReadLine());
                        Console.WriteLine(_bl.Product.GetProductClient(word, _cart));
                        break;
                    case "c":
                        foreach (var ob in _bl.Product.GetList())
                            Console.WriteLine(ob);
                        break;
                    case "d":
                        BO.Product orb = new BO.Product();
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
                        _bl.Product.Update(orb);
                        break;
                    case "e":
                        int ore;
                        Console.WriteLine("enter ID:");
                        ore = int.Parse(Console.ReadLine());
                        _bl.Product.Delete(ore);
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
}
