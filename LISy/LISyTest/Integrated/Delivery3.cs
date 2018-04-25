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

            LibrarianDataManager.AddLibrarian(new Librarian(
                "LibrarianName",
                "LibrarianSurname",
                "30006",
                "LibrarianAddress",
                3
                ), "librarian_1", "12345");

            LibrarianDataManager.LibrarianId = 2;

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
        }

        [TestMethod]
        public void D3TC1()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 3);
            PatronDataManager.CheckOutDocument(2, 3);
            LibrarianDataManager.ReturnDocument(2, 3);
            Copy copy = LibrarianDataManager.GetCheckedByUserCopiesList(3)[0];
            Assert.AreEqual(copy.DocumentId, 1);       
            Assert.AreEqual(DateManager.GetDate(copy.ReturningDate), DateTime.Today.AddDays(28));
            Assert.AreEqual(LibrarianDataManager.GetFinesByPatronId(3).GetLength(0), 0);
        }

        [TestMethod]
        public void D3TC2()
        {
            
        }

        [TestMethod]
        public void D3TC3()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 3);
            PatronDataManager.CheckOutDocument(2, 6);
            PatronDataManager.CheckOutDocument(2, 7);
            PatronDataManager.RenewDocument(1, 3);
            PatronDataManager.RenewDocument(2, 6);
            PatronDataManager.RenewDocument(2, 7);
            DateTime date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(3)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(56));
            date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(6)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(42));            
            date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(7)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(14));
        }

        [TestMethod]
        public void D3TC4()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 3);
            PatronDataManager.CheckOutDocument(2, 6);
            PatronDataManager.CheckOutDocument(2, 7);
            LibrarianDataManager.SetOutstanding(true, 2);
            PatronDataManager.RenewDocument(1, 3);
            PatronDataManager.RenewDocument(2, 6);
            PatronDataManager.RenewDocument(2, 7);
            DateTime date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(3)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(56));
            date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(6)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(21));            
            date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(7)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(7));
        }

        [TestMethod]
        public void D3TC5()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(3, 3);
            PatronDataManager.CheckOutDocument(3, 6);
            PatronDataManager.CheckOutDocument(3, 7);
            PatronDataManager.AddToQueue(3, 7);
            Assert.AreEqual(LibrarianDataManager.GetQueueToDocument(3)[0].CardNumber, 7);
        }

        [TestMethod]
        public void D3TC6()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(3, 3);
            PatronDataManager.CheckOutDocument(3, 4);
            PatronDataManager.CheckOutDocument(3, 6);
            PatronDataManager.AddToQueue(3, 6);
            PatronDataManager.CheckOutDocument(3, 7);
            PatronDataManager.AddToQueue(3, 7);
            PatronDataManager.CheckOutDocument(3, 6);
            PatronDataManager.AddToQueue(3, 5);
            Patron[] patrons = LibrarianDataManager.GetQueueToDocument(3);
            Assert.AreEqual(patrons[0].CardNumber, 6);
            Assert.AreEqual(patrons[1].CardNumber, 7);
            Assert.AreEqual(patrons[2].CardNumber, 5);
        }

        [TestMethod]
        public void D3TC7()
        {            
            D3TC6();
            LibrarianDataManager.SetOutstanding(true, 3);
            Assert.AreEqual(LibrarianDataManager.GetQueueToDocument(3).Length, 0);
            Assert.AreEqual(PatronDataManager.GetNotifications(3).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(4).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(5).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(6).Length, 1);
            Assert.AreEqual(PatronDataManager.GetNotifications(7).Length, 1);
        }

        [TestMethod]
        public void D3TC8()
        {
            D3TC6();
            LibrarianDataManager.ReturnDocument(3, 4);
            Assert.AreEqual(PatronDataManager.GetNotifications(6).Length, 1);
            Assert.AreEqual(LibrarianDataManager.GetCheckedByUserCopiesList(4).Length, 0);
            Patron[] patrons = LibrarianDataManager.GetQueueToDocument(3);
            Assert.AreEqual(patrons[0].CardNumber, 6);
            Assert.AreEqual(patrons[1].CardNumber, 7);
            Assert.AreEqual(patrons[2].CardNumber, 5);
        }

        [TestMethod]
        public void D3TC9()
        {
            D3TC6();
            PatronDataManager.RenewDocument(3, 3);
            DateTime date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(3)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(56));
        }

        [TestMethod]
        public void D3TC10()
        {
            Initialization();
            PatronDataManager.CheckOutDocument(1, 3);
            PatronDataManager.RenewDocument(1, 3);
            PatronDataManager.CheckOutDocument(1, 7);
            PatronDataManager.RenewDocument(1, 7);
            DateTime date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(3)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(56));
            date = DateManager.GetDate(LibrarianDataManager.GetCheckedByUserCopiesList(7)[0].ReturningDate);
            Assert.AreEqual(date, DateTime.Today.AddDays(14));
        }
    }
}