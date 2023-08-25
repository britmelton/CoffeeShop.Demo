namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose your roast:");

            var roastInput = Console.ReadLine().ToLower();
            var roast = DetermineRoast(roastInput);

            Console.WriteLine("----------------------------------------------------------------------");

            var coffee = new Coffee(roast);
            Console.WriteLine("Choose your additions: ");
            Console.WriteLine("\tmilk\n\tcream\n\tcaramel syrup\n\tchocolate syrup");
            Console.WriteLine("(type each selection individually and hit enter, when finished hit enter again)");
            Console.WriteLine("\n");
            Console.WriteLine("Selections:\n");
            while (true)
            {
                var additions = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(additions))
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine(
                        $"Coffee Order:\n\t Roast: {coffee.Roast}\n\t Additions: {coffee.Options}\n\t Total: ${coffee.Price}"
                    );
                    break;
                }

                DetermineOptions(additions, coffee);
            }
        }

        public static Roast DetermineRoast(string roastInput)
        {
            var roast = new Roast();

            switch (roastInput)
            {
                case "light":
                    roast = Roast.Light;
                    break;
                case "medium":
                    roast = Roast.Medium;
                    break;
                case "dark":
                    roast = Roast.Dark;
                    break;
                case "decaf":
                    roast = Roast.Decaf;
                    break;
            }
            return roast;
        }

        public static Coffee DetermineOptions(string selections, Coffee coffee)
        {
            switch (selections)
            {
                case "milk":
                    coffee += CoffeeOptions.Milk;
                    break;
                case "cream":
                    coffee += CoffeeOptions.Cream;
                    break;
                case "caramel syrup":
                    coffee += CoffeeOptions.CaramelSyrup;
                    break;
                case "chocolate syrup":
                    coffee += CoffeeOptions.ChocolateSyrup;
                    break;
            }
            return coffee;
        }
    }
}