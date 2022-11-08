
namespace DO
{
    public struct Product
    {
        public int ID { get; set; }//product ID
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? InStock { get; set; }
        public int Price { get; set; }

        public override string ToString() => $@"
        Product ID={ID}: {Name}, 
        category - {Category}
    	Price: {Price}
    	Amount in stock: {InStock}
";
    }
}
