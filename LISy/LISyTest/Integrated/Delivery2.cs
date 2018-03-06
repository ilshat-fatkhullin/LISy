using System;
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using LISy.Managers;
using LISy.Managers.DataManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LISyTest.Integrated
{
    [TestClass]
    public class Delivery2
    {
        [TestMethod]
        public void TestCase1()
        {
            DatabaseDataManager.ClearAll();
            LibrarianDataManager.AddUser(new Librarian("LibrarianName", "LibrarianSurname", "80000000000", "Address"),
                "librarian_1", "12345");
            LibrarianDataManager.AddDocument(new Book("Authors", "Book_1", "Publisher", "Edition", 2018, false, "Keys", "", 100));
            LibrarianDataManager.AddCopy(3, new Copy(1, 1, 1));
            LibrarianDataManager.AddDocument(new Book("Authors", "Book_2", "Publisher", "Edition", 2018, false, "Keys", "", 100));
            LibrarianDataManager.AddCopy(2, new Copy(2, 1, 2));
            LibrarianDataManager.AddDocument(new Book("Authors", "Book_3", "Publisher", "Edition", 2018, false, "Keys", "", 100));
            LibrarianDataManager.AddCopy(1, new Copy(3, 1, 2));
            LibrarianDataManager.AddDocument(new AVMaterial("Authors", "AVMaterial_1", "Keys", "", 100));
            LibrarianDataManager.AddDocument(new AVMaterial("Authors", "AVMaterial_2", "Keys", "", 100));

            LibrarianDataManager.AddUser(new Librarian("LibrarianName", "LibrarianSurname", "80000000000", "Address"),
                "librarian_1", "12345");
            LibrarianDataManager.AddUser(new Faculty("FacultyName", "FacultySurname", "80000000000", "Address"),
                "patron_1", "12345");
            LibrarianDataManager.AddUser(new Student("StudentName", "StudentSurname", "80000000000", "Address"),
                "patron_2", "12345");
            LibrarianDataManager.AddUser(new Student("StudentName", "StudentSurname", "80000000000", "Address"),
                "patron_3", "12345");

            
        }
    }
}
