namespace BO
{
    public class OrderItem
    {
        public int ProductID { get; set; }//ProductID
        public string? ProductName { get; set; }//Order Item Name
        public double Price { get; set; }// Price
        public int Amount { get; set; }//Amount
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return $@"
           Order Item Details:
           Product ID: {ProductID},
    	   Order Item Name: {ProductName},
    	   Price: {Price},
           Amount: {Amount},
           Total Price: {TotalPrice}.";
        }
    }
}
