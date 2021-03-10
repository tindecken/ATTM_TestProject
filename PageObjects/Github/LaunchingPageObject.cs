using OpenQA.Selenium;


namespace TestProject.PageObjects.Github
{
    public class LaunchingPageObject
    {
        private IWebDriver driver;
        public LaunchingPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement WEbtnLogin => driver.FindElement(By.XPath("//a[@href='/login']"));
    }
}
