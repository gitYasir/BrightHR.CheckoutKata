using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutApp {
    public interface ICheckout {
        void Scan( string item );
        int GetTotalPrice();
    }

    public class ItemPricing {
        public char SKU { get; set; }
        public int UnitPrice { get; set; }
        public (int Quantity, int SpecialPrice) SpecialPrice { get; set; }

        public ItemPricing( char sku, int unitPrice, int specialQuantity = 0, int specialPrice = 0 ) {
            SKU = sku;
            UnitPrice = unitPrice;
            SpecialPrice = (specialQuantity, specialPrice);
        }
    }

    public class Checkout : ICheckout {
        private Dictionary<char, ItemPricing> itemPrices;
        private Dictionary<char, int> scannedItems;

        public int GetTotalPrice() {
            int totalPrice = 0;

            foreach ( var item in scannedItems ) {
                var pricing = itemPrices[ item.Key ];
                int quantity = item.Value;

                if ( pricing.SpecialPrice.Quantity > 0 && quantity >= pricing.SpecialPrice.Quantity ) {
                    int specialPriceGroups = quantity / pricing.SpecialPrice.Quantity;
                    int remainingItems = quantity % pricing.SpecialPrice.Quantity;
                    totalPrice += ( specialPriceGroups * pricing.SpecialPrice.SpecialPrice ) + ( remainingItems * pricing.UnitPrice );
                }
                else {
                    totalPrice += quantity * pricing.UnitPrice;
                }
            }
        }

        public void Scan( string item ) {
            if ( item.Length != 1 || !char.IsLetter( item[ 0 ] ) ) {
                throw new ArgumentException( "Invalid item" );
            }

            char sku = char.ToUpper( item[ 0 ] );

            if ( !itemPrices.ContainsKey( sku ) ) {
                throw new ArgumentException( $"Item '{sku}' not found in pricing rules" );
            }

            if ( !scannedItems.ContainsKey( sku ) ) {
                scannedItems[ sku ] = 1;
            }
            else {
                scannedItems[ sku ]++;
            }
        }
    }


}
