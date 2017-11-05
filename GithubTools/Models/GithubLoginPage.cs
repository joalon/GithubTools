using OpenQA.Selenium;


namespace GithubCmdlets.Models
{
    public class GithubLoginPage : BasePage
    {

        private By UsernameInput = By.Id("login_field");

        private By PasswordInput = By.Id("password");

        private By LoginButton = By.Name("commit");

        public GithubLoginPage(IWebDriver webDriver) : base(webDriver)
        {
            this._pageUrl = "https://github.com/login";
        }

        public void Login(string Username, string Password)
        {

            SendKeys(UsernameInput, Username);

            SendKeys(PasswordInput, Password);

            Click(LoginButton);
        }

        
    }
}
