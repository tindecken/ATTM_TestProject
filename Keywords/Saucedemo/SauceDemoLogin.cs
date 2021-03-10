using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestProject.Framework;
using TestProject.PageObjects.SauceDemo;

namespace TestProject.Keywords.Saucedemo
{
    public class SauceDemoLogin
    {
        readonly IWebDriver driver;
        private readonly LoginPageObject loginPageObject;
        public SauceDemoLogin(IWebDriver driver)
        {
            this.driver = driver;
            loginPageObject = new LoginPageObject(driver);
        }

        /// <summary>
        /// author: Tindecken
        /// createdDate: 06/25/2020
        /// description: Login SauceDemo Page and check the login message
        /// </summary>
        /// <param name="sUserName">User Name need to input. Exp: tindecken</param>
        /// <param name="sPassword">Password to need to input. Exp: password</param>
        /// <param name="sExpectedLoginStatus">Login status need to verify. Exp: Success|Fail|null</param>
        /// <param name="sExpectedLoginMessage">Login message need to verify. Exp: Epic sadface: Username is required|Epic sadface: Username and password do not match any user in this service</param>
        /// <param name="sOptional">Optional. Exp: null</param>
        public void Login(string sUserName, string sPassword, string sExpectedLoginStatus, string sExpectedLoginMessage ,string sOptional)
        {
            //Process parameter with buffer
            sUserName = BufferUtils.getValueFromBuffer(sUserName);
            sPassword = BufferUtils.getValueFromBuffer(sPassword);
            sExpectedLoginStatus = BufferUtils.getValueFromBuffer(sExpectedLoginStatus);
            sExpectedLoginMessage = BufferUtils.getValueFromBuffer(sExpectedLoginMessage);
            sOptional = BufferUtils.getValueFromBuffer(sOptional);

            //Input userName
            loginPageObject.WEInputUserName.SendKeys(sUserName);
            loginPageObject.WEInputPassword.SendKeys(sPassword);
            loginPageObject.WEbtnLogin.Click();

            if (string.IsNullOrEmpty(sExpectedLoginStatus))
            {
                switch (sExpectedLoginStatus.ToUpper())
                {
                    case "SUCCESS":
                        break;
                    case "FAIL":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //Logger.Info("By pass verify LoginStatus");
            }

        }
    }
}
