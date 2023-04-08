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
    }
}
