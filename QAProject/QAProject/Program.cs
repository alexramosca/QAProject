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
           // SiteReset();
           
            //driver used on the project
            IWebDriver driver = new ChromeDriver(@"c:\Selenium"); //Careful with the path of your driver.

            driver.Url = "http://10.157.123.12/site3/Login.php"; //opening and closing just to make sure it works

            //RICO'S TESTS START
            
            driver.Manage().Window.Size = new System.Drawing.Size(1620, 980);

            //LOG01 - Test Login with Invalid Information

            if (SiteTest.Login(driver, "adsdsaadsdsa", "qweweqweqwqe"))
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

            Thread.Sleep(10000);
            

            //RICO'S TESTS END

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

            Thread.Sleep(5000);

         





            driver.Quit();



            //ALEX'S TESTS END

        }

        public static void SiteReset()
        {
            string myConnectionString = "server=10.157.123.12;database=bitter-site4;uid=site3;pwd=KgpRPAIfliuGXxM8;";
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
