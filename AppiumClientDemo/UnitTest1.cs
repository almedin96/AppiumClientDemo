using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using System;
using System.Threading;

namespace AppiumClientDemo
{
    public class Tests
    {
        private AppiumDriver<AndroidElement> _driver;

        [SetUp]
        public void Setup()
        {
            var appPath = @"C:/Users/User/Downloads/app-release (10).apk";
            // platform, device, application
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, appPath);
            //driverOption.AddAdditionalCapability("chromedriverExecutable", @"")
            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
            var contexts = ((IContextAware)_driver).Contexts;
            string webviewContext = null;
            for (var i = 0; i < contexts.Count; i++)
            {
                Console.WriteLine(contexts[i]);
                if(contexts[i].Contains("WEBVIEW"))
                {
                    webviewContext = contexts[i];
                    break;
                }
            }
            ((IContextAware)_driver).Context = webviewContext;
            Thread.Sleep(25000);
            _driver.FindElementByAccessibilityId("Explore the app first").Click();
            Thread.Sleep(25000);
            _driver.FindElementByAccessibilityId("Explore the app first").Click();
            Thread.Sleep(25000);

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}