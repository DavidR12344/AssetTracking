using AssetTracking.interfaces;
using AssetTracking.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.controllers
{
    public class Order : IOrder
    {
        private List<Electronic> electronics;

        public Order()
        {
            electronics = new List<Electronic>();
        }

        public void Add(string name, string type, string brand, string model, string purchasedDate, int price, string currency, string localPriceToday)
        {
            // Check if the currency is valid
            if (!IsValidCurrency(currency))
            {
                Console.WriteLine("Invalid currency. Please provide a valid currency (EUR, SEK, USD).");
                return;
            }

            // Adjust local price today to match current price and currency
            localPriceToday = price.ToString();

            if (type.ToLower() == "computer")
            {
                Computer computer = new Computer(name, type, brand, model, purchasedDate, price, currency, localPriceToday);
                electronics.Add(computer);
                Console.WriteLine("Computer added to your order");
            }
            else if (type.ToLower() == "phone")
            {
                Mobile mobile = new Mobile(name, type, brand, model, purchasedDate, price, currency, localPriceToday);
                electronics.Add(mobile);
                Console.WriteLine("Phone added to your order");
            }
        }

        private bool IsValidCurrency(string currency)
        {
            return currency.ToUpper() == "EUR" || currency.ToUpper() == "SEK" || currency.ToUpper() == "USD";
        }

        public void Mark(int index)
        {
            if (index >= 0 && index < electronics.Count)
            {
                Electronic electronicItem = electronics[index];
                DateTime endOfLife = electronicItem.EndOfLife;

                // Check if the end of life is within 6 months
                if (endOfLife <= DateTime.Now.AddMonths(6))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                // Check if the end of life is within 3 months
                else if (endOfLife <= DateTime.Now.AddMonths(3))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                // Print the electronic item details
                Console.WriteLine($"- Type {electronicItem.Type} - Brand {electronicItem.Brand} - Model {electronicItem.Model} - Office: {electronicItem.Name} - Purchase Date {electronicItem.PurchasedDate} - Price in USD {electronicItem.Price} - Currency {electronicItem.Currency} - Local price today {electronicItem.LocalPriceToday}");

                // Reset console foreground color to default
                Console.ResetColor();
            }
        }



        public void View()
        {
            if (electronics.Count == 0)
            {
                Console.WriteLine("No Electronics in your order");
            }
            else
            {
                // Print header row
                Console.WriteLine($"{"Type",-10}{"Brand",-15}{"Model",-15}{"Office",-15}{"Purchase Date",-15}{"Price (USD)",-12}{"Currency",-10}{"Local price today",10}");
                for (int i = 0; i < electronics.Count; i++)
                {
                    Mark(i);
                    // Print data row
                    Console.WriteLine($"{electronics[i].Type,-10}{electronics[i].Brand,-15}{electronics[i].Model,-15}{electronics[i].Name,-15}{electronics[i].PurchasedDate,-15}{electronics[i].Price,-12}{electronics[i].Currency,-10} {electronics[i].LocalPriceToday,-10}");
                }
            }
        }

        public void SortByOffice()
        {
            electronics.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
            Console.WriteLine("Electronics sorted by office.");
            View();
        }

        public void SortByPrimary()
        {
            // Sort electronics list placing computers first, then phones
            electronics.Sort((e1, e2) =>
            {
                // First, compare types. If they're different types, put Computer first.
                if (e1.Type != e2.Type)
                {
                    return e1.Type.CompareTo("computer");
                }
                // If they're the same type, leave them as they are.
                return 0;
            });

            Console.WriteLine("Electronics sorted by primary.");
            View();
        }

        public void SortByPurchasedDate()
        {
            electronics.Sort((e1, e2) => e1.PurchasedDate.CompareTo(e2.PurchasedDate));
            Console.WriteLine("Electronics sorted by purchased date.");
            View();
        }

    }
}
