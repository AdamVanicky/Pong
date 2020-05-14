using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pong;

namespace UnitTestPong
{
    [TestClass]
    public class UnitTest1
    {
        LeaderBoard LeaderBoard = new LeaderBoard();
        
        public UnitTest1() { }
        [TestMethod]
        public void Returns10_WithFile()
        {
            List<int> testList;
            int expectedLength = 10;
            string FileName = "Scores.txt";

            testList = LeaderBoard.FillLeaderBoard(FileName);

            Assert.IsTrue(expectedLength == testList.Count);
        }
        [TestMethod]
        public void Returns10_WithoutFile()
        {
            
        }
        [TestMethod]
        public void IsSorted()
        {

        }

       
    }
}
