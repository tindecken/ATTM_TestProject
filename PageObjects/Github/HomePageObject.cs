using OpenQA.Selenium;


namespace TestProject.PageObjects.Github
{
    public class HomePageObject
    {
        private IWebDriver driver;
        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement WEAvatar => driver.FindElement(By.XPath("//a[@href='/login']"));
    }
}
