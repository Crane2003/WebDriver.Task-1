using OpenQA.Selenium;

namespace WebDriver.Task_1.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private const string url = "https://pastebin.com/";

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement NewPasteTextArea => driver.FindElement(By.Id("postform-text"));
        private IWebElement PasteNameInput => driver.FindElement(By.Id("postform-name"));
        private IWebElement CreateNewPasteButton => driver.FindElement(By.XPath("//button[text()='Create New Paste']"));

        public void Open()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void EnterPasteText(string pasteText)
        {
            NewPasteTextArea.SendKeys(pasteText);
        }

        public void SelectPasteExpiration(string expiration)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"document.getElementById('postform-expiration').value = '{expiration}';");
        }

        public void EnterPasteName(string pasteName)
        {
            PasteNameInput.SendKeys(pasteName);
        }

        public void CreateNewPaste()
        {
            CreateNewPasteButton.Click();
        }
    }
}
