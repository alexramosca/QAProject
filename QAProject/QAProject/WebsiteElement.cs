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
    internal class WebsiteElement
    {
        //Add Webelements here, each method must have a webdriver called driver as argument

        /* The following method will retrieve the message on the alert the website generates.
         * Please remember to use this method after you click the send button, or when expecting the alert to be displayed.
           After you use GetAlertMessage you can call AcceptAlert to dismiss it.
        */
        public static string GetAlertMessage(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            string message = alert.Text;
            return message;
        }
        public static void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        //Login Page

        public static IWebElement txtScreenName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("username"));
            return element;
        }
        public static IWebElement txtPassword(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("password"));
            return element;
        }
        public static IWebElement signUpLink(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("body > div > div > div:nth-child(2) > p > a"));
            return element;
        }
        public static IWebElement btnLogin(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("button"));
            return element;
        }

        // Sign Up Page

        public static IWebElement menuIndexLink(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > a"));
            return element;
        }
        public static IWebElement txtFirstName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("firstname"));
            return element;
        }
        public static IWebElement txtLastName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("lastname"));
            return element;
        }
        public static IWebElement txtEmail(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("email"));
            return element;
        }
        public static IWebElement txtSignUpScreenName(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("username"));
            return element;
        }
        public static IWebElement txtSignUpPassword(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("password"));
            return element;
        }
        public static IWebElement txtConfirmPassword(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("confirm"));
            return element;
        }
        public static IWebElement txtPhoneNumber(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("phone"));
            return element;
        }
        public static IWebElement txtAddress(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("address"));
            return element;
        }
        public static IWebElement selectProvince(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("province"));
            return element;
        }
        public static IWebElement txtUrl(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("url"));
            return element;
        }
        public static IWebElement txtDescription(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("desc"));
            return element;
        }
        public static IWebElement txtLocation(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("location"));
            return element;
        }
        public static IWebElement btnRegister(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("button"));
            return element;
        }

        //Index Page (Once logged in)

        //Index Page - Menu

        public static IWebElement homeLink(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > ul > li:nth-child(1) > a"));
            return element;
        }
        public static IWebElement momentsLink(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > ul > li:nth-child(2) > a"));
            return element;
        }
        public static IWebElement messagesLink(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > ul > li:nth-child(4) > a"));
            return element;
        }
        public static IWebElement contactUsLink(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > ul > li:nth-child(5) > a"));
            return element;
        }
        public static IWebElement txtSearch(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("search"));
            return element;
        }
        public static IWebElement btnSearch(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > form > button"));
            return element;
        }
        public static IWebElement btnProfile(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("dropdown01"));
            return element;
        }
        public static IWebElement btnLogOut(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > li > div > a:nth-child(1)"));
            return element;
        }
        public static IWebElement btnEditProfile(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > li > div > a:nth-child(2)"));
            return element;
        }

        //Index Page - Content

        public static IWebElement linkToYourProfile(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("body > div > div.row > div:nth-child(1) > div.mainprofile.img-rounded > div > a"));
            return element;
        }
        public static IWebElement txtTweet(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("myTweet"));
            return element;
        }
        public static IWebElement btnSendTweet(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#button"));
            return element;
        }

        public static IWebElement firstTweet(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("body > div > div.row > div.col-sm-6 > div:nth-child(2) > div:nth-child(1)"));
            return element;
        }

            //Messages Page

            public static IWebElement txtSendMessageTo(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("to"));
            return element;
        }
        public static IWebElement txtMessage(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("message"));
            return element;
        }
        public static IWebElement btnSend(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("button"));
            return element;
        }

        //Contact Us Page

        public static IWebElement linkEmailAddress(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("body > div > table > tbody > tr:nth-child(4) > td:nth-child(2) > a"));
            return element;
        }

        //Edit Profile Page

        public static IWebElement filePhoto(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#frm_photo > input.btn.btn-primary.btn-block.btn-lg"));
            return element;
        }
        public static IWebElement btnSendPhoto(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("button"));
            return element;
        }


        public static IWebElement profilePictureTrump(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#dropdown01"));
            return element;
        }
        public static IWebElement profilePicture(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#navbarsExampleDefault > li > div > a:nth-child(2)"));
            return element; 
        }

        public static IWebElement submitPhoto(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.Id("button"));
            return element;
        }

        public static IWebElement chooseFile(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#frm_photo > input.btn.btn-primary.btn-block.btn-lg"));
            return element;
        }





    }
}
