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
        public int Amount { get; protected set; }
        public LinkedList<Copy> Copies { get; protected set; }

        public Takable(string[] authors, string title, string[] keys, int room, int level, string image, int price, int amount) : base(authors, title, keys, room, level, image)
        {
            Price = price;
            Amount = amount;
            for (int i = 1; i <= amount; ++i)
                Copies.AddLast(new Copy(this));
        }

        public bool IsAvailable()
        {
            return Amount > 0;
        }

        public void CheckOutCopy(Patron patron)
        {
            if (patron == null) throw new ArgumentNullException();
            if (!IsAvailable())
            {
                return; // which exception?
            }
            foreach (Copy temp in Copies)
            {
                if (temp.IsAvailable())
                {
                    temp.CkeckOut(patron);
                    break;
                }
            }
            --Amount;
        }

        public void ReturnCopy()
        {
            ++Amount;
        }

        public void AddCopies(int n)
        {
            if (n < 1) throw new ArgumentException();
            for (int i = 1; i <= n; ++i)
                Copies.AddLast(new Copy(this));
            Amount += n;
        }

        public void RemoveCopy()
        {
            if (!IsAvailable()) return; // which exception?
            foreach (Copy temp in Copies)
            {
                if (temp.IsAvailable())
                {
                    Copies.Remove(temp); // is it right?
                    break;
                }
            }
            --Amount;
        }
    }
}
