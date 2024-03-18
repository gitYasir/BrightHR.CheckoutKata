# Checkout Kata C# Solution

This C# solution implements the Checkout Kata, which simulates the checkout process in a supermarket with pricing rules for different items.

## Project Structure

The solution consists of two projects:
- **CheckoutApp**: This project contains the implementation of the checkout system, including the `ItemPricing` class, the `ICheckout` interface, and the `Checkout` class.
- **CheckoutTests**: This project contains NUnit tests to ensure the correctness of the implementation in the CheckoutApp project.

### CheckoutApp Project

#### ItemPricing Class (ItemPricing.cs)
- Represents the pricing rules for each item in the store.
- Properties:
  - `SKU`: Stock Keeping Unit (identifier) of the item.
  - `UnitPrice`: Price of one unit of the item.
  - `SpecialPrice`: Special pricing rules stored as a tuple containing the quantity and the special price for that quantity.
- Explanation: Encapsulates pricing information for each item, facilitating management and updates to pricing rules.

#### ICheckout Interface (ICheckout.cs)
- Defines the contract for checkout implementations.
- Methods:
  - `Scan(string item)`: Adds an item to the checkout.
  - `GetTotalPrice()`: Calculates and returns the total price of all scanned items.
- Explanation: Ensures consistency and modularity in checkout implementations.

#### Checkout Class (Checkout.cs)
- Implements the `ICheckout` interface, representing the checkout system.
- Fields:
  - `itemPrices`: Dictionary to store pricing rules for each item.
  - `scannedItems`: Dictionary to store scanned items and their quantities.
- Methods:
  - `Scan(string item)`: Adds the scanned item to the checkout.
  - `GetTotalPrice()`: Calculates total price based on scanned items and pricing rules.
- Explanation: Efficiently manages item pricing and scanned items, adhering to the defined contract.

### CheckoutTests Project

#### CheckoutTests Class (CheckoutTests.cs)
- NUnit tests for the `ItemPricing` class and the `Checkout` class.
- Tests cover constructor initialization, scanning items, and calculating the total price.
- Explanation: Validates implementation correctness and robustness through unit tests.

## Running the Tests

To run the tests, use any NUnit test runner or the Test Explorer in Visual Studio.

## License

This project is licensed under the [MIT License](LICENSE).
