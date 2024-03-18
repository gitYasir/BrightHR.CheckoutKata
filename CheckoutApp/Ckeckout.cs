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
            throw new NotImplementedException();
        }

        public void Scan( string item ) {
            throw new NotImplementedException();
        }
    }


}
