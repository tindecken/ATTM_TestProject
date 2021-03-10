using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.Generic;

namespace TestProject.Framework.WrapperFactory
{
    class WebDriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static readonly ChromeOptions chromeOptions = new ChromeOptions();

        public static IWebDriver Driver1 { get; set; }

        public static IWebDriver Driver2 { get; set; }

        public static IWebDriver Driver3 { get; set; }
        public static IWebDriver Driver { get; internal set; }

        public static void InitBrowser(string browserName)
        {
            chromeOptions.AddArgument("--window-size=1300,800");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            switch (browserName)
            {
                case "Firefox":
                    if (Driver1 == null)
                    {
                        Driver1 = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver1);
                    }
                    break;

                case "IE":
                    if (Driver1 == null)
                    {
                        Driver1 = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver1);
                    }
                    break;

                case "Chrome1":
                    if (Drivers.ContainsKey("Chrome1"))
                    {
                        Drivers.Remove("Chrome1");
                    }
                    if (Driver1 == null)
                    {
                        Driver1 = new ChromeDriver(ProjectConstant.sWebDriverPath, chromeOptions);
                        Drivers.Add("Chrome1", Driver1);
                    }
                    break;
                case "Chrome2":
                    if (Drivers.ContainsKey("Chrome2"))
                    {
                        Drivers.Remove("Chrome2");
                    }
                    if (Driver2 == null)
                    {
                        Driver2 = new ChromeDriver(ProjectConstant.sWebDriverPath, chromeOptions);
                        Drivers.Add("Chrome2", Driver2);
                    }
                    break;
                case "Chrome3":
                    if (Drivers.ContainsKey("Chrome3"))
                    {
                        Drivers.Remove("Chrome3");
                    }
                    if (Driver3 == null)
                    {
                        Driver3 = new ChromeDriver(ProjectConstant.sWebDriverPath, chromeOptions);
                        Drivers.Add("Chrome3", Driver3);
                    }
                    break;
            }
        }


        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
