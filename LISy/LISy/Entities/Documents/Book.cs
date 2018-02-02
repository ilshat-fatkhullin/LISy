﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    public class Book : Takable
    {
        public string Publisher { get; private set; }
        public string Edition { get; private set; }
        public int Year { get; private set; }
        public bool Bestseller { get; private set; }

        public Book(string[] authors, string title, string publisher, string edition, int year, bool bestseller, string[] keys, int room, int level, string image, int price, int amount) : base(authors, title, keys, room, level, image, price, amount)
        {
            Publisher = publisher ?? throw new ArgumentNullException("Book must have a publisher!");
            Edition = edition ?? throw new ArgumentNullException("Book must have an edition!");
            Year = year > 0 ? year : throw new ArgumentException("Invalid year!");
            Bestseller = bestseller;
        }

        public bool ChangeBestseller()
        {
            Bestseller = !Bestseller;
            return Bestseller;
        }
    }
}
