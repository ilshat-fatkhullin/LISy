using System;
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using LISy.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LISyTest.Integrated
{
    [TestClass]
    public class Delivery3
    {
        public void Initialization()
        {
            LibrarianDataManager.ClearAll();
            LibrarianDataManager.AddBook(new Book(
                "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest and Clifford Stein",
                "Introduction to Algorithms",
                "MIT Press",
                "Third edition",
                2009,
                false,
                "Algorithms",
                "",
                5000
                ));
            LibrarianDataManager.AddBook(new Book(
                "Erich Gamma, Ralph Johnson, John Vlissides, Richard Helm",
                "Design Patterns: Elements of Reusable Object-Oriented Software",
                "Addison-Wesley Professional",
                "First edition",
                2003,
                true,
                "Algorithms",
                "",
                1700
                ));
            LibrarianDataManager.AddAVMaterial(new AVMaterial(
                "Tony Hoare",
                "Null References: The Billion DollarMistake",
                "",
                "",
                700));
            LibrarianDataManager.AddCopies(3, new Copy(1, 1, 1));
            LibrarianDataManager.AddCopies(3, new Copy(2, 1, 1));
            LibrarianDataManager.AddCopies(2, new Copy(3, 1, 1));

            LibrarianDataManager.AddFaculty(new Faculty(
                "Sergey",
                "Afonso",
                "30001",
                "ViaMargutta, 3",
                Faculty.PROFESSOR_SUBTYPE
                ), "patron_1", "12345");
            LibrarianDataManager.AddFaculty(new Faculty(
                "Nadia",
                "Teixeira",
                "30002",
                "Via Sacra, 13",
                Faculty.PROFESSOR_SUBTYPE
                ), "patron_2", "12345");
            LibrarianDataManager.AddFaculty(new Faculty(
                "Elvira",
                "Espindola",
                "30003",
                "Via del Corso, 22",
                Faculty.PROFESSOR_SUBTYPE
                ), "patron_3", "12345");
            LibrarianDataManager.AddStudent(new Student(
                "Andrey",
                "Velo",
                "30004",
                "AvenidaMazatlan 250"
                ), "patron_4", "12345");
            LibrarianDataManager.AddGuest(new Guest(
                "Veronika",
                "Rama",
                "30005",
                "Stret Atocha, 27"
                ), "patron_5", "12345");
            LibrarianDataManager.AddLibrarian(new Librarian(
                "LibrarianName",
                "LibrarianSurname",
                "30006",
                "LibrarianAddress"
                ), "librarian_1", "12345");
        }

        [TestMethod]
        public void D3TC1()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 1);
            PatronDataManager.CheckOutDocument(2, 1);
            LibrarianDataManager.ReturnDocument(2, 1);
            Copy copy = LibrarianDataManager.GetCheckedByUserCopiesList(1)[0];
            Assert.AreEqual(copy.DocumentId, 1);
            Assert.AreEqual(copy.ReturningDate, DateTime.Today.AddDays(28).ToShortDateString());
            Assert.AreEqual(LibrarianDataManager.GetFinesByPatronId(1).GetLength(0), 0);
        }

        [TestMethod]
        public void D3TC2()
        {
            
        }

        [TestMethod]
        public void D3TC3()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 1);
            PatronDataManager.CheckOutDocument(2, 4);
            PatronDataManager.CheckOutDocument(2, 5);
            PatronDataManager.RenewDocument(1, 1);
            PatronDataManager.RenewDocument(2, 4);
            PatronDataManager.RenewDocument(2, 5);
            string date = LibrarianDataManager.GetCheckedByUserCopiesList(1)[0].ReturningDate;
            Assert.AreEqual(date, DateTime.Today.AddDays(56).ToShortDateString());            
            date = LibrarianDataManager.GetCheckedByUserCopiesList(4)[0].ReturningDate;
            Assert.AreEqual(date, DateTime.Today.AddDays(42).ToShortDateString());            
            date = LibrarianDataManager.GetCheckedByUserCopiesList(5)[0].ReturningDate;
            Assert.AreEqual(date, DateTime.Today.AddDays(14).ToShortDateString());
        }

        [TestMethod]
        public void D3TC4()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 1);
            PatronDataManager.CheckOutDocument(2, 4);
            PatronDataManager.CheckOutDocument(2, 5);
            LibrarianDataManager.SetOutstanding(true, 2);
            PatronDataManager.RenewDocument(1, 1);
            PatronDataManager.RenewDocument(2, 4);
            PatronDataManager.RenewDocument(2, 5);
            string date = LibrarianDataManager.GetCheckedByUserCopiesList(1)[0].ReturningDate;
            Assert.AreEqual(date, DateTime.Today.AddDays(56).ToShortDateString());
            date = LibrarianDataManager.GetCheckedByUserCopiesList(4)[0].ReturningDate;
            Assert.AreEqual(date, DateTime.Today.AddDays(21).ToShortDateString());
            date = LibrarianDataManager.GetCheckedByUserCopiesList(5)[0].ReturningDate;
            Assert.AreEqual(date, DateTime.Today.AddDays(7).ToShortDateString());
        }

        [TestMethod]
        public void D3TC5()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(3, 1);
            PatronDataManager.CheckOutDocument(3, 4);
            PatronDataManager.CheckOutDocument(3, 5);
            PatronDataManager.AddToQueue(3, 5);
            Assert.AreEqual(LibrarianDataManager.GetQueueToDocument(3)[0].CardNumber, 5);
        }

        [TestMethod]
        public void D3TC6()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(3, 1);
            PatronDataManager.CheckOutDocument(3, 2);
            PatronDataManager.CheckOutDocument(3, 4);
            PatronDataManager.AddToQueue(3, 4);
            PatronDataManager.CheckOutDocument(3, 5);
            PatronDataManager.AddToQueue(3, 5);
            PatronDataManager.CheckOutDocument(3, 4);
            PatronDataManager.AddToQueue(3, 3);
            Patron[] patrons = LibrarianDataManager.GetQueueToDocument(3);
            Assert.AreEqual(patrons[0].CardNumber, 4);
            Assert.AreEqual(patrons[1].CardNumber, 5);
            Assert.AreEqual(patrons[2].CardNumber, 3);
        }

        [TestMethod]
        public void D3TC7()
        {            
            D3TC6();
            LibrarianDataManager.SetOutstanding(true, 3);
            Assert.AreEqual(LibrarianDataManager.GetQueueToDocument(3).Length, 0);
            Assert.AreEqual(PatronDataManager.GetNotifications(1).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(2).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(3).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(4).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(5).Length, 1);
        }

        [TestMethod]
        public void D3TC8()
        {
            D3TC6();
            PatronDataManager.CheckOutDocument(3, 2);
        }
    }
}