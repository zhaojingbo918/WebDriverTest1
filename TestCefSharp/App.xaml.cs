using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestCefSharp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitializeCefSharp();
        }



        private static void InitializeCefSharp()
        {
            var settings = new CefSettings();
            settings.RemoteDebuggingPort = 18888;
            // Set BrowserSubProcessPath based on app bitness at runtime
            //settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
            //                                       Environment.Is64BitProcess ? "x64" : "x86",
            //                                       "CefSharp.BrowserSubprocess.exe");

            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
        }
    }
}
