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
        List<int> testList = new List<int>();
        public UnitTest1() { }
        [TestMethod]
        public void Returns10_WithFile()
        {
            
            int expectedLength = 10;
            string FileName = "Scores.txt";

            testList = LeaderBoard.FillLeaderBoard(FileName);

            Assert.IsTrue(expectedLength == testList.Count);
        }
        [TestMethod]
        public void Returns10_WithoutFile()
        {
            int expectedLength = 10;
            string FileName = "";

            testList = LeaderBoard.FillLeaderBoard(FileName);

            Assert.IsTrue(expectedLength == testList.Count);
        }
        [TestMethod]
        public void IsSorted()
        {
            bool expectedResult = true;
            bool Result;

            Result = LeaderBoard.arraySorted(testList.ToArray());

            Assert.IsTrue(Result == expectedResult);
        }

       
    }
}
