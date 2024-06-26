﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.interfaces
{
    public interface IOrder
    {
        //Method to add new Electronics to list
        void Add(string officeName, string type, string brand, string model, string date, int price, string currency, string localPriceToday);

        //Method to view all electronic in list
        void View();

        //Method to sort by type computer first and then phone
        void SortByPrimary();

        //Method to sort by office
        void SortByOffice();

        //Method to sort by purchased date
        void SortByPurchasedDate();
    }
}
