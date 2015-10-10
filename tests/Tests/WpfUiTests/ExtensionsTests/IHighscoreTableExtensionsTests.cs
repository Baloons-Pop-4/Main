namespace Tests.WpfUiTests.ExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.GraphicUserInterface.Gadgets;
    using BalloonsPop.Highscore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IHighscoreTableExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIfToStringListsThrowsWithNullCaller()
        {
            IHighscoreTable nullTable = null;
            nullTable.ToStringLists();
        }

        [TestMethod]
        public void MyTestMethod()
        {
        }

        [TestMethod]
        public void TestIfToStringListsCorrectlyReturnsAHighscoreTableAsStringLists()
        {
            var table = new HighscoreTable();

            var sampleStringTable = new List<List<string>>() 
            {
                new List<string>()
                {
                    "tosho", "8"
                },
                new List<string>()
                {
                    "gosho", "28"
                },
                new List<string>()
                {
                    "pesho", "30"
                }
            };

            foreach (var record in sampleStringTable)
            {
                var score = new PlayerScore(record[0], int.Parse(record[1]), DateTime.Now);
            }

            var asStringLists = table.ToStringLists();

            for (int i = 0, length = asStringLists.Count; i < length; i++)
            {
                for (int j = 0, length2 = asStringLists[i].Count; j < length2; j++)
                {
                    Assert.AreEqual(sampleStringTable[i][j], asStringLists[i][j]);
                }
            }
        }
    }
}
