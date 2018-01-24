using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    public abstract class Takable : Document
    {
        public int Price { get; protected set; }
        public int Amount { get; protected set; }
        public LinkedList<Copy> Copies { get; protected set; }

        public Takable(string[] authors, string title, string[] keys, int room, int level, Image image, int price, int amount) : base(authors, title, keys, room, level, image)
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

        public void CheckOutCopy(User patron)
        {
            if (!IsAvailable())
            {
                return;
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

        public void ReturnCopy(User patron)
        {
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

        public void AddCopy()
        {
            Copies.AddLast(new Copy(this));
            ++Amount;
        }

        public void AddCopies(int n)
        {
            if (n < 2) return;
            for (int i = 1; i <= n; ++i)
                Copies.AddLast(new Copy(this));
            Amount += n;
        }

        public void RemoveCopy()
        {
            if (!IsAvailable()) return;
            foreach (Copy temp in Copies)
            {
                if (temp.IsAvailable())
                {
                    Copies.Remove(temp);
                    break;
                }
            }
            --Amount;
        }
    }
}
