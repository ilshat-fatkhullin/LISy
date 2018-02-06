using System;
using LISy.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LISyTest.Integrated
{
    [TestClass]
    public class IntegratedTest
    {        
        [TestMethod]
        public void TestCase1()
        {
            long documentId = 1;
            long patronId = 1;

            PatronDataManager.CheckOutDocument(patronId, documentId);



            PatronDataManager.ReturnDocument(patronId, documentId);
        }
    }
}
