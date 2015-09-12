using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: Selenium Email Passowd ");
                return -1;
            }

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://spb.hh.ru/account/login");
            var arr =
                driver.FindElements(By.XPath(".//input[@class='bloko-input' and @type='text' or @type='password']"));

            arr[0].SendKeys(args[0]);
            arr[1].SendKeys(args[1]);
            arr[1].SendKeys(Keys.Enter);

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://spb.hh.ru/applicant/resumes");
            driver.FindElement(By.XPath(".//div[@class='resumelist__resume']/div/span/a")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            if (
                driver.FindElement(
                    By.XPath(
                        ".//div[@class='HH-Resume-UpdateTimer-ToUpdate-Container' and text()='Обновить можно через ']"))
                    .Displayed)
            {
                driver.Close();
                return -1;
            }


            driver.FindElement(By.XPath(".//span[@class='g-switcher m-switcher_999 noprint HH-Resume-Touch-Button']"))
                .Click();
            driver.Close();


            return 0;
        }
    }
}