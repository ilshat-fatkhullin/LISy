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

        /// <summary>
        /// Action: Patron p checks out a copy of book b.
        /// Effect: Librarians can see that Patron p has one copy of book b and there is one copy of book b in the library.
        /// </summary>
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

            PatronDataManager.ReturnDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, PATRON_1_ID); 

            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Action: A patron 'p' checks out book by A.
        /// Effect: The system does not change its state. Maybe a message notifying the patron can read: the library does not have book 'b'
        /// </summary>
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

        /// <summary>
        /// Action: 'f' checks out book 'b'
        /// Effect: The book is checked out by 'f' with returning time of 4 weeks(from the day it was checked out)
        /// </summary>
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
                    Math.Abs((DateTime.Parse(c.ReturningDate) - DateTime.Now).TotalDays - Book.FACULTY_RETURN_TIME) < 0.1)
                {
                    flag = true;
                }
            }

            PatronDataManager.ReturnDocument(BOOK_ONE_COPY_NOT_BESTSELLER_NO_REFERENCE_ID, FACULTY_ID);

            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Action: 'f' checks out book 'b'
        /// Effect: The book is checked out by 'f' with returning time of 2 weeks(from the day it was checked out)
        /// </summary>
        [TestMethod]
        public void TestCase4()
        {
            
        }

        /// <summary>
        /// Action: Three patrons try to check out book A.
        /// Effect: Only first two patrons can check out the copy of book A.The third patron sees an empty list of books.
        /// </summary>        
        [TestMethod]
        public void TestCase5()
        {
            PatronDataManager.CheckOutDocument(BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID, PATRON_1_ID);
            PatronDataManager.CheckOutDocument(BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID, PATRON_2_ID);
            PatronDataManager.CheckOutDocument(BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID, PATRON_3_ID);

            Copy[] copies = LibrarianDataManager.GetAllCopiesList();

            bool checked1 = false, checked2 = false, checked3 = false;

            foreach (Copy c in copies)
            {
                if (c.DocumentID == BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID)
                {
                    if (c.PatronID == PATRON_1_ID)
                    {
                        checked1 = true;
                    }
                    if (c.PatronID == PATRON_2_ID)
                    {
                        checked2 = true;
                    }
                    if (c.PatronID == PATRON_3_ID)
                    {
                        checked3 = true;
                    }
                }
            }

            PatronDataManager.ReturnDocument(BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID, PATRON_1_ID);
            PatronDataManager.ReturnDocument(BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID, PATRON_2_ID);
            PatronDataManager.ReturnDocument(BOOK_TWO_COPY_BESTSELLER_NO_REFERENCE_ID, PATRON_3_ID);

            Assert.IsTrue(checked1 && checked2 && !checked3);
        }
    }
}
