
namespace DO;

public struct OrderItem
{
    public int ID { get; set; }//OrderItem ID
    public int ProductID { get; set; }//ProductID
    public int OrderID { get; set; }//OrderID
    public double Price { get; set; }// Price
    public int Amount { get; set; }//Amount

    public override string ToString()
    {
        return $@"
           Order Item Details:
           Orders Item ID: {ID}, 
           Product ID: {ProductID},
    	   OrderID: {OrderID},
    	   Price: {Price},
           Amount: {Amount}.";
    }
}
