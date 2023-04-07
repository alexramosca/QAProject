using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MySql.Data.MySqlClient;

namespace QAProject
{
    internal class SiteTest
    {
        //Add the tests and the structures used by the tests
        public static bool TWEET01(IWebDriver driver) 
        {
            IWebElement txtUsername= WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();

            IWebElement txtTweet = WebsiteElement.txtTweet(driver);
            txtTweet.Click();
            txtTweet.SendKeys("");
            

            IWebElement txtBtnSendTweet = WebsiteElement.btnSendTweet(driver);
            txtBtnSendTweet.Click();
            txtBtnSendTweet.Click();
            

            try
            {
                driver.SwitchTo().Alert().Accept();
                return false; // Alert was present to post tweet
            }
            catch (NoAlertPresentException)
            {
                return true; // Alert was not present so didn't post tweet
            }
                        
        }




        public static bool TWEET02(IWebDriver driver)
        {
            IWebElement txtUsername = WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();

            IWebElement txtTweet = WebsiteElement.txtTweet(driver);
            txtTweet.Click();
            txtTweet.SendKeys("h2");


            IWebElement txtBtnSendTweet = WebsiteElement.btnSendTweet(driver);
            txtBtnSendTweet.Click();
            txtBtnSendTweet.Click();


            try
            {
                driver.SwitchTo().Alert().Accept();
                return false; // Alert was present to post tweet
            }
            catch (NoAlertPresentException)
            {
                return true; // Alert was not present so didn't post tweet
            }

        }












    }
}
