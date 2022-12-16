using BlApi;

namespace BlImplementation
{
    internal class Bl : IBL
    {
        public ICart Cart { get;} = new Cart();
        public IOrder Order { get; } = new Order();
        public IProduct Product { get; } = new Product();
    }
}
