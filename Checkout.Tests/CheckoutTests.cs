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

        }
    }
}