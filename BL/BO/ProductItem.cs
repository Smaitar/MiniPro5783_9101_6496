namespace BO
{
    public class ProductItem
    {
        public int ID { get; set; }//product ID
        public string? Name { get; set; }
        public Category Category { get; set; }
        public bool InStock { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $@"
           ProductItem Details:
           Product ID: {ID}, 
           Product Name: {Name},
    	   Product Category: {Category},
    	   InStock: {InStock},
           Price: {Price},
           Amount:{Amount}.";
        }
    }
}
