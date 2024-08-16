using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System;
using System.IO;
using OpenQA.Selenium.Edge;
using static System.Windows.Forms.Design.AxImporter;
using System.Text.RegularExpressions;
using Palmer;
using System.Windows.Forms;

namespace MonitoringApp
{
    public partial class Form1 : Form
    {
        private string Domains = "";
        public static string DirectoryDomains { get; set; }
        public Form1()
        {
            InitializeComponent();
            label3.Text = "...";
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            //OpenUrlsAndTakeScreenshots(Domains);
            ExecuteBrowser();
        }

        public async void ExecuteBrowser()
        {
            Parallel.Invoke(() => OpenUrlsAndTakeScreenshots_ff(Domains), () => OpenUrlsAndTakeScreenshots_ch(Domains), () => OpenUrlsAndTakeScreenshots_ed(Domains));
        }

        public void OpenUrlsAndTakeScreenshots_ff(string filePath)
        {
            // Read URLs from the file
            var urls = File.ReadAllLines(filePath);

            // Open Firefox, navigate to each URL, and take a screenshot

            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AcceptInsecureCertificates = true; // Accept invalid SSL certificates

            IWebDriver firefoxDriver = new FirefoxDriver(firefoxOptions);
            IJavaScriptExecutor jsf = (IJavaScriptExecutor)firefoxDriver;
            foreach (var url in urls)
            {
                //firefoxDriver.Navigate().GoToUrl("https://"+url);

                jsf.ExecuteScript("window.open();");

                firefoxDriver.SwitchTo().Window(firefoxDriver.WindowHandles[1]);

                System.Threading.Thread.Sleep(4000);
                try
                {

                    firefoxDriver.Navigate().GoToUrl(!url.StartsWith("http://") || !url.StartsWith("https://") ? "https://" + url : url);
                }
                catch (TimeoutException ex)
                {
                    LogError(ex.Message, ex.StackTrace);
                }
                catch (WebDriverException ex)
                {
                    LogError(ex.Message, ex.StackTrace);
                }
                finally
                {
                    try
                    {
                        TakeScreenshot(firefoxDriver, "Firefox", url);
                        firefoxDriver.SwitchTo().Window(firefoxDriver.WindowHandles[0]);
                    }
                    catch (NoSuchWindowException ex)
                    {
                        LogError(ex.Message, ex.StackTrace);
                    }

                }

                //firefoxDriver.Close();

            }
            firefoxDriver.Quit();

        }

        public void OpenUrlsAndTakeScreenshots_ch(string filePath)
        {
            // Read URLs from the file
            var urls = File.ReadAllLines(filePath);

            // Open Chrome, navigate to each URL, and take a screenshot
            var chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true; // Accept invalid SSL certificates

            IWebDriver chromeDriver = new ChromeDriver(chromeOptions);

            IJavaScriptExecutor jsf = (IJavaScriptExecutor)chromeDriver;
            foreach (var url in urls)
            {
                jsf.ExecuteScript("window.open();");

                chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[1]);

                System.Threading.Thread.Sleep(4000);
                try
                {
                    chromeDriver.Navigate().GoToUrl(!url.StartsWith("http://") || !url.StartsWith("https://") ? "https://" + url : url);
                }
                catch (TimeoutException ex)
                {
                    LogError(ex.Message, ex.StackTrace);
                }
                catch (WebDriverException ex)
                {
                    LogError(ex.Message, ex.StackTrace);
                }
                finally
                {

                    try
                    {
                        TakeScreenshot(chromeDriver, "Chrome", url);
                        chromeDriver.SwitchTo().Window(chromeDriver.WindowHandles[0]);
                    }
                    catch (NoSuchWindowException ex)
                    {
                        LogError(ex.Message, ex.StackTrace);
                    }
                }
               // chromeDriver.Close();

            }
            chromeDriver.Quit();

        }

        public void OpenUrlsAndTakeScreenshots_ed(string filePath)
        {
            // Read URLs from the file
            var urls = File.ReadAllLines(filePath);

            // Open Chrome, navigate to each URL, and take a screenshot
            var edgeOptions = new EdgeOptions();
            edgeOptions.AcceptInsecureCertificates = true; // Accept invalid SSL certificates
            IWebDriver edgeDriver = new EdgeDriver(edgeOptions);

            IJavaScriptExecutor jsf = (IJavaScriptExecutor)edgeDriver;
            foreach (var url in urls)
            {
                jsf.ExecuteScript("window.open();");

                edgeDriver.SwitchTo().Window(edgeDriver.WindowHandles[1]);

                System.Threading.Thread.Sleep(4000);
                try
                {
                    edgeDriver.Navigate().GoToUrl(!url.StartsWith("http://") || !url.StartsWith("https://") ? "https://" + url : url);
                }
                catch (TimeoutException ex)
                {
                    LogError(ex.Message, ex.StackTrace);
                }
                catch (WebDriverException ex)
                {
                    LogError(ex.Message, ex.StackTrace);
                }
                finally
                {

                    try
                    {
                        TakeScreenshot(edgeDriver, "Edge", url);
                        edgeDriver.SwitchTo().Window(edgeDriver.WindowHandles[0]);
                    }
                    catch (NoSuchWindowException ex)
                    {
                        LogError(ex.Message, ex.StackTrace);
                    }
                }
               // edgeDriver.Close();
            }
            edgeDriver.Quit();

        }

        private void TakeScreenshot(IWebDriver driver, string browserName, string domainsname)
        {
            // Take a screenshot and save it with a unique name
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var dateString = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string fileName = browserName + "_" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".png";
            string fileName = browserName + "_" + Regex.Replace(domainsname, @"[^0-9a-zA-Z]+", "") + "_" + dateString + ".png";

            screenshot.SaveAsFile(@"D:\env\result_monitoring\" + fileName);
        }

        static void LogError(string errorMessage, string stackTrace)
        {
            //string logFilePath = "D:\\env\\result_monitoring\\error_log.txt";
            string CurrentDirectory = System.IO.Path.GetDirectoryName(DirectoryDomains);
            
            string logFilePath = CurrentDirectory + "\\error_log.txt";
            string logEntry = $"{DateTime.Now}: {errorMessage}\n{stackTrace}\n\n";

            //File.AppendAllText(logFilePath, logEntry);
            //Console.WriteLine($"Error logged to {logFilePath}");
            Retry.On<IOException>().For(TimeSpan.FromSeconds(15)).With(context =>
            {
                File.AppendAllText(logFilePath, logEntry);
            });
        }

        private void button_domains_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt) | *txt";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Title = "Select a Files";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Domains = openFileDialog.FileName;
                DirectoryDomains = Domains;
                label3.Text = System.IO.Path.GetFullPath(Domains).ToString();
                //MessageBox.Show(System.IO.Path.GetFullPath(Domains));
            }
        }
    }
}
