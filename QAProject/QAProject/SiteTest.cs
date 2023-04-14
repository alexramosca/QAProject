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
using System.IO;
using Org.BouncyCastle.Crypto.Macs;
using static System.Net.Mime.MediaTypeNames;
using Bogus;

namespace QAProject
{
    internal class SiteTest
    {
        //Add the tests and the structures used by the tests
        public static bool TWEET01(IWebDriver driver)
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
            string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName, "large.jpg");
            btnChooseFile.SendKeys(filePath);
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
            string filePath = Path.Combine(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName, "short.png");
            btnChooseFile.SendKeys(filePath);
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
            if (driver.Url.Contains("http://10.157.123.12/site3/search.php"))
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
            catch
            {
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
        //MENU06 - TEST LOGOUT
        public static bool TestMenu06(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");

                IWebElement btnLi = WebsiteElement.btnProfile(driver);
                IWebElement btnLogOut = WebsiteElement.btnLogOut(driver);


                btnLi.Click();
                btnLogOut.Click();


                if (driver.Url.Contains("http://10.157.123.12/site3/Login.php"))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }
        //MENU07 - TEST EDIT PROFILE PICTRE
        public static bool TestMenu07(IWebDriver driver)
        {
            try
            {
                Login(driver, "nick", "asdf");
                IWebElement btnLi = WebsiteElement.btnProfile(driver);
                IWebElement btnEdit = WebsiteElement.btnEditProfile(driver);
                btnLi.Click();
                btnEdit.Click();


                if (driver.Url.Contains("http://10.157.123.12/site3/edit_photo.php"))
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }
        //Brett code starts
        //REG01 - TEST REGISTRATION -Check if Passwords match
        public static bool TestReg01(IWebDriver driver)
        {
            try
            {
                var faker = new Faker();
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();
                // Navigate to the form page
                IWebElement link = driver.FindElement(By.LinkText("Click Here"));
                link.Click();
                
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys(firstName);
                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys(lastName);
                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys(firstName);
                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys(faker.Internet.Email(firstName, lastName));
                
                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("TestApril2023");
                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("TestApril2023");
                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");
                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");
                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();
                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();
                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");
                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");
                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");
                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");


                Console.WriteLine(txtSignUpPassword.Text + " " + txtSignUpConfirmPassword.Text);
                //check if passwords match
                if (txtSignUpPassword.Text == txtSignUpConfirmPassword.Text)
                {
                    IWebElement btnSignUp = WebsiteElement.btnRegister(driver);
                    btnSignUp.Click();
                    Thread.Sleep(4000);
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();

                    return true;

                }
                else
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();
                    return false;
                }

                
            }
            catch (NoAlertPresentException)
            {
                return false;
            }





        }
        //REG02 - TEST REGISTRATION -Check if email is correct
        public static bool TestReg02(IWebDriver driver)
        {
            try
            {
                var faker = new Faker();
                var firstName = faker.Name.FirstName();
                var lastName = faker.Name.LastName();

                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys(firstName);
                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys(lastName);
                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys(firstName);
                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                string email = faker.Internet.Email(firstName, lastName);
                txtEmail.SendKeys(email);
                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("TestApril2023");
                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("TestApril2023");
                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");
                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");
                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();
                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();
                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");
                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");
                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");
                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");

                //check if the email is correct
                if (email.Contains("@") && email.EndsWith(".com"))
                {
                    IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                    BtnRegister.Click();
                    Thread.Sleep(4000);
                    IAlert alert = driver.SwitchTo().Alert();

                    //Test if the email is valid and the user is registered
                    if (alert.Text.Contains("your account is created Sucessfully!!"))
                    {
                        alert.Accept();
                        return true;
                    }
                    else
                    {
                        alert.Accept();
                        return false;
                    }



                    

                }
                else
                {
                    IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                    BtnRegister.Click();
                    if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                    {
                        driver.SwitchTo().Alert().Accept();
                        return true;
                    }
                    else
                    {

                        driver.SwitchTo().Alert().Accept();
                        return false;
                    }

                }
            }
            catch
            {
                return false;
            }
        }
        //REG03 - TEST REGISTRATION -check username
        public static bool TestReg03(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys("Test");
                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys("April");
                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys("nick");
                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys("Test@gmail.com");
                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("TestApril2023");
                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("TestApril2023");
                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");
                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");
                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();
                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();
                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");
                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");
                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");
                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");



                Thread.Sleep(1000);
                IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                BtnRegister.Click();

                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {
                    driver.SwitchTo().Alert().Accept();
                    return false;
                }


            }
            catch
            {
                return false;
            }
        }
        //REG04 - TEST REGISTRATION -Check Logo page
        public static bool TestReg04(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(1000);
                IWebElement logoImage = driver.FindElement(By.CssSelector(".logo"));
                logoImage.Click();
                Thread.Sleep(1000);

                if (driver.Title.Contains("404 Not Found"))
                {
                    driver.Navigate().Back();
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //REG05 - TEST REGISTRATION -Test phone number
        public static bool TestReg05(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys("Test");
                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys("April");
                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys("test5");
                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys("Test@gmail.comt");
                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("TestApril2023");
                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("TestApril2023");
                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("asdasdasd");
                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");
                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();
                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();
                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");
                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");
                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");
                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");

                Thread.Sleep(1000);

                IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                BtnRegister.Click();
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {

                    driver.SwitchTo().Alert().Accept();
                    driver.Navigate().Refresh();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //REG06 - TEST REGISTRATION -test address
        public static bool TestReg06(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys("Test");
                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys("April");
                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys("test6");
                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys("Test@gmail.com");
                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("TestApril2023");
                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("TestApril2023");
                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");
                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("qweqweqwe");
                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();
                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();
                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");
                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");
                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");
                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");

                Thread.Sleep(1000);

                IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                BtnRegister.Click();
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {

                    driver.SwitchTo().Alert().Accept();
                    driver.Navigate().Refresh();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //REG07 - TEST REGISTRATION -test URL
        public static bool TestReg07(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys("Test");
                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys("April");
                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys("test6");
                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys("Test@gmail.com");
                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("TestApril2023");
                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("TestApril2023");
                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");
                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");
                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();
                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();
                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");
                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("testestestestest");
                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");
                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");

                Thread.Sleep(1000);

                IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                BtnRegister.Click();
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {

                    driver.SwitchTo().Alert().Accept();
                    driver.Navigate().Refresh();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //REG08 - TEST REGISTRATION -test registration with valid data
        public static bool TestReg08(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys("Selenium");

                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys("Last Name");

                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys("selenium");

                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys("selenium@test.ca");

                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("selenium");

                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("selenium");

                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");

                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");

                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();

                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();

                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");

                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");

                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");

                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");

                Thread.Sleep(1000);

                IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                BtnRegister.Click();
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {

                    driver.SwitchTo().Alert().Accept();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //REG09 - TEST REGISTRATION -test screen name
        public static bool TestReg09(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(4000);
                IWebElement txtFirstName = WebsiteElement.txtFirstName(driver);
                txtFirstName.SendKeys("Selenium");

                IWebElement txtLastName = WebsiteElement.txtLastName(driver);
                txtLastName.SendKeys("Last Name");

                IWebElement txtScreenName = WebsiteElement.txtScreenName(driver);
                txtScreenName.SendKeys("TestUser$$@@");

                IWebElement txtEmail = WebsiteElement.txtEmail(driver);
                txtEmail.SendKeys("selenium@test.ca");

                IWebElement txtSignUpPassword = WebsiteElement.txtSignUpPassword(driver);
                txtSignUpPassword.SendKeys("selenium");

                IWebElement txtSignUpConfirmPassword = WebsiteElement.txtConfirmPassword(driver);
                txtSignUpConfirmPassword.SendKeys("selenium");

                IWebElement txtPhone = WebsiteElement.txtPhoneNumber(driver);
                txtPhone.SendKeys("(506) 123-4456");

                IWebElement txtAddress = WebsiteElement.txtAddress(driver);
                txtAddress.SendKeys("123 Main Street");

                IWebElement provinceComboBox = driver.FindElement(By.Id("province"));
                provinceComboBox.Click();

                IWebElement nbOption = driver.FindElement(By.XPath("//option[text()='New Brunswick']"));
                nbOption.Click();

                IWebElement txtpostalcode = driver.FindElement(By.Id("postalCode"));
                txtpostalcode.SendKeys("E3A 1V3");

                IWebElement txtUrl = WebsiteElement.txtUrl(driver);
                txtUrl.SendKeys("www.google.com");

                IWebElement description = WebsiteElement.txtDescription(driver);
                description.SendKeys("This is a test");

                IWebElement location = WebsiteElement.txtLocation(driver);
                location.SendKeys("Fredericton");

                Thread.Sleep(1000);

                IWebElement BtnRegister = WebsiteElement.btnRegister(driver);
                BtnRegister.Click();
                if (driver.SwitchTo().Alert().Text.Contains("successfully"))
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {

                    driver.SwitchTo().Alert().Accept();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        

        
    }
}




