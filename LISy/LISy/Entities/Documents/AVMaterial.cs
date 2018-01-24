using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    public class AVMaterial : Takable
    {
        public bool IsAVideo { get; private set; }

        public AVMaterial(string[] authors, string title, bool video, string[] keys, int room, int level, string image, int price, int amount) : base(authors, title, keys, room, level, image, price, amount)
        {
            IsAVideo = video;
        }
    }
}
