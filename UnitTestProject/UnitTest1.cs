using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaliburnDemo;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new ShellViewModel();
            var expectedState = new Dictionary<string, object>
            {
                { "I1", 100 },
                { "I2", 200 },
                { "Str1", "Test" }
            };
            var tester = new Testerment.ViewModelTestHelper<ShellViewModel>();
            tester.Test(nameof(sut.Click1), null, expectedState, sut);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sut = new ShellViewModel();
            var expectedState = new Dictionary<string, object>
            {
                { "I1", 10 },
                { "I2", 200 },
                { "Str1", "Test" }
            };
            var tester = new Testerment.ViewModelTestHelper<ShellViewModel>();
            tester.Test(nameof(sut.Click1), null, expectedState, sut);
        }
    }
}
