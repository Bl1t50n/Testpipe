using PuppeteerSharp;
using System;
using System.Runtime.CompilerServices;

namespace TestsAutomation
{
    public class TestAutomation
    {
        private void DownloadChromium() {
            
        }

        private static IBrowser GetBrowser() {
            var browserFetcherOptions = new BrowserFetcherOptions { Browser = SupportedBrowser.Chromium };
            var browserFetcher = new BrowserFetcher(browserFetcherOptions);

            var bfResult = browserFetcher.DownloadAsync(BrowserTag.Latest).GetAwaiter().GetResult();

            var executablePath = browserFetcher.GetExecutablePath(bfResult.BuildId);
            
            if (string.IsNullOrEmpty(executablePath))
            {
                throw new Exception("Custom Chromium location is empty. Unable to start Chromium.");
            }

            return Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false, //false for the browser UI to open
                ExecutablePath = executablePath,
            }).GetAwaiter().GetResult();
        }

        public async Task<bool> RunTestOne()  {
            var browser = GetBrowser();
            try
            {
                Console.WriteLine();
                Console.WriteLine("----- Starting test case #1 -----");

                var page = await browser.NewPageAsync();

                Console.WriteLine("1.1 Openning Page...");

                await page.GoToAsync("https://www.ipportalegre.pt/pt/");

                await Task.Delay(2000);

                Console.WriteLine("----- Test case #1 completed with success. -----");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                // Close the browser when done
                await browser.CloseAsync();
            }

            return true;
        }

        public async Task<bool> RunTestTwo()
        {
            var browser = GetBrowser();
            try
            {
                Console.WriteLine();
                Console.WriteLine("----- Starting test case #2 -----");

                var page = await browser.NewPageAsync();

                Console.WriteLine("2.1 Openning Page...");

                await page.GoToAsync("https://www.ipportalegre.pt/pt/");

                await Task.Delay(2000);

                // Navegar para outra página do site
                //await page.ClickAsync("a['href=https://pae.ipportalegre.pt/']");

                Console.WriteLine("2.2 clicking link...");

                await page.ClickAsync("a[href='https://pae.ipportalegre.pt']");



                await Task.Delay(2000);

                Console.WriteLine("----- Test case #2 completed with success. -----");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await browser.CloseAsync();
            }

            return true;
        }

        public async Task<bool> RunTestThree()
        {
            var browser = GetBrowser();
            try
            {
                Console.WriteLine();
                Console.WriteLine("----- Starting test case #3 -----");

                var page = await browser.NewPageAsync();

                Console.WriteLine("3.1 Opening Page...");

                await page.GoToAsync("https://netpa.ipportalegre.pt/netpa/page");

                await Task.Delay(2000);
                Console.WriteLine("3.2 clicking link...");
                // Navigating to the login page
                await page.ClickAsync("a[href='#']");
                await Task.Delay(2000);


                // Typing username
                await page.TypeAsync("#textfield-1014-inputEl", "21534");

                // Typing password
                await page.TypeAsync("#textfield-1015-inputEl", "sua_senha_aqui");

                Console.WriteLine("3.3 typing input...");
                await Task.Delay(2000);

                Console.WriteLine("----- Test case #3 completed with success. -----");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await browser.CloseAsync();
            }


            return true;
        }

    }
}