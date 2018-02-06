using System;
using LISy.Entities;
using LISy.Entities.Documents;
using LISy.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LISyTest.Integrated
{
    [TestClass]
    public class IntegratedTest
    {        
        private const long PATRON_1_ID = 1, PATRON_2_ID = 2, PATRON_3_ID = 3,
            FACULTY_ID = 1,
            STUDENT_ID = 2,
            BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID = 1,
            BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID = 2;

        [TestMethod]
        public void TestCase1()
        {            
            PatronDataManager.CheckOutDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, PATRON_1_ID);

            Copy[] copies = LibrarianDataManager.GetAllCopiesList();
            bool flag = false;

            foreach (var c in copies)
            {
                if (c.PatronID == PATRON_1_ID && c.DocumentID == BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID)
                {
                    flag = true;
                    break;                    
                }
            }

            PatronDataManager.ReturnDocument(PATRON_1_ID, BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID);         

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestCase2()
        {
            Copy[] oldCopies = LibrarianDataManager.GetAllCopiesList();
            PatronDataManager.CheckOutDocument(int.MaxValue, PATRON_1_ID);
            Copy[] newCopies = LibrarianDataManager.GetAllCopiesList();
            bool flag = false;
            for (int i = 0; i < oldCopies.Length; i++)            
            {
                if (oldCopies[i].Equals(newCopies[i]))
                {
                    flag = true;
                    break;                    
                }
            }
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestCase3()
        {
            PatronDataManager.CheckOutDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, FACULTY_ID);

            Copy[] copies = LibrarianDataManager.GetAllCopiesList();
            bool flag = false;

            foreach (var c in copies)
            {
                if (c.PatronID == FACULTY_ID &&
                    c.DocumentID == BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID &&
                    Math.Abs((DateTime.Parse(c.ReturningTime) - DateTime.Now).TotalDays - Book.FACULTY_RETURN_TIME) < 0.1)
                {
                    flag = true;
                }
            }

            PatronDataManager.ReturnDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, FACULTY_ID);

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestCase4()
        {
            PatronDataManager.CheckOutDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, PATRON_1_ID);
            PatronDataManager.CheckOutDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, PATRON_2_ID);
            PatronDataManager.CheckOutDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, PATRON_3_ID);

            Copy[] copies = LibrarianDataManager.GetAllCopiesList();

            bool checked1 = false, checked2 = false, checked3 = true;

            foreach (Copy c in copies)
            {
                checked1 = c.
            }
        }

        [TestMethod]
        public void TestCase5()
        {

        }
    }
}
