namespace xCarpaccio.client
{
    public class Order
    {
        public decimal[] Prices { get; set; }
        public int[] Quantities { get; set; }
        public string Country { get; set; }
        public string Reduction { get; set; }

    }
}