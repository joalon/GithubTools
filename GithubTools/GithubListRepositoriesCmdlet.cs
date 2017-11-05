using GithubCmdlets.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Management.Automation;

namespace GithubCmdlets
{

    [Cmdlet(VerbsCommon.New, "GithubRepository")]
    public class NewGithubRepositoryCmdlet : Cmdlet
    {
        [Parameter(Position = 1)]
        public string Username { get; set; }

        [Parameter(Position = 2)]
        public string Password { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipeline = true)]
        public string RepositoryName { get; set; }

        [Parameter(Position = 4, ValueFromPipeline = true)]
        public string RepositoryDescription { get; set; }

        private IWebDriver webDriver;

        protected override void BeginProcessing()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless ");

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;

            webDriver = new ChromeDriver(service, options);

            var page = new GithubLoginPage(webDriver);
            page.GoTo();
            page.Login(Username, Password);

        }
        
        protected override void ProcessRecord()
        {
            var newPage = new GithubNewPage(webDriver);
            newPage.GoTo();
            newPage.CreateNewRepository(RepositoryName, RepositoryDescription);
        }

        protected override void EndProcessing()
        {
            webDriver.Quit();
        }

        protected override void StopProcessing()
        {
            webDriver.Quit();
        }
    }
}
