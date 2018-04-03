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
        }
    }
}
