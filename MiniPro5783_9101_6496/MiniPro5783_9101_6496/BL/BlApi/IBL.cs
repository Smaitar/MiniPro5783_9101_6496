namespace BlApi
{
    public interface IBL
    {
        public IProduct Product { get; }
        public ICart Cart { get; }
        public IOrder Order { get; }
    }
}
