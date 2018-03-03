using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy.Entities.Documents
{
    /// <summary>
    /// Represents an AV entity in the library.
    /// </summary>
    public class AVMaterial : Takable
    {

        public AVMaterial() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of an AV material.
        /// </summary>
        /// <param name="authors">Authors of the material.</param>
        /// <param name="title">Title of the material.</param>
        /// <param name="keys">KeyWords using which the material can be found.</param>
        /// <param name="image">Cover of the material.</param>
        /// <param name="price">Price of the material.</param>
        public AVMaterial(string authors, string title, string keys, string image, int price) : base(authors, title, keys, image, price)
        {

        }

        public AVMaterial(long id, string authors, string title, string keys, string image, int price) : base(id, authors, title, keys, image, price)
        {

        }
    }
}
