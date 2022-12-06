namespace BO
{
    public class Order
    {
        public int ID { get; set; }//OrderID
        public string? CustomerName { get; set; }//CustomerName
        public string? CustomerEmail { get; set; }//CustomerEmail
        public string? CustomerAdress { get; set; }//CustomerAdress
        public DateTime? OrderDate { get; set; }//OrderDate
        public DateTime? ShipDate { get; set; }//ShipDate
        public DateTime? DeliveryDate { get; set; }//DeliveryDate
        public OrderStatus Status { get; set; }
        public DateTime? PaymentDate { get; set; }
        public List<OrderItem?>? Items { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString() =>
             $@"
           Order Details:
           Order ID: {ID}, 
           Customer Name {CustomerName},
    	   Customer Email: {CustomerEmail},
    	   Customer Adress: {CustomerAdress},
           Order Date: {OrderDate},
           ShipDate: {ShipDate},
           Delivery Date: {DeliveryDate}
           Order Status:  {Status},
           Payment Date: {PaymentDate}, 
           Items: {string.Join(", \n", Items)},
            Total Price: {TotalPrice}";
    }
}
