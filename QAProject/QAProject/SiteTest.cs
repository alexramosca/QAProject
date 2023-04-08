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
                    driver.SwitchTo().Alert().Accept();
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

            Thread.Sleep(2000);

            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("Message Not Sent"))
                {
                    driver.SwitchTo().Alert().Accept();
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


        public static bool MESSAGE04(IWebDriver driver)
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
            txtMessage.SendKeys("La tecnología ha revolucionado la forma en que vivimos nuestras vidas. Desde los teléfonos inteligentes hasta los robots, la tecnología ha transformado la manera en que nos comunicamos, trabajamos y nos entretenemos. Los avances en la tecnología también han llevado a grandes mejoras en la medicina y la ciencia, permitiendo que los médicos y los científicos realicen investigaciones y descubrimientos que nunca antes fueron posibles.\r\n\r\nSin embargo, también hay desventajas en la tecnología. Muchas personas se sienten cada vez más desconectadas de la sociedad y de la naturaleza debido al uso excesivo de la tecnología. Además, la tecnología también ha dado lugar a problemas como la adicción a Internet y la ciberseguridad.\r\n\r\nA pesar de estos desafíos, la tecnología continúa avanzando a un ritmo acelerado. Los científicos y los ingenieros están trabajando en nuevas tecnologías que podrían cambiar el mundo de maneras que aún no podemos imaginar. Desde los avances en la inteligencia artificial hasta las soluciones para el cambio climático, la tecnología tiene el potencial de hacer del mundo un lugar mejor para todos.\r\n\r\nEn conclusión, la tecnología es una fuerza poderosa que puede tener tanto efectos positivos como negativos en nuestras vidas. Es importante que utilicemos la tecnología de manera responsable y consideremos cuidadosamente sus impactos en la sociedad y en el medio ambiente.");

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
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
            }
            catch (NoAlertPresentException)
            {
                return false; // Didn't sent a confirmation of sending
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
                    driver.SwitchTo().Alert().Accept();
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
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    
                    return false;
                }

                else
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
            }
            catch (NoAlertPresentException)
            {
                return false; // Didn't sent a confirmation of uploading
            }

        }





        public static bool PHOTO03(IWebDriver driver)
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
            btnChooseFile.SendKeys("C:\\repos\\QAProject\\short.png"); // uploading a large file 
            Thread.Sleep(5000);

            IWebElement btnSubmitPhoto = WebsiteElement.submitPhoto(driver);
            btnSubmitPhoto.Click();


            try
            {
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
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
                return false; // Didn't sent a confirmation of uploading
            }


        }




    }
}
