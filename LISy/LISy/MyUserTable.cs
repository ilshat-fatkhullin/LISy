using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISy
{
    class MyUserTable
    {
        public MyUserTable(int Id, string FirtsName, string LastName, string town, string street, int house, int flat, string phoneNumber, int countBookedBooks)
        {
            this.Id = Id;
            
        }
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public int house { get; set; }
        public int flat { get; set; }
        public int phoneNumber { get; set; }
        public int countBookedBooks { get; set; }
    }

}
