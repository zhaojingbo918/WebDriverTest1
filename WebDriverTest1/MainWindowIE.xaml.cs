﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
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
    public partial class MainWindowIE : Window
    {
        public MainWindowIE()
        {
            InitializeComponent();
        }

        private int step;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var chromeDriverService = InternetExplorerDriverService.CreateDefaultService();


            var option = new InternetExplorerOptions();
            option.PageLoadStrategy = PageLoadStrategy.None;

            //option.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";


            //option.AddArgument("remote-debugging-port=port#");


            var driver = new InternetExplorerDriver(chromeDriverService, option);

            //Puts a Implicit wait, Will wait for 10 seconds before throwing exception
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            Console.WriteLine(step++);
            //Launch website



            driver.Url = "http://www.yiibai.com";



            Console.WriteLine(step++);
            //Maximize the browser
            //driver.Manage().Window.Maximize();



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.PollingInterval = TimeSpan.FromMilliseconds(500);

            IWebElement firstResult = wait.Until(ea => ea.FindElement(By.Id("navs")));



            // Scroll down the webpage by 5000 pixels
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scrollBy(0, 100)");


         


            // Click on the Search button
            driver.FindElement(By.LinkText("Access教程")).Click();//原文出自【易百教程】，商业转载请联系作者获得授权，非商业请保留原文链接：https://www.yiibai.com/selenium/selenium-webdriver-running-test-on-chrome-browser.html#article-start









            Console.WriteLine("fffffffff");

            //driver.Quit();
            //Console.WriteLine(" 1111111 " + DateTime.Now.ToString("mm:ss"));
            //driver.Dispose();
            //Console.WriteLine(" 222222 " + DateTime.Now.ToString("mm:ss"));
            //chromeDriverService.Dispose();
            //Console.WriteLine(" 3333333 " + DateTime.Now.ToString("mm:ss"));

        }
    }
}
