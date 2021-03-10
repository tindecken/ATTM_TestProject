using OpenQA.Selenium;

namespace TestProject.PageObjects.Github
{
    public class LoginPageObject
    {
        private readonly IWebDriver driver;
        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement WEinputName => driver.FindElement(By.Id("login_field"));

        public IWebElement WEinputPassword => driver.FindElement(By.Id("password"));

        public IWebElement WEbtnSignIn => driver.FindElement(By.XPath("//input[@value='Sign in']"));
        public string sLoginErrorMessage => driver.FindElement(By.XPath("//div[contains(@class,'flash-error')]")).Text;
    }
}
