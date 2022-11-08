
using system;
namespace DO
{
    public struct Order
    {
        public int ID { get; set; }//OrderID
        public string? CustomerName { get; set; }//CustomerName
        public string? CustomerEmail { get; set; }//CustomerEmail
        public string? CustomerAdress { get; set; }//CustomerAdress
        public DateTime OrderDate { get; set; }//OrderDate
        public DateTime ShipDate { get; set; }//ShipDate
        public DateTime DeliveryDate { get; set; }//DeliveryDate

        public override string ToString()
        {
            return $@"
           Order Details:
           Order ID: {ID}, 
           Customer Name: {CustomerName},
    	   Customer Email: {CustomerEmail},
    	   Customer Adress: {CustomerAdress},
           Order Date: {OrderDate},
           ShipDate: {ShipDate},
           Delivery Date: {DeliveryDate}.";
        }
    }

}

