using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LISy.Entities.Users;

namespace LISy.Entities.Documents
{
    public abstract class Takable : Document
    {
        public int Price { get; protected set; }
        public List<Copy> Copies { get; protected set; }
        private Copy LastAvailableCopy;

        public Takable(string[] authors, string title, string[] keys, int room, int level, string image, int price, int amount) : base(authors, title, keys, room, level, image)
        {
            if (amount <= 0) throw new ArgumentException("Amount of copies cannot be nonpositive!");
            Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative!");
            Copies = new List<Copy>();
            for (int i = 1; i <= amount; ++i)
                Copies.Add(new Copy(this));
            LastAvailableCopy = Copies[0];
        }

        public int AvailableCopiesAmount()
        {
            int amount = 0;
            foreach (Copy temp in Copies)
            {
                if (temp.IsAvailable()) ++amount;
            }
            return amount;
        }

        public bool IsAvailable()
        {
            if (LastAvailableCopy != null && LastAvailableCopy.IsAvailable()) return true;
            foreach (Copy temp in Copies)
            {
                if (temp.IsAvailable())
                {
                    LastAvailableCopy = temp;
                    return true;
                }
            }
            return false;
        }

        public Copy CheckOutCopy(Patron patron)
        {
            if (patron == null) throw new ArgumentNullException("Copy must be checkouted to a patron!");
            if (!IsAvailable()) throw new Exception("No availbale copies!");
            LastAvailableCopy.CkeckOut(patron);
            return LastAvailableCopy;
        }

        public void AddCopies(int n)
        {
            if (n < 1) throw new ArgumentException("Ivalid amount of new copies!");
            for (int i = 1; i <= n; ++i)
                Copies.Add(new Copy(this));
        }

        public void RemoveCopy()
        {
            if (!IsAvailable()) throw new Exception("No availbale copies!");
            Copies.Remove(LastAvailableCopy);
            LastAvailableCopy = null;
        }
    }
}
