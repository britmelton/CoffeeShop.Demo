namespace CoffeeShop
{
    public class Coffee
    {
        public Coffee(Roast roast)
        {
            Roast = roast;
        }

        public const decimal BasePrice = 5.00m;

        public CoffeeOptions Options { get; private set; }
        public DiscountOptions Discount { get; set; }
        public Roast Roast { get; set; }

        public decimal DiscountedPrice => CalculateDiscount();
        public decimal Price => CalculatePrice();

        public void Add(CoffeeOptions options)
        {
            Options |= options;
        }

        public decimal CalculateDiscount()
        {
            decimal discountedPrice = 0;

            foreach (var (key, value) in DiscountOptionsExtensions.Discounts)
            {
                if (Discount.HasFlag(key))
                    discountedPrice = Price - Price * value;
            }
            return discountedPrice;
        }

        public decimal CalculatePrice()
        {
            var price = BasePrice;

            foreach (var (key, value) in CoffeeOptionsExtensions.Prices)
            {
                if (Options.HasFlag(key))
                    price += value;
            }
            return price;
        }

        public static Coffee operator +(Coffee coffee, CoffeeOptions options)
        {
            coffee.Add(options);
            return coffee;
        }

        public static Coffee operator +(CoffeeOptions options, Coffee coffee) => coffee + options;
    }
}