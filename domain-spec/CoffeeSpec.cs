using CoffeeShop;
using FluentAssertions;

namespace Domain.Spec
    {
        public class CoffeeSpec
        {
            #region Options.Spec
            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingOneOptions_ThenCoffeeContainsIt(Roast roast)
            {
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk;

                coffee.Options.Should().Be(CoffeeOptions.Milk);
            }

            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingMultipleOptions_ThenCoffeeContainsThem(Roast roast)
            {
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk | CoffeeOptions.Cream;

                coffee.Options.Should().Be(CoffeeOptions.Milk | CoffeeOptions.Cream);
            }

            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingAllOptions_ThenCoffeeContainsAll(Roast roast)
            {
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk | CoffeeOptions.Cream | CoffeeOptions.CaramelSyrup | CoffeeOptions.ChocolateSyrup;

                coffee.Options.Should().Be(CoffeeOptions.Milk | CoffeeOptions.Cream | CoffeeOptions.CaramelSyrup | CoffeeOptions.ChocolateSyrup);
            }
            #endregion

            #region Price.Spec
            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingOneOptions_ThenPriceIsCalculated(Roast roast)
            {
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk;

                coffee.Price.Should().Be(7.00m);
            }

            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingMultipleOptions_ThenPriceIsCalculated(Roast roast)
            {
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk | CoffeeOptions.Cream;

                coffee.Price.Should().Be(8.00m);
            }

            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingAllOptions_ThenPriceIsCalculated(Roast roast)
            {
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk | CoffeeOptions.Cream | CoffeeOptions.CaramelSyrup | CoffeeOptions.ChocolateSyrup;

                coffee.Price.Should().Be(9.65m);
            }

            #endregion

            #region NoOptions.Spec

            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingNoOptions_ThenNoOptionsAreSelected(Roast roast)
            {
                var coffee = new Coffee(roast);

                coffee.Options.Should().Be(CoffeeOptions.None);
            }

            [Theory]
            [InlineData(Roast.Light)]
            [InlineData(Roast.Medium)]
            [InlineData(Roast.Dark)]
            [InlineData(Roast.Decaf)]
            public void WhenAddingNoOptions_ThenPriceIsBasePrice(Roast roast)
            {
                var coffee = new Coffee(roast);

                coffee.Price.Should().Be(5.00m);
            }
            #endregion

            #region Roast.Spec
            [Fact]
            public void WhenSettingRoastToLight_ThenRoastIsLight()
            {
                var roast = Roast.Light;
                var coffee = new Coffee(roast);

                coffee.Roast.Should().Be(Roast.Light);
            }

            [Fact]
            public void WhenSettingRoastToMedium_ThenRoastIsMedium()
            {
                var roast = Roast.Medium;
                var coffee = new Coffee(roast);

                coffee.Roast.Should().Be(Roast.Medium);
            }

            [Fact]
            public void WhenSettingRoastToDark_ThenRoastIsDark()
            {
                var roast = Roast.Dark;
                var coffee = new Coffee(roast);

                coffee.Roast.Should().Be(Roast.Dark);
            }

            [Fact]
            public void WhenSettingRoastToDecaf_ThenRoastIsDecaf()
            {
                var roast = Roast.Decaf;
                var coffee = new Coffee(roast);

                coffee.Roast.Should().Be(Roast.Decaf);
            }
            #endregion

            #region Discount.Spec

            [Fact]
            public void WhenFivePercentDiscountIsApplied_ThenNewPriceIsCalculated()
            {
                var roast = Roast.Light;
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk;

                var discount = DiscountOptions.Five;
                coffee.Discount = discount;

                coffee.DiscountedPrice.Should().Be(6.65m);
            }

            [Fact]
            public void WhenTenPercentDiscountIsApplied_ThenNewPriceIsCalculated()
            {
                var roast = Roast.Light;
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk;

                var discount = DiscountOptions.Ten;
                coffee.Discount = discount;

                coffee.DiscountedPrice.Should().Be(6.30m);
            }

            [Fact]
            public void WhenFifteenPercentDiscountIsApplied_ThenNewPriceIsCalculated()
            {
                var roast = Roast.Light;
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk;

                var discount = DiscountOptions.Fifteen;
                coffee.Discount = discount;

                coffee.DiscountedPrice.Should().Be(5.95m);
            }

            [Fact]
            public void WhenTwentyPercentDiscountIsApplied_ThenNewPriceIsCalculated()
            {
                var roast = Roast.Light;
                var coffee = new Coffee(roast);
                coffee += CoffeeOptions.Milk;

                var discount = DiscountOptions.Twenty;
                coffee.Discount = discount;

                coffee.DiscountedPrice.Should().Be(5.60m);
            }

            #endregion
        }
    }

