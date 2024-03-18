using CheckoutApp;
using NUnit.Framework;

namespace Checkout.Tests {
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
        }
    }
}