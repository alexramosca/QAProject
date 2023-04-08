using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MySql.Data.MySqlClient;
using OpenQA.Selenium.Support.UI;


namespace QAProject
{
    internal class SiteTest
    {
        //Add the tests and the structures used by the tests

        //HOME01

        public static bool TestProfileLink(IWebDriver driver)
        {
            WebsiteElement.linkToYourProfile(driver).Click();
            if (driver.Url.Contains("http://10.157.123.12/site3/userpage.php?userId="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // SEARCH01
        public static bool TestSearchBar(IWebDriver driver)
        {
            WebsiteElement.txtSearch(driver).SendKeys("asdasdasdads");
            WebsiteElement.btnSearch(driver).Click();
            if(driver.Url.Contains("http://10.157.123.12/site3/search.php"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Login Method
        public static bool Login(IWebDriver driver, string screenName, string password)
        {
            try
            {
                WebsiteElement.txtScreenName(driver).SendKeys(screenName);
                WebsiteElement.txtPassword(driver).SendKeys(password);
                WebsiteElement.btnLogin(driver).Click();

                String output = WebsiteElement.GetAlertMessage(driver);
                WebsiteElement.AcceptAlert(driver);

                if (!output.Contains("Please provide a valid username and password"))
                {
                    return true;
                }
                return false;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

         
        }
        //MENU01 - HOME PAGE MENU
        public static bool TestMenu01(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");
                IWebElement btnHome = WebsiteElement.homeLink(driver);
                btnHome.Click();

                if (driver.Url.Contains("http://10.157.123.12/site3/index.php"))
                    return true;
                else return false;
            }
            catch {
                return false;
            }

        }
        //MENU02 - ELEMENTS PAGE  
        public static bool TestMenu02(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");
                IWebElement btnMoments = WebsiteElement.momentsLink(driver);
                string oldUrl = driver.Url;
                btnMoments.Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                string newUrl = driver.Url;
                string formatNewUrl = newUrl.Substring(0, newUrl.Length - 1);
                Console.WriteLine(formatNewUrl);
                

                if (oldUrl == formatNewUrl)
                    return false;
                else return true;
            }
            catch
            {
                return false;
            }

        }
        //MENU03 - TEST NOTIFICATIONS LINK
        public static bool TestMenu03(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");
                IWebElement btnHome = WebsiteElement.NotificationsLink(driver);
                btnHome.Click();

                if (driver.Url.Contains("http://10.157.123.12/site3/Notifications.php"))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }
        //MENU04 - TEST MESSAGES LINK
        public static bool TestMenu04(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");
                IWebElement btnHome = WebsiteElement.messagesLink(driver);
                btnHome.Click();

                if (driver.Url.Contains("http://10.157.123.12/site3/DirectMessage.php"))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }

        //MENU05 - TEST CONTACTUS LINK
        public static bool TestMenu05(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");
                IWebElement btnContact = WebsiteElement.contactUsLink(driver);
                btnContact.Click();

                if (driver.Url.Contains("http://10.157.123.12/site3/ContactUs.php"))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }

    }

}
