using System;

namespace AssetTracking.models
{
    public abstract class Electronic : Office
    {
        public Electronic(string name, string type, string brand, string model, string purchasedDate, int price, string currency, string localPriceToday) : base(name)
        {
            Type = type;
            Brand = brand;
            Model = model;
            PurchasedDate = purchasedDate;
            Price = price;
            Currency = currency;
            LocalPriceToday = localPriceToday;
            EndOfLife = CalculateEndOfLife(purchasedDate);
        }

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PurchasedDate { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public string LocalPriceToday { get; set; }
        public DateTime EndOfLife { get; set; }

        private DateTime CalculateEndOfLife(string purchasedDate)
        {
            if (DateTime.TryParseExact(purchasedDate, new[] { "MM/dd/yyyy", "MM-dd-yyyy" }, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime purchaseDate))
            {
                return purchaseDate.AddYears(3);
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
