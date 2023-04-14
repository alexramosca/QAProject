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
    internal class Program
    {
        private static MySqlConnection connection;
        static void Main(string[] args)
        {
            //Add the call for the tests on SiteTests class

            //reset the website
            //SiteReset(); It didn't work
           
            //driver used on the project
            IWebDriver driver = new ChromeDriver(@"c:\Selenium"); //Careful with the path of your driver.

            driver.Url = "http://10.157.123.12/site3/Login.php"; //opening and closing just to make sure it works

            //RICO'S TESTS START

             driver.Manage().Window.Size = new System.Drawing.Size(1620, 980);
            
            //LOG01 - Test Login with Invalid Information

           /* if (SiteTest.Login(driver, "adsdsaadsdsa", "qweweqweqwqe"))
            {
                Console.WriteLine("LOG01 - Login successful - TEST FAIL");
            }
            else
            {
                Console.WriteLine("LOG01 - Login unsuccessful - TEST PASS");
            }

            Thread.Sleep(5000);

            //LOG02 - Test Login with Valid Information

            if (SiteTest.Login(driver, "nick", "asdf"))
            {
                Console.WriteLine("LOG02 - Login successful - TEST PASS");
            }
            else
            {
                Console.WriteLine("LOG02 - Login unsuccessful - TEST FAIL");
            }

            Thread.Sleep(5000);

            //SEARCH01 - Test Search Bar

            if (SiteTest.TestSearchBar(driver))
            {
                Console.WriteLine("SEARCH01 - Page Redirected to Results - TEST PASS");
            }
            else
            {
                Console.WriteLine("SEARCH01 - Page Didn't Redirect to Results - TEST FAIL");
            }

            Thread.Sleep(5000);

            //HOME01 - Test Link to Profile

            driver.Navigate().Back();

            if (SiteTest.TestProfileLink(driver))
            {
                Console.WriteLine("HOME01 - Page Redirected to Profile - TEST PASS");
            }
            else
            {
                Console.WriteLine("HOME01 - Page Didn't Redirect to Profile - TEST FAIL");
            }

            Thread.Sleep(5000);
            LogOut(driver);


            //RICO'S TESTS END



            //ANTONIO'S TESTS

            bool TWEET01 = SiteTest.TWEET01(driver);

            if (TWEET01)// TEST SENDING EMPTY TWEET
            {
                Console.WriteLine("EMPTY TWEET TEST: PASSED");
            }
            else
            {
                Console.WriteLine("EMPTY TWEET TEST: FAILED");
            }

            LogOut(driver);

            bool TWEET02 = SiteTest.TWEET02(driver);

            if (TWEET02)// TEST SENDING TWEET WITH SPECIAL CHARACTERS
            {
                Console.WriteLine("TEST WITH SPECICAL CHARACTERS: PASSED");
            }
            else
            {
                Console.WriteLine("TEST WITH SPECIAL CHARACTERS: FAILED");
            }

            LogOut(driver);



            bool TWEET03 = SiteTest.TWEET03(driver);

            if (TWEET03)// TEST SENDING TWEET WITH MORE THAN 60O CHARACTERS
            {
                Console.WriteLine("TEST WITH A LIMIT OF 600 CHARACTERES: PASSED");
            }
            else
            {
                Console.WriteLine("TEST WITH A LIMIT OF 600 CHARACTERES: FAILED");
            }

            LogOut(driver);

            /* RUN IT INDIVIDUALLY
            bool MESSAGE01 = SiteTest.MESSAGE01(driver);

            if (MESSAGE01)// TEST SENDING AN EMPTY MESSAGE 
            {
                Console.WriteLine("TEST WITH EMPTY MESSAGE: PASSED");
            }
            else
            {
                Console.WriteLine("TEST WITH EMPTY MESSAGE: FAILED");
            }
            */


            //LogOut(driver);

            /*--------------------------------------------------------------------------------------
            bool MESSAGE02 = SiteTest.MESSAGE02(driver);

            if (MESSAGE02)// TEST SENDING A VALID MESSAGE 
            {
                Console.WriteLine("TEST WITH VALID MESSAGE: PASSED");

            }
            else
            {
                Console.WriteLine("TEST WITH VALID MESSAGE: FAILED");

            }

            LogOut(driver);


            bool MESSAGE03 = SiteTest.MESSAGE03(driver);

            if (MESSAGE03)// TEST SENDING A VALID MESSAGE 
            {
                Console.WriteLine("TEST TO CURRENT LOGGED IN USER: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO CURRENT LOGGED IN USER: FAILED");

            }


            LogOut(driver);

            bool MESSAGE04 = SiteTest.MESSAGE04(driver);

            if (MESSAGE04)// TEST SENDING A MESSAGE WITH MORE THAN 1200 WORDS 
            {
                Console.WriteLine("TEST WITH MESSAGE WITH MORE THAN 1200 WORDS: PASSED");

            }
            else
            {
                Console.WriteLine("TEST WITH MESSAGE WITH MORE THAN 1200 WORDS: FAILED");

            }


            LogOut(driver);

            bool PHOTO01 = SiteTest.PHOTO01(driver);

            if (PHOTO01)// TEST UPLOADING WITHOUT ATTACHING FILE 
            {
                Console.WriteLine("TEST TO EDIT PHOTO WITHOUT ATTACHING FILE: PASSED");


            }
            else
            {
                Console.WriteLine("TEST TO EDIT PHOTO WITHOUT ATTACHING FILE: FAILED");

            }

            LogOutWithHome(driver);


            bool PHOTO02 = SiteTest.PHOTO02(driver);

            if (PHOTO02)// TEST ATTACHING A LARGER FILE
            {
                Console.WriteLine("TEST TO ATTACH A LARGER FILE: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO ATTACH A LARGER FILE: FAILED");

            }

            LogOutWithHome(driver);


            bool PHOTO03 = SiteTest.PHOTO03(driver);

            if (PHOTO03)// TEST ATTACHING A SHORT FILE
            {
                Console.WriteLine("TEST TO ATTACH A SHORT FILE: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO ATTACH A SHORT FILE: FAILED");

            }


            Thread.Sleep(10000);

            

            //ALEX'S TESTS START
            //TEST MENU01 -  MENU LINK

            if (SiteTest.TestMenu01(driver))
            {
                Console.WriteLine("MENU01 - Page Redirect to Index page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU01 - Page Redirect to Index page - TEST FAIL");
            }

            Thread.Sleep(5000);

            //TEST MENU02 -  MOMENTS LINK

            if (SiteTest.TestMenu02(driver))
            {
                Console.WriteLine("MENU02 - Page Redirect to Moments page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU02 - Page Redirect to Moments page - TEST FAIL");
            }

            Thread.Sleep(5000);


            //TEST MENU03 - NOTIFICATIONS LINK
            if (SiteTest.TestMenu03(driver))
            {
                Console.WriteLine("MENU03 - Page Redirect to Notifications page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU03 - Page Redirect to Notifications page - TEST FAIL");
            }

            Thread.Sleep(5000);

            //TEST MENU04 - MESSAGES LINK
            if (SiteTest.TestMenu04(driver))
            {
                Console.WriteLine("MENU04 - Page Redirect to Messages page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU04 - Page Redirect to Messages page - TEST FAIL");
            }

            Thread.Sleep(5000);

            //TEST MENU06 - LOGOUT LINK
            if (SiteTest.TestMenu06(driver))
            {
                Console.WriteLine("MENU06 - Page Redirect to Login Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU06 - Page Redirect to Login page - TEST FAIL");
            }

            Thread.Sleep(5000);

            //TEST MENU07 - LOGOUT LINK
            if (SiteTest.TestMenu07(driver))
            {
                Console.WriteLine("MENU07 - Page Redirect to Edit Profile Picture Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU07 - Page Redirect to Edit Profile Picture page - TEST FAIL");
            }

            Thread.Sleep(5000);

            //TEST MENU05 - CONTACT US LINK
            if (SiteTest.TestMenu05(driver))
            {
                Console.WriteLine("MENU05 - Page Redirect to Contact us page - TEST PASS");
            }
            else
            {
                Console.WriteLine("MENU05 - Page Redirect to Contact us page - TEST FAIL");
            }
            LogOutWithHome(driver);
            Thread.Sleep(5000); ------------------------------------------------------*/
            //Brett's Tests Start
            driver.Url = @"http://10.157.123.12/site3/login.php";
            //TEST REG01 
            if (SiteTest.TestReg01(driver))
            {
                Console.WriteLine("REG01 - registration with password matching - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG01 - REG01 - registration with password matching - TEST FAIL");
            }
            Thread.Sleep(5000);

            driver.Url = @"http://10.157.123.12/site3/signup.php";
            //TEST REG02
            if (SiteTest.TestReg02(driver))
            {
                Console.WriteLine("REG02 - check valid email - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG02 - check valid email - TEST FAIL");
            }
            Thread.Sleep(5000);

            driver.Url = @"http://10.157.123.12/site3/signup.php";

            //TEST REG03
            if (SiteTest.TestReg03(driver))
            {
                Console.WriteLine("REG03 - Test username that already exists - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG03 - Test username that already exists - TEST FAIL");
            }
            Thread.Sleep(5000);
            //TEST REG04
            if (SiteTest.TestReg04(driver))
            {
                Console.WriteLine("REG04 - Page Redirect to Registration Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG04 - Page Redirect to Registration Page - TEST FAIL");
            }
            Thread.Sleep(5000);
            //TEST REG05
            if (SiteTest.TestReg05(driver))
            {
                Console.WriteLine("REG05 - Testing invalid phone number - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG05 - Testing invalid phone number - TEST FAIL");
            }
            Thread.Sleep(5000);
            //TEST REG06
            if (SiteTest.TestReg06(driver))
            {
                Console.WriteLine("REG06 - Page Redirect to Registration Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG06 - Page Redirect to Registration Page - TEST FAIL");
            }
            Thread.Sleep(5000);
            //TEST REG07
            if (SiteTest.TestReg07(driver))
            {
                Console.WriteLine("REG07 - Page Redirect to Registration Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG07 - Page Redirect to Registration Page - TEST FAIL");
            }
            Thread.Sleep(5000);
            //TEST REG08
            if (SiteTest.TestReg08(driver))
            {
                Console.WriteLine("REG08 - Page Redirect to Registration Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG08 - Page Redirect to Registration Page - TEST FAIL");
            }
            Thread.Sleep(5000);
            //TEST REG09
            if (SiteTest.TestReg09(driver))
            {
                Console.WriteLine("REG09 - Page Redirect to Registration Page - TEST PASS");
            }
            else
            {
                Console.WriteLine("REG09 - Page Redirect to Registration Page - TEST FAIL");
            }
            //end of Brett's Tests
            Thread.Sleep(5000);
            driver.Quit();




















            /* IWebElement btnLogOut = WebsiteElement.logOut(driver);
             btnLogOut.Click();*/
        }

        public static void LogOutWithHome(IWebDriver driver)
        {
            IWebElement btnHome = WebsiteElement.homeLink(driver);
            btnHome.Click();

            IWebElement btnProfilePictureTrump = WebsiteElement.profilePictureTrump(driver);
            btnProfilePictureTrump.Click();

            IWebElement btnLogOut = WebsiteElement.logOut(driver);
            btnLogOut.Click();
        }

        public static void LogOut(IWebDriver driver)
        {
            IWebElement btnProfilePictureTrump = WebsiteElement.profilePictureTrump(driver);
            btnProfilePictureTrump.Click();

            IWebElement btnLogOut = WebsiteElement.logOut(driver);
            btnLogOut.Click();
        }
        public static void SiteReset()
        {
            string myConnectionString = "server=10.157.123.12;database=bitter-site3;uid=site3;pwd=2UN3HEWrmi8Nse5d;";
            connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = new MySqlCommand();

            command.Connection = connection;
            command.CommandText = "reset";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


    }
}
