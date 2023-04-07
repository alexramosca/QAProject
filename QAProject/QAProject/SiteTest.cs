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
            txtTweet.SendKeys("#!-");


            IWebElement txtBtnSendTweet = WebsiteElement.btnSendTweet(driver);
            txtBtnSendTweet.Click();
            txtBtnSendTweet.Click();
            driver.SwitchTo().Alert().Accept();

            IWebElement txtFirstTweet = WebsiteElement.firstTweet(driver);

            if (txtFirstTweet.Text.Contains("#!-"))
            {
                return true;
            }

            else 
            {
                return false;
            }

        }


        public static bool TWEET03(IWebDriver driver)
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
            txtTweet.SendKeys("HOLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");


            IWebElement txtBtnSendTweet = WebsiteElement.btnSendTweet(driver);
            txtBtnSendTweet.Click();
            txtBtnSendTweet.Click();
            driver.SwitchTo().Alert().Accept();

            IWebElement txtFirstTweet = WebsiteElement.firstTweet(driver);

            if (txtFirstTweet.Text.Contains("HOLAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"))
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        public static bool MESSAGE01(IWebDriver driver)
        {
            IWebElement txtUsername = WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();

            
            
            
            IWebElement btnMessagesLink = WebsiteElement.messagesLink(driver);
            btnMessagesLink.Click();

            Thread.Sleep(2000);

            IWebElement txtSendMessageTo = WebsiteElement.txtSendMessageTo(driver);
            txtSendMessageTo.Click();
            txtSendMessageTo.SendKeys("test");

            Thread.Sleep(2000);

            IWebElement txtMessage = WebsiteElement.txtMessage(driver);
            txtMessage.Click();
            txtMessage.SendKeys("");

            Thread.Sleep(2000);

            IWebElement btnSend = WebsiteElement.btnSend(driver);
            btnSend.Click();

            Thread.Sleep(2000);


            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("Message Sent"))
                {
                    return false;
                }

                else 
                {
                    return true;
                }
            }
            catch (NoAlertPresentException)
            {
                return true; // Didn't sent a confirmation of sending
            }


        }


        public static bool MESSAGE02(IWebDriver driver)
        {
            IWebElement txtUsername = WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();




            IWebElement btnMessagesLink = WebsiteElement.messagesLink(driver);
            btnMessagesLink.Click();

            Thread.Sleep(2000);

            IWebElement txtSendMessageTo = WebsiteElement.txtSendMessageTo(driver);
            txtSendMessageTo.Click();
            txtSendMessageTo.SendKeys("test");

            Thread.Sleep(2000);

            IWebElement txtMessage = WebsiteElement.txtMessage(driver);
            txtMessage.Click();
            txtMessage.SendKeys("This is a valid message");

            Thread.Sleep(2000);

            IWebElement btnSend = WebsiteElement.btnSend(driver);
            btnSend.Click();

            Thread.Sleep(2000);

            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("Message Sent"))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (NoAlertPresentException)
            {
                return false; // Didn't sent a confirmation of sending
            }


        }


        public static bool MESSAGE03(IWebDriver driver)
        {
            IWebElement txtUsername = WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();




            IWebElement btnMessagesLink = WebsiteElement.messagesLink(driver);
            btnMessagesLink.Click();

            Thread.Sleep(2000);

            IWebElement txtSendMessageTo = WebsiteElement.txtSendMessageTo(driver);
            txtSendMessageTo.Click();
            txtSendMessageTo.SendKeys("nick");

            Thread.Sleep(2000);

            IWebElement txtMessage = WebsiteElement.txtMessage(driver);
            txtMessage.Click();
            txtMessage.SendKeys("I'm sending a message to myself");

            Thread.Sleep(2000);

            IWebElement btnSend = WebsiteElement.btnSend(driver);
            btnSend.Click();

            Thread.Sleep(5000);

            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("Message Not Sent"))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (NoAlertPresentException)
            {
                return false; // Didn't sent a confirmation of not sending
            }


        }


        public static bool PHOTO01(IWebDriver driver)
        {
            IWebElement txtUsername = WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();


            IWebElement btnProfilePictureTrump = WebsiteElement.profilePictureTrump(driver);
            btnProfilePictureTrump.Click();

            IWebElement btnProfilePicture = WebsiteElement.profilePicture(driver);
            btnProfilePicture.Click();

            IWebElement btnSubmitPhoto = WebsiteElement.submitPhoto(driver);
            btnSubmitPhoto.Click();

            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("Error you must select a file"))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (NoAlertPresentException)
            {
                return false; // Didn't sent a confirmation of not sending
            }




            Thread.Sleep(5000);

            return true;

            

        }



        public static bool PHOTO02(IWebDriver driver)
        {
            IWebElement txtUsername = WebsiteElement.txtScreenName(driver);
            IWebElement txtPassword = WebsiteElement.txtPassword(driver);
            txtUsername.SendKeys("nick");
            txtPassword.SendKeys("asdf");
            IWebElement btnLogin = WebsiteElement.btnLogin(driver);
            btnLogin.Click();
            driver.SwitchTo().Alert().Accept();


            IWebElement btnProfilePictureTrump = WebsiteElement.profilePictureTrump(driver);
            btnProfilePictureTrump.Click();

            IWebElement btnProfilePicture = WebsiteElement.profilePicture(driver);
            btnProfilePicture.Click();
            Thread.Sleep(3000);

            IWebElement btnChooseFile = WebsiteElement.chooseFile(driver);
            btnChooseFile.SendKeys("C:\\repos\\QAProject\\large.jpg"); // uploading a large file 
            Thread.Sleep(3000);

            IWebElement btnSubmitPhoto = WebsiteElement.submitPhoto(driver);
            btnSubmitPhoto.Click();


            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("Your photo have uploaded successfully"))
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
            catch (NoAlertPresentException)
            {
                return false; // Didn't sent a confirmation of uploading
            }


            Thread.Sleep(5000);

            return true;


        }









    }
}
