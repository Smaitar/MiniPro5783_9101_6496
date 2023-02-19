
//using BlApi;
//using BlImplementation;
using BO;
namespace BlTest
{
    internal class Program
    {
        private static BlApi.IBL? _bl = BlApi.Factory.Get();
        //private static IBL _bl = new Bl();

        private static Cart _cart = new Cart { Items = new List<OrderItem>() };

        public static void Main(string[] args)
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("To Order press 1");
                Console.WriteLine("To OrderItem press 2");
                Console.WriteLine("To Product press 3");
                Console.WriteLine("To Exit press 0");

                choice = tryParseInt();
                //Sending to help functions according to the selected personalities
                try
                {
                    switch (choice)
                    {
                        case 1:
                            orderOption();
                            break;

                        case 2:
                            cartOption();
                            break;

                        case 3:
                            productOption();
                            break;

                        default:
                            break;
                    }
                }

               //catch the throws
                catch (BO.NagtiveNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (BO.EmptyStringAddress ex)
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
        {//convert the string to int
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Wrong number enter again");
            }
            return number;
        }

        private static double tryParseDouble()
        {//convert to double in cases we will need it like price..
            double number;

            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Wrong number enter again");
            }
            return number;
        }

        private static void cartOption()//if the user chose orderItem
        {

            //the options the user can make
            string choice = "";

            while (choice != "e")
            {
                Console.WriteLine("To add order item to cart press a");
                Console.WriteLine("To update amount press b");
                Console.WriteLine("To commit order press c");
                Console.WriteLine("To clear the items d");
                Console.WriteLine("To exit press e");

                choice = Console.ReadLine()!;
                int id;

                switch (choice)
                {
                    case "a":
                        Console.WriteLine("enter ID:");
                        id = tryParseInt();
                        _bl.Cart.AddProduct(_cart, id);
                        break;

                    case "b":
                        Console.WriteLine("enter ID:");
                        id = tryParseInt();

                        Console.WriteLine("enter amount:");
                        int amount = tryParseInt();
                        _bl.Cart.UpdateCart(_cart, id, amount);
                        break;

                    case "c":
                        Console.WriteLine("enter Customer Name:");
                        _cart.CustomerName = Console.ReadLine()!;

                        Console.WriteLine("enter Customer Email:");
                        _cart.CustomerEmail = Console.ReadLine()!;

                        Console.WriteLine("enter Customer Adress:");
                        _cart.CustomerAdress = Console.ReadLine()!;

                        _bl.Cart.AprrovedCart(_cart);
                        break;

                    case "d":
                        _bl.Cart.ClearItems(_cart);
                        break;
                }
            }
        }


        private static void orderOption()//if the user chose to order
        {
            string choice = "";
            int id;

            while (choice != "f")
            {
                Console.WriteLine("To print press a");
                Console.WriteLine("To printAll press b");
                Console.WriteLine("To update sent press c");
                Console.WriteLine("To update supplied press d");
                Console.WriteLine("To order trackinge e");
                Console.WriteLine("To exit press f");

                choice = Console.ReadLine()!;

                switch (choice)
                {

                    case "a":
                        Console.WriteLine("enter ID:");
                        id = tryParseInt();
                        Console.WriteLine(_bl.Order.OrderDetails(id));
                        break;

                    case "b":
                        foreach (OrderForList ob in _bl.Order.GetOrderForListsManager())
                            Console.WriteLine(ob);
                        break;

                    case "c":
                        Console.WriteLine("enter ID:");
                        id = tryParseInt();
                        Console.WriteLine(_bl.Order.UpdateSentOrder(id));
                        break;

                    case "d":
                        Console.WriteLine("enter ID:");
                        id = tryParseInt();
                        Console.WriteLine(_bl.Order.UpdateSuppliedOrder(id));
                        break;

                    case "e":
                        Console.WriteLine("enter ID:");
                        id = tryParseInt();
                        Console.WriteLine(_bl.Order.OrderTracking(id));
                        break;
                }
            }
        }

        private static void productOption()//if the user chose Product
        {
            //the options the user can make

            string choice = "";

            while (choice != "g")
            {
                Console.WriteLine("To add press a");
                Console.WriteLine("To print product press b");
                Console.WriteLine("To printAll press c");
                Console.WriteLine("To update press d");
                Console.WriteLine("To delete press e");
                Console.WriteLine("To print product item press f");
                Console.WriteLine("To exit press g");
                choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "a":
                        BO.Product product = new BO.Product();
                        Console.WriteLine("enter ID:");
                        product.ID = tryParseInt();

                        Console.WriteLine("enter Name:");
                        product.Name = Console.ReadLine();

                        Console.WriteLine("enter Category:");
                        int x = tryParseInt();

                        product.Category = (Category)(x);
                        Console.WriteLine("enter InStock:");

                        product.InStock = tryParseInt();
                        Console.WriteLine("enter Price:");

                        product.Price = tryParseDouble();

                        _bl.Product.Add(product);
                        break;

                    case "b":
                        Console.WriteLine("enter ID:");
                        Console.WriteLine(_bl.Product.GetProductClient(tryParseInt(), _cart));
                        break;

                    case "c":
                        foreach (var ob in _bl.Product.GetList())
                            Console.WriteLine(ob);
                        break;

                    case "d":

                        BO.Product orb = new BO.Product();

                        Console.WriteLine("enter ID:");
                        orb.ID = tryParseInt();

                        Console.WriteLine("enter Name:");
                        orb.Name = Console.ReadLine();

                        Console.WriteLine("enter Category:");
                        int y = tryParseInt();

                        orb.Category = (Category)(y);
                        Console.WriteLine("enter InStock:");

                        orb.InStock = tryParseInt();
                        Console.WriteLine("enter Price:");

                        orb.Price = tryParseDouble();
                        _bl.Product.Update(orb);
                        break;

                    case "e":
                        Console.WriteLine("enter ID:");
                        _bl.Product.Delete(tryParseInt());
                        break;

                    case "f":
                        Console.WriteLine("enter ID:");
                        _bl.Product.GetProductClient(tryParseInt(), _cart);
                        break;
                }
            }

        }

    }
}
