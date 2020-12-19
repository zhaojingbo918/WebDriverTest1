using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebDriverTest1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();


            ChromeOptions option = new OpenQA.Selenium.Chrome.ChromeOptions();
            option.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            var driver = new ChromeDriver(chromeDriverService, option);
             
            //Puts a Implicit wait, Will wait for 10 seconds before throwing exception
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            //Launch website
            driver.Navigate().GoToUrl("http://www.calculator.net/");

            //Maximize the browser
            driver.Manage().Window.Maximize();

            // Click on Percent Calculators
            driver.FindElement(OpenQA.Selenium.By.XPath("//*[@id='hl3']/li[3]/a")).Click();

            
            // Enter value 10 in the first number of the percent Calculator
            driver.FindElement(By.Id("cpar1")).SendKeys("10");

            // Enter value 50 in the second number of the percent Calculator
            driver.FindElement(By.Id("cpar2")).SendKeys("50");

            // Click Calculate Button
            driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr[2]/td/input[2]")).Click();

            // Get the Result Text based on its xpath
            String result = driver.FindElement(By.XPath("//*[@id='content']/h2[1]")).Text;

            //Print a Log In message to the screen
            Console.WriteLine(" The Result is " + result);

            driver.Quit();
            Console.WriteLine(" 1111111 " + DateTime.Now.ToString("mm:ss"));
            driver.Dispose();
            Console.WriteLine(" 222222 " + DateTime.Now.ToString("mm:ss"));
            chromeDriverService.Dispose();
            Console.WriteLine(" 3333333 " + DateTime.Now.ToString("mm:ss"));

        }
    }
}
