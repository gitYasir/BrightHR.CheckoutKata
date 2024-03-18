using CheckoutApp;
using NUnit.Framework;

namespace CheckoutTests {
    public class CheckoutTests {
        public class ItemPricingTests {
            [Test]
            public void ItemPricing_Constructor_Should_Set_Properties_Correctly() {
                char sku = 'A';
                int unitPrice = 50;
                int specialQuantity = 3;
                int specialPrice = 130;

                var itemPricing = new ItemPricing( sku, unitPrice, specialQuantity, specialPrice );

                Assert.That( itemPricing.SKU, Is.EqualTo( sku ) );
                Assert.That( itemPricing.UnitPrice, Is.EqualTo( unitPrice ) );
                Assert.That( itemPricing.SpecialPrice, Is.EqualTo( (specialQuantity, specialPrice) ) );
            }

            [Test]
            public void ItemPricing_Constructor_Default_SpecialPrice_Should_Be_Zero() {
                char sku = 'C';
                int unitPrice = 20;

                var itemPricing = new ItemPricing( sku, unitPrice );

                Assert.That( itemPricing.SKU, Is.EqualTo( sku ) );
                Assert.That( itemPricing.UnitPrice, Is.EqualTo( unitPrice ) );
                Assert.That( itemPricing.SpecialPrice, Is.EqualTo( (0, 0) ) );
            }
            [Test]
            public void Scan_Should_Throw_Exception_For_Invalid_Item() {
                var checkout = new Checkout( new List<ItemPricing>() );
                string invalidItem = "1";

                Assert.Throws<ArgumentException>( () => checkout.Scan( invalidItem ) );
            }

            [Test]
            public void Scan_Should_Increment_Quantity_For_Existing_Item() {
                var checkout = new Checkout( new List<ItemPricing> { new ItemPricing( 'A', 50 ) } );
                string item = "A";

                checkout.Scan( item );
                checkout.Scan( item );

                Assert.That( checkout.scannedItems[ item[ 0 ] ], Is.EqualTo( 2 ) );
            }
            [Test]
            public void GetTotalPrice_Should_Return_Total_Price_Of_Items() {
                var pricingRules = new List<ItemPricing>
                {
                new ItemPricing('A', 50),
                new ItemPricing('B', 30),
                new ItemPricing('C', 20),
                new ItemPricing('D', 15)
            };
                var checkout = new Checkout( pricingRules );

                checkout.Scan( "A" );
                checkout.Scan( "B" );
                checkout.Scan( "C" );
                checkout.Scan( "D" );

                int expectedTotalPrice = 50 + 30 + 20 + 15;

                Assert.That( checkout.GetTotalPrice(), Is.EqualTo( expectedTotalPrice ) );
            }
            [Test]
            public void GetTotalPrice_Should_Return_Correct_Price_With_Special_Offer() {
                // Arrange
                var pricingRules = new List<ItemPricing>
                {
        new ItemPricing('A', 50, 3, 130),
        new ItemPricing('B', 30, 2, 45),
        new ItemPricing('C', 20),
        new ItemPricing('D', 15)
    };
                var checkout = new Checkout( pricingRules );

                // Act
                checkout.Scan( "A" );
                checkout.Scan( "A" );
                checkout.Scan( "A" );

                // Assert
                Assert.AreEqual( 130, checkout.GetTotalPrice() );
            }

            [Test]
            public void GetTotalPrice_Should_Return_Correct_Price_With_Default_Price() {
                // Arrange
                var pricingRules = new List<ItemPricing>
                {
        new ItemPricing('A', 50),
        new ItemPricing('B', 30),
        new ItemPricing('C', 20),
        new ItemPricing('D', 15)
    };
                var checkout = new Checkout( pricingRules );

                // Act
                checkout.Scan( "A" );
                checkout.Scan( "B" );
                checkout.Scan( "C" );
                checkout.Scan( "D" );

                // Assert
                Assert.AreEqual( 50 + 30 + 20 + 15, checkout.GetTotalPrice() );
            }

        }
    }
}