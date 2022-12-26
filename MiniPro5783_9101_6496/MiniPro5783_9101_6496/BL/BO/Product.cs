namespace BO
{
    public class Product
    {
        public int ID { get; set; }//product ID
        public string? Name { get; set; }
        public Category Category { get; set; }
        public int InStock { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $@"/
           Product Details:
           Product ID: {ID}, 
           Product Name: {Name},
    	   Product Category: {Category},
    	   InStock: {InStock},
           Price: {Price}.";
        }
    }
}
