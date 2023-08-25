namespace CoffeeShop
{
    public enum DiscountOptions
    {
        None = 0,
        Five = 1 << 0,
        Ten = 1 << 1,
        Fifteen = 1 << 2,
        Twenty = 1 << 3
    }
    public static class DiscountOptionsExtensions
    {
        public static Dictionary<DiscountOptions, decimal> Discounts = new()
        {
            { DiscountOptions.Five, .05m },
            { DiscountOptions.Ten, .10m },
            { DiscountOptions.Fifteen, .15m },
            { DiscountOptions.Twenty, .20m }
        };
    }
}