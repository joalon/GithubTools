using OpenQA.Selenium;

namespace GithubCmdlets.Models
{
    public class GithubNewPage : BasePage
    {
        
        public GithubNewPage(IWebDriver webDriver) : base(webDriver)
        {
            _pageUrl = "https://github.com/new";
        }

        public void CreateNewRepository(string RepositoryName, string RepositoryDescription)
        {

            SendKeys(RepositoryNameField, RepositoryName);

            SendKeys(RepositoryDescriptionField, RepositoryDescription);

            Click(CreateRepositoryButton);

        }

        private By RepositoryNameField = By.Id("repository_name");

        private By RepositoryDescriptionField = By.Id("repository_description");

        private By CreateRepositoryButton = By.CssSelector(".btn.btn-primary.first-in-line");

    }
}
