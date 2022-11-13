
namespace DO;

public struct Product
{
    public int ID { get; set; }//product ID
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? InStock { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
        return $@"
           Product Details:
           Product ID: {ID}, 
           Product Name: {Name},
    	   Product Category: {Category},
    	   InStock: {InStock},
           Price: {Price}.";
    }
}
