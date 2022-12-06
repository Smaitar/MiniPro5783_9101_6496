namespace BO
{
    public class OrderTracking
    {
        public int ID { get; set; }//OrderID

        public OrderStatus Status { get; set; }

        public List<(DateTime?, OrderStatus)>? OrderTrackings { get; set; }

        public override string ToString()
        {
            return $@"
           OrderTracking Details:
           Order ID: {ID}, 
           Order Status:{Status},
            string s = null;
            Items: {string.Join(", \n", OrderTrackings)},";
        }
    }
}
