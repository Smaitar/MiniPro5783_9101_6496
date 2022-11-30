
namespace BO
{
    public class OrderForList
    {
        public int ID { get; set; }//OrderID
        public string CustomerName { get; set; }//CustomerName
        public int AmountOfItem { get; set; }
        public BO.OrderStatus status { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return $@"
           OrderForList Details:
           Order ID: {ID}, 
           Customer Name {CustomerName},
           AmountOfItem: {AmountOfItem},
           Order Status:  {status},
           Total Price: {TotalPrice}.";
        }
    }
}
