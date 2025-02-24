﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UWP
{
    [TestClass]
    public class InvalidIputTests
    {

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            AppManager.StartApp();
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            AppManager.StopApp();
        }

        [TestCleanup]
        public void ClearEntries()
        {
            var mainPage = new MainPage();
            mainPage.ClearAllEntries();
        }

        [TestMethod]
        public void ClickRunWithEmptyEntries()
        {
            var mainPage = new MainPage();

            mainPage.ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(result, MainPage.InvalidValues);
        }

        [TestMethod]
        public void ClickRunWithOneEmptyEntry()
        {
            var mainPage = new MainPage();
            var before = mainPage.GetResult();
            mainPage.SetFirstSide("1")
                .SetSecondSide("1")
                .ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(result, MainPage.InvalidValues);
        }

        [TestMethod]
        public void StringInEntries()
        {
            var mainPage = new MainPage();
            var before = mainPage.GetResult();
            mainPage.SetFirstSide("first")
                .SetSecondSide("second")
                .SetThirdSide("third")
                .ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(result, MainPage.InvalidValues);
        }

        [TestMethod]
        public void StringAndNumberInEntries()
        {
            var mainPage = new MainPage();
            var before = mainPage.GetResult();
            mainPage.SetFirstSide("1f")
                .SetSecondSide("s2")
                .SetThirdSide("t3h")
                .ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(result, MainPage.InvalidValues);
        }

        [TestMethod]
        public void NegativeNumbers()
        {
            var mainPage = new MainPage();
            mainPage.SetFirstSide("-1")
                .SetSecondSide("-1")
                .SetThirdSide("-1")
                .ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(result, MainPage.InvalidValues);
        }

        [TestMethod]
        public void FloatNumbers()
        {
            var mainPage = new MainPage();
            mainPage.SetFirstSide("1.3")
                .SetSecondSide("1.3")
                .SetThirdSide("1.3")
                .ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(result, MainPage.InvalidValues);
        }

        [TestMethod]
        public void InvalidTriangleWithZeroSides()
        {
            var mainPage = new MainPage();
            mainPage.SetFirstSide("0")
                .SetSecondSide("0")
                .SetThirdSide("0")
                .ClickRunButton();
            var result = mainPage.GetResult();
            Assert.AreEqual(MainPage.InvalidValues, result);
        }

    }
}
