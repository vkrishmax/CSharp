using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using TestProject.Framework;
using System.Drawing;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CommonVariable.DT_ = _Data.DateTIME();

            CommonVariable.TestName = "TC01";
            _Data.LogFile("**************** TestMethod1 **************");
            _Data.LogFile("Started Successfully");
            _Keys.Browserlaunch("http://www.cleartrip.com");
            _Keys.TypeIn("From_txtbx#.//*[@id='FromTag']","Chennai");
            _Keys.TypeIn("To_txtbx#.//*[@id='ToTag']","Mumbai");
            _Data.LogFile("Done Successfully");
        }
    }
}
