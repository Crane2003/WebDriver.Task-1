using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriver.Task_1.Pages;

namespace WebDriver.Task_1.Tests
{
    [TestClass]
    public class PastebinTests
    {
        private IWebDriver driver;
        private HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void CreateNewPaste_Test()
        {
            // Arrange
            string pasteText = "Hello from WebDriver";
            string pasteExpiration = "10M";
            string pasteName = "helloweb";

            // Act
            homePage.Open();
            homePage.EnterPasteText(pasteText);
            homePage.SelectPasteExpiration(pasteExpiration);
            homePage.EnterPasteName(pasteName);
            homePage.CreateNewPaste();

            // Assert
            Assert.IsTrue(driver.PageSource.Contains(pasteText));
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
