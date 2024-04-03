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

        /// <summary>
        /// Constructor and initialize list
        /// </summary>
        public Order()
        {
            electronics = new List<Electronic>();
        }

        /// <summary>
        /// Add a new electronic to list 
        /// </summary>
        /// <param name="officeName"></param>
        /// <param name="type"></param>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="purchasedDate"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="localPriceToday"></param>
        public void Add(string officeName, string type, string brand, string model, string purchasedDate, int price, string currency, string localPriceToday)
        {
            if (!IsValidCurrency(currency))
            {
                Console.WriteLine("Invalid currency. Please provide a valid currency (EUR, SEK, USD).");
                return;
            }

            localPriceToday = price.ToString();

            if (type.ToLower() == "computer")
            {
                Computer computer = new Computer(officeName, type, brand, model, purchasedDate, price, currency, localPriceToday);
                electronics.Add(computer);
                Console.WriteLine("Computer added to your order");
            }
            else if (type.ToLower() == "phone")
            {
                Mobile mobile = new Mobile(officeName, type, brand, model, purchasedDate, price, currency, localPriceToday);
                electronics.Add(mobile);
                Console.WriteLine("Phone added to your order");
            }
        }

        /// <summary>
        /// Checks if the currency is valid
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>

        private bool IsValidCurrency(string currency)
        {
            return currency.ToUpper() == "EUR" || currency.ToUpper() == "SEK" || currency.ToUpper() == "USD";
        }

        /// <summary>
        /// Displays all electronic in list and Mark an electronic as red or yellow if end of life is near. 
        /// </summary>
        public void View()
        {
            if (electronics.Count == 0)
            {
                Console.WriteLine("No Electronics in your order");
            }
            else
            {
                Console.WriteLine($"{"Type",-10}{"Brand",-15}{"Model",-15}{"Office",-15}{"Purchase Date",-15}{"Price (USD)",-12}{"Currency",-10}{"Local price today",10}");
                for (int i = 0; i < electronics.Count; i++)
                {
                    Electronic electronicItem = electronics[i];
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
                    Console.WriteLine($"{electronicItem.Type,-10}{electronicItem.Brand,-15}{electronicItem.Model,-15}{electronicItem.OfficeName,-15}{electronicItem.PurchasedDate,-15}{electronicItem.Price,-12}{electronicItem.Currency,-10}{electronicItem.LocalPriceToday,10}");

                    // Reset console foreground color to default
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Sort by office
        /// </summary>
        public void SortByOffice()
        {
            electronics.Sort((e1, e2) => e1.OfficeName.CompareTo(e2.OfficeName));
            Console.WriteLine("Electronics sorted by office.");
            View();
        }

        /// <summary>
        /// Sort by computer first and then phones. If it is same type leave them as they ARE
        /// </summary>

        public void SortByPrimary()
        {
            electronics.Sort((e1, e2) =>
            {
                if (e1.Type.ToLower() == "computer" && e2.Type.ToLower() != "computer")
                {
                    return -1;
                }
                else if (e1.Type.ToLower() != "computer" && e2.Type.ToLower() == "computer")
                {
                    return 1;
                }
                else
                {
                    return 0; // e1 and e2 are either both computers or both phones, their order remains unchanged
                }
            });

            Console.WriteLine("Electronics sorted by primary.");
            View();
        }

        //Sort by purchased date
        public void SortByPurchasedDate()
        {
            electronics.Sort((e1, e2) =>
            {
                DateTime purchaseDate1, purchaseDate2;
                bool parse1 = DateTime.TryParseExact(e1.PurchasedDate, new[] { "MM/dd/yyyy", "MM-dd-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out purchaseDate1);
                bool parse2 = DateTime.TryParseExact(e2.PurchasedDate, new[] { "MM/dd/yyyy", "MM-dd-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out purchaseDate2);

                if (parse1 && parse2)
                {
                    return purchaseDate1.CompareTo(purchaseDate2);
                }
                return 0;
            });

            Console.WriteLine("Electronics sorted by purchased date.");
            View();
        }


    }
}
