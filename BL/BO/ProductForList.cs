namespace BO
{
    public class ProductForList
    {
        public int ID { get; set; }//product ID
        public string? Name { get; set; }
        public BO.Category Category { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $@"
           ProductForList Details:
           Product ID: {ID}, 
           Product Name: {Name},
    	   Product Category: {Category}
           Price: {Price}.";
        }
    }
}
