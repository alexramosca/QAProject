﻿using System;
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

            /*
            bool TWEET01 = SiteTest.TWEET01(driver);
                        
            if (TWEET01)// TEST SENDING EMPTY TWEET
            {
                Console.WriteLine("EMPTY TWEET TEST: PASSED");
            }
            else
            {
                Console.WriteLine("EMPTY TWEET TEST: FAILED");
            }
            */

            /*
            bool TWEET02 = SiteTest.TWEET02(driver);

            if (TWEET02)// TEST SENDING TWEET WITH SPECIAL CHARACTERS
            {
                Console.WriteLine("TEST WITH SPECICAL CHARACTERS: PASSED");
            }
            else
            {
                Console.WriteLine("TEST WITH SPECIAL CHARACTERS: FAILED");
            }
            */

            /*
            bool TWEET03 = SiteTest.TWEET03(driver);

            if (TWEET03)// TEST SENDING TWEET WITH MORE THAN 60O CHARACTERS
            {
                Console.WriteLine("TEST WITH A LIMIT OF 600 CHARACTERES: PASSED");
            }
            else
            {
                Console.WriteLine("TEST WITH A LIMIT OF 600 CHARACTERES: FAILED");
            }
            */

            /*
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


            /*
             bool MESSAGE02 = SiteTest.MESSAGE02(driver);

             if (MESSAGE02)// TEST SENDING A VALID MESSAGE 
             {
                 Console.WriteLine("TEST WITH VALID MESSAGE: PASSED");

             }
             else
             {
                 Console.WriteLine("TEST WITH VALID MESSAGE: FAILED");

             }
            */

            /*
            bool MESSAGE03 = SiteTest.MESSAGE03(driver);

            if (MESSAGE03)// TEST SENDING A VALID MESSAGE 
            {
                Console.WriteLine("TEST TO CURRENT LOGGED IN USER: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO CURRENT LOGGED IN USER: FAILED");

            }
            */

            bool MESSAGE04 = SiteTest.MESSAGE04(driver);

            if (MESSAGE04)// TEST SENDING A MESSAGE WITH MORE THAN 1200 WORDS 
            {
                Console.WriteLine("TEST WITH MESSAGE WITH MORE THAN 1200 WORDS: PASSED");

            }
            else
            {
                Console.WriteLine("TEST WITH MESSAGE WITH MORE THAN 1200 WORDS: FAILED");

            }

            /*
            bool PHOTO01 = SiteTest.PHOTO01(driver);

            if (PHOTO01)// TEST UPLOADING WITHOUT ATTACHING FILE 
            {
                Console.WriteLine("TEST TO EDIT PHOTO WITHOUT ATTACHING FILE: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO EDIT PHOTO WITHOUT ATTACHING FILE: FAILED");

            }
            */


            /*
            bool PHOTO02 = SiteTest.PHOTO02(driver);

            if (PHOTO02)// TEST ATTACHING A LARGER FILE
            {
                Console.WriteLine("TEST TO ATTACH A LARGER FILE: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO ATTACH A LARGER FILE: FAILED");

            }
            */

            /*
            bool PHOTO03 = SiteTest.PHOTO03(driver);

            if (PHOTO03)// TEST ATTACHING A SHORT FILE
            {
                Console.WriteLine("TEST TO ATTACH A SHORT FILE: PASSED");

            }
            else
            {
                Console.WriteLine("TEST TO ATTACH A SHORT FILE: FAILED");

            }
            */

            Thread.Sleep(10000);
            driver.Quit();


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
