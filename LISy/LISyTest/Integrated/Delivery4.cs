using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Entities.Notifications;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;
using LISy.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LISyTest.Integrated
{
    [TestClass]
    public class Delivery4
    {
        private const int L1 = 2,
            L2 = 3,
            L3 = 4,
            P1 = 5,
            P2 = 6,
            P3 = 7,
            S = 8,
            V = 9,
            D1 = 1,
            D2 = 2,
            D3 = 3;

        private void InitializeLibrarians()
        {
            LibrarianDataManager.AddLibrarian(new Librarian(
                "Eugenia",
                "Rama",
                "89999999999",
                "LibrarianAddress",
                1
                ), "librarian_1", "12345");
            LibrarianDataManager.AddLibrarian(new Librarian(
                "Luie",
                "Ramos",
                "89999999999",
                "LibrarianAddress",
                2
                ), "librarian_2", "12345");
            LibrarianDataManager.AddLibrarian(new Librarian(
                "Ramon",
                "Valdez",
                "89999999999",
                "LibrarianAddress",
                3
                ), "librarian_3", "12345");
        }

        private void CreatePatrons(int librarianId)
        {
            LibrarianDataManager.LibrarianId = librarianId;

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

        private void CreateDocuments(int librarianId)
        {
            LibrarianDataManager.LibrarianId = librarianId;

            LibrarianDataManager.AddBook(new Book(
                "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest and Clifford Stein",
                "Introduction to Algorithms",
                "MIT Press",
                "Third edition",
                2009,
                false,
                "Algorithms, Data Structures, Complexity, Computational Theory",
                "",
                5000
                ));
            LibrarianDataManager.AddBook(new Book(
                "Niklaus Wirth",
                "Algorithms + Data Structures = Programs",
                "Prentice Hall PTR",
                "First edition",
                1978,
                false,
                "Algorithms, Data Structures, Search Algorithms, Pascal",
                "",
                5000
                ));
            LibrarianDataManager.AddBook(new Book(
                "Donald E. Knuth",
                "The Art of Computer Programming",
                "AddisonWesley Longman Publishing Co., Inc",
                "Third edition",
                1997,
                false,
                "Algorithms, Combinatorial Algorithms, Recursion",
                "",
                5000
                ));
        }

        private void Initialize()
        {
            LibrarianDataManager.ClearAll();

            InitializeLibrarians();
            CreatePatrons(L3);
            CreateDocuments(L3);
        }

        [TestMethod]
        public void D4TC1()
        {

        }

        [TestMethod]
        public void D4TC2()
        {
            LibrarianDataManager.ClearAll();

            InitializeLibrarians();
            Assert.AreEqual(LibrarianDataManager.GetNumberOfUsers(), 4);
        }

        [TestMethod]
        public void D4TC3()
        {
            D4TC2();
            CreateDocuments(L3);
            LibrarianDataManager.LibrarianId = L1;
            LibrarianDataManager.AddCopies(3, new Copy(D1, 1, 1));
            LibrarianDataManager.AddCopies(3, new Copy(D2, 1, 1));
            LibrarianDataManager.AddCopies(3, new Copy(D3, 1, 1));
            Assert.AreEqual(LibrarianDataManager.GetNumberOfCopies(), 0);
        }

        [TestMethod]
        public void D4TC4()
        {
            D4TC2();
            CreateDocuments(L3);
            LibrarianDataManager.LibrarianId = L2;
            LibrarianDataManager.AddCopies(3, new Copy(D1, 1, 1));
            LibrarianDataManager.AddCopies(3, new Copy(D2, 1, 1));
            LibrarianDataManager.AddCopies(3, new Copy(D3, 1, 1));
            CreatePatrons(L2);

            Assert.AreEqual(LibrarianDataManager.GetNumberOfCopies(), 9);
            Assert.AreEqual(LibrarianDataManager.GetNumberOfUsers(), 9);
        }

        [TestMethod]
        public void D4TC5()
        {
            D4TC4();
            LibrarianDataManager.LibrarianId = L3;
            long copyId = 0;
            foreach (Copy c in LibrarianDataManager.GetAllCopiesList())
            {
                if (c.DocumentId == D1)
                {
                    copyId = c.Id;
                    break;
                }
            }
            LibrarianDataManager.DeleteCopy(copyId);
            LibrarianDataManager.LibrarianId = L2;
            int numberOfCopies = 0;
            foreach (Copy c in LibrarianDataManager.GetAllCopiesList())
            {
                if (c.DocumentId == D1)
                    numberOfCopies++;
            }
            Assert.AreEqual(numberOfCopies, 2);
        }

        [TestMethod]
        public void D4TC6()
        {
            D4TC4();
            PatronDataManager.PatronId = P1;
            PatronDataManager.CheckOutDocument(D3, P1);
            PatronDataManager.PatronId = P2;
            PatronDataManager.CheckOutDocument(D3, P2);
            PatronDataManager.PatronId = S;
            PatronDataManager.CheckOutDocument(D3, S);
            PatronDataManager.PatronId = V;
            PatronDataManager.AddToQueue(D3, V);
            PatronDataManager.PatronId = P3;
            PatronDataManager.AddToQueue(D3, P3);
            LibrarianDataManager.LibrarianId = L1;
            LibrarianDataManager.SetOutstanding(true, D3);
            Assert.AreEqual(LibrarianDataManager.GetQueueToDocument(D3).Length, 2);
        }

        [TestMethod]
        public void D4TC7()
        {
            D4TC4();
            PatronDataManager.PatronId = P1;
            PatronDataManager.CheckOutDocument(D3, P1);
            PatronDataManager.PatronId = P2;
            PatronDataManager.CheckOutDocument(D3, P2);
            PatronDataManager.PatronId = S;
            PatronDataManager.CheckOutDocument(D3, S);
            PatronDataManager.PatronId = V;
            PatronDataManager.AddToQueue(D3, V);
            PatronDataManager.PatronId = P3;
            PatronDataManager.AddToQueue(D3, P3);
            LibrarianDataManager.LibrarianId = L3;
            LibrarianDataManager.SetOutstanding(true, D3);
            Assert.AreEqual(LibrarianDataManager.GetQueueToDocument(D3).Length, 0);
            PatronDataManager.PatronId = S;
            Assert.AreEqual(PatronDataManager.GetNotifications(S)[0].Message,
                "You have to return document The Art of Computer Programming.");
            PatronDataManager.PatronId = P1;
            Assert.AreEqual(PatronDataManager.GetNotifications(P1)[0].Message,
                "You have to return document The Art of Computer Programming.");
            PatronDataManager.PatronId = P2;
            Assert.AreEqual(PatronDataManager.GetNotifications(P2)[0].Message,
                "You have to return document The Art of Computer Programming.");
            PatronDataManager.PatronId = V;
            Assert.AreEqual(PatronDataManager.GetNotifications(V)[0].Message,
                "The Art of Computer Programming is not available now.");
            Assert.AreEqual(PatronDataManager.GetNotifications(P3)[0].Message,
                "The Art of Computer Programming is not available now.");
        }

        [TestMethod]
        public void D4TC8()
        {
            D4TC6();
            LogContent[] logs = LibrarianDataManager.GetAllLogs();

            Assert.AreEqual(logs[0].Log, "Admin 1 added librarian Eugenia");
            Assert.AreEqual(logs[1].Log, "Admin 1 added librarian Luie");
            Assert.AreEqual(logs[2].Log, "Admin 1 added librarian Ramon");
            Assert.AreEqual(logs[3].Log, "Librarian 4 added book Introduction to Algorithms");
            Assert.AreEqual(logs[4].Log, "Librarian 4 added book Algorithms + Data Structures = Programs");
            Assert.AreEqual(logs[5].Log, "Librarian 4 added book The Art of Computer Programming");
            Assert.AreEqual(logs[6].Log, "Librarian 3 added 3 copies for document 1");
            Assert.AreEqual(logs[7].Log, "Librarian 3 added 3 copies for document 2");
            Assert.AreEqual(logs[8].Log, "Librarian 3 added 3 copies for document 3");
            Assert.AreEqual(logs[9].Log, "Librarian 3 added faculty Sergey");
            Assert.AreEqual(logs[10].Log, "Librarian 3 added faculty Nadia");
            Assert.AreEqual(logs[11].Log, "Librarian 3 added faculty Elvira");
            Assert.AreEqual(logs[12].Log, "Librarian 3 added student Andrey");
            Assert.AreEqual(logs[13].Log, "Librarian 3 added guest Veronika");
            Assert.AreEqual(logs[14].Log, "Patron 5 checked out document with id 3");
            Assert.AreEqual(logs[15].Log, "Patron 6 checked out document with id 3");
            Assert.AreEqual(logs[16].Log, "Patron 8 checked out document with id 3");
            Assert.AreEqual(logs[17].Log, "Patron 9 has been added to queue to document with id 3");
            Assert.AreEqual(logs[18].Log, "Patron 7 has been added to queue to document with id 3");            
        }

        [TestMethod]
        public void D4TC9()
        {
            D4TC7();

            LogContent[] logs = LibrarianDataManager.GetAllLogs();
            
            Assert.AreEqual(logs[0].Log, "Admin 1 added librarian Eugenia");
            Assert.AreEqual(logs[1].Log, "Admin 1 added librarian Luie");
            Assert.AreEqual(logs[2].Log, "Admin 1 added librarian Ramon");
            Assert.AreEqual(logs[3].Log, "Librarian 4 added book Introduction to Algorithms");
            Assert.AreEqual(logs[4].Log, "Librarian 4 added book Algorithms + Data Structures = Programs");
            Assert.AreEqual(logs[5].Log, "Librarian 4 added book The Art of Computer Programming");
            Assert.AreEqual(logs[6].Log, "Librarian 3 added 3 copies for document 1");
            Assert.AreEqual(logs[7].Log, "Librarian 3 added 3 copies for document 2");
            Assert.AreEqual(logs[8].Log, "Librarian 3 added 3 copies for document 3");
            Assert.AreEqual(logs[9].Log, "Librarian 3 added faculty Sergey");
            Assert.AreEqual(logs[10].Log, "Librarian 3 added faculty Nadia");
            Assert.AreEqual(logs[11].Log, "Librarian 3 added faculty Elvira");
            Assert.AreEqual(logs[12].Log, "Librarian 3 added student Andrey");
            Assert.AreEqual(logs[13].Log, "Librarian 3 added guest Veronika");
            Assert.AreEqual(logs[14].Log, "Patron 5 checked out document with id 3");
            Assert.AreEqual(logs[15].Log, "Patron 6 checked out document with id 3");
            Assert.AreEqual(logs[16].Log, "Patron 8 checked out document with id 3");
            Assert.AreEqual(logs[17].Log, "Patron 9 has been added to queue to document with id 3");
            Assert.AreEqual(logs[18].Log, "Patron 7 has been added to queue to document with id 3");
            Assert.AreEqual(logs[19].Log, "Librarian 4 seted outstanding request to document with id 3");
        }

        [TestMethod]
        public void D4TC10()
        {
            D4TC4();
            PatronDataManager.PatronId = V;
            Document[] documents = SearchManager.Search(LibrarianDataManager.GetAllBooksList(),
                "Introduction to Algorithms",
                typeof(Book),
                false,
                true,
                false);
            Assert.AreEqual(documents[0].Title, "Introduction to Algorithms");
        }

        [TestMethod]
        public void D4TC11()
        {
            D4TC4();
            PatronDataManager.PatronId = V;
            Document[] documents = SearchManager.Search(LibrarianDataManager.GetAllBooksList(),
                "Algorithms",
                typeof(Book),
                false,
                true,
                false);
            Assert.AreEqual(documents[0].Title, "Introduction to Algorithms");
            Assert.AreEqual(documents[1].Title, "Algorithms + Data Structures = Programs");            
        }

        [TestMethod]
        public void D4TC12()
        {
            D4TC4();
            PatronDataManager.PatronId = V;
            Document[] documents = SearchManager.Search(LibrarianDataManager.GetAllBooksList(),
                "Algorithms",
                typeof(Book),
                false,
                false,
                true);
            Assert.AreEqual(documents[0].Title, "Introduction to Algorithms");
            Assert.AreEqual(documents[1].Title, "Algorithms + Data Structures = Programs");
            Assert.AreEqual(documents[2].Title, "The Art of Computer Programming");            
        }
    }
}
