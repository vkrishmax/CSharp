using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject.Framework
{
    public class _Keys
    {
        public static IWebDriver dr;
        public static void Browserlaunch(String URL)
        {
            try
            {
             dr    = new FirefoxDriver();
            dr.Navigate().GoToUrl(URL);
            Thread.Sleep(3000);
            
            _Data.LogFile("Successfully launched the Browser with URL : " + URL);
            }
            catch(Exception e)
            {
                _Data.LogFile("Unable to launch the Browser");
                Assert.Fail;
            }

        }

        public static void TypeIn(String _locator,String Value)
        {
            String[] a = _locator.Split('#');
            String XPATH = a[1];
            String Element = a[0];
            try
            {
                dr.FindElement(By.XPath(XPATH)).Clear();
            dr.FindElement(By.XPath(XPATH)).SendKeys(Value);
            _Data.LogFile("Type : "+Value+" in " + Element);
            }
            catch(Exception e)
            {
                _Data.LogFile("Unable to perform Type action "+Element);
                Assert.Fail;
            }

        }

        public static void _Select(String _locator,String Value)
        {
            String[] a = _locator.Split('#');
            String XPATH = a[1];
            String Element = a[0];
            try
            {
                IWebElement drp = dr.FindElement(By.XPath(XPATH));
                new SelectElement(drp).SelectByValue(Value);
                _Data.LogFile("Select : "+Value+" in " + Element +" dropdown");
            }
            catch(Exception e)
            {
                _Data.LogFile("Unable to perform select action - "+Element);
                Assert.Fail;
            }
        }
        
        public static void _VerifyElement(String _locator)
        {
            String[] a = _locator.Split('#');
            String XPATH = a[1];
            String Element = a[0];
            try
            {
                if(dr.FindElement(By.XPath(XPATH)).Displayed)
                {
                    _Data.LogFile("Verified the expected Element "+ Element);
                }
            }
            catch(Exception e)
            {
                   _Data.LogFile("Expected Element is not found - "+ Element);
                   Assert.Fail;
            }
        }
        
    }
}
