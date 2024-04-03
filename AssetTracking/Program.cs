using System;
using AssetTracking.controllers;
using AssetTracking.interfaces;

namespace AssetTracking
{
    public class Program
    {
        static void Main(string[] args)
        {
            IOrder orderList = new Order();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine(">> Welcome to your new local office");
                Console.WriteLine(">> You have to get new electronics today!");
                Console.WriteLine(">> Pick an option: ");
                Console.WriteLine(">> (1) Add new electronics");
                Console.WriteLine(">> (2) Level 2 (sorted by primary and sorted by purchased date)");
                Console.WriteLine(">> (3) Level 3 (sorted by office and then by purchased date)");
                Console.WriteLine(">> (4) Exit");
                Console.WriteLine("Please enter a choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        while (true)
                        {
                            Console.WriteLine("Enter office: ");
                            string name = Console.ReadLine();
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Office cannot be empty. Please enter a valid office.");
                                continue;
                            }

                            Console.WriteLine("Enter type of the electronic (Computer/Phone): ");
                            string type = Console.ReadLine();
                            if (string.IsNullOrEmpty(type))
                            {
                                Console.WriteLine("Type cannot be empty. Please enter a valid type.");
                                continue;
                            }

                            Console.WriteLine("Enter brand of the electronic: ");
                            string brand = Console.ReadLine();
                            if (string.IsNullOrEmpty(brand))
                            {
                                Console.WriteLine("Brand cannot be empty. Please enter a valid brand.");
                                continue;
                            }

                            Console.WriteLine("Enter model of the electronic: ");
                            string model = Console.ReadLine();
                            if (string.IsNullOrEmpty(model))
                            {
                                Console.WriteLine("Model cannot be empty. Please enter a valid model.");
                                continue;
                            }

                            Console.WriteLine("Enter date of purchase (MM/dd/yyyy): ");
                            string date = Console.ReadLine();
                            if (string.IsNullOrEmpty(date))
                            {
                                Console.WriteLine("Date cannot be empty. Please enter a valid date.");
                                continue;
                            }

                            Console.WriteLine("Enter price of the electronic: ");
                            string priceStr = Console.ReadLine();
                            if (!int.TryParse(priceStr, out int price))
                            {
                                Console.WriteLine("Price must be a valid number. Please enter a valid price.");
                                continue;
                            }

                            Console.WriteLine("Enter currency of the electronic (EUR, SEK, USD): ");
                            string currency = Console.ReadLine().ToUpper();
                            if (string.IsNullOrEmpty(currency) || (currency != "EUR" && currency != "SEK" && currency != "USD"))
                            {
                                Console.WriteLine("Invalid currency. Please enter a valid currency (EUR, SEK, USD).");
                                continue;
                            }

                            string localPriceToday = price.ToString();
                            orderList.Add(name, type, brand, model, date, price, currency, localPriceToday);
                            break; // Exit the loop if all inputs are valid and the electronic is added
                        }
                        break;
                    case "2":
                        orderList.SortByPrimary();
                        orderList.SortByPurchasedDate();
                        break;
                    case "3":
                        orderList.SortByOffice();
                        orderList.SortByPurchasedDate();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again");
                        break;
                }
            }
        }
    }
}
