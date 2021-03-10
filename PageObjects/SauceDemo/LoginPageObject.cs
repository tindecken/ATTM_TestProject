using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.PageObjects.SauceDemo
{
    public class LoginPageObject
    {
        private IWebDriver driver;
        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement WEInputUserName => driver.FindElement(By.Id("user-name"));
        public IWebElement WEInputPassword => driver.FindElement(By.Id("password"));
        public IWebElement WEbtnLogin => driver.FindElement(By.XPath("//input[@type='submit' and @value='LOGIN']"));
        public IWebElement WEtxtError => driver.FindElement(By.XPath("//h3[@data-test='error']"));

    }
}
