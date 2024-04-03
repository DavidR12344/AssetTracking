using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.interfaces
{
    public interface IOrder
    {
        void Add(string name, string type, string brand, string model, string date, int price, string currency, string localPriceToday);

        void Mark(int index);

        void View();

        void SortByPrimary();

        void SortByOffice();

        void SortByPurchasedDate();
    }
}
