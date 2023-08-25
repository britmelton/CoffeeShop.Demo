namespace CoffeeShop
{
    [Flags]
    public enum CoffeeOptions
    {
        None = 0,
        Milk = 1 << 0,
        Cream = 1 << 1,
        CaramelSyrup = 1 << 2,
        ChocolateSyrup = 1 << 3
    }

    public static class CoffeeOptionsExtensions
    {
        public static Dictionary<CoffeeOptions, decimal> Prices = new()
        {
            { CoffeeOptions.Milk, 2.00m },
            { CoffeeOptions.Cream, 1.00m },
            { CoffeeOptions.CaramelSyrup, .90m },
            { CoffeeOptions.ChocolateSyrup, .75m }
        };
    }
}