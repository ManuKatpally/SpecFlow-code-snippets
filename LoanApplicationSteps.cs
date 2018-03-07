[Binding]
    public class LoanApplicationSteps
    {
        private IWebDriver _driver;
        private LoanApplicationpage _loanapplicationpage;
        private ApplicationConfirmationPage _confirmationpage;

        [Given(@"I am on the Loan Application screen")]
        public void GivenIAmOnTheLoanApplicationScreen()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            // _driver.Navigate().GoToUrl("http://localhost:40077/Home/StartLoanApplication");
            _loanapplicationpage = LoanApplicationpage.NavigateTo(_driver);

        }
        
        [Given(@"I enter firstname of (.*)")]
        public void GivenIEnterFirsTnameOf(string Firstname)
        {
            //IWebElement firstname = _driver.FindElement(By.Id("FirstName"));
            //firstname.SendKeys(Firstname);
            _loanapplicationpage.FirstName = Firstname;
        }
        
        [Given(@"I enter Last name of (.*)")]
        public void GivenIEnterLastNameOf(string lastname)
        {
            // _driver.FindElement(By.Id("LastName")).SendKeys(lastname);
            _loanapplicationpage.LastName = lastname;

        }

        [Given(@"I select that I have an existing loan account")]
        public void GivenISelectThatIHaveAnExistingLoanAccount()
        {
            //_driver.FindElement(By.Id("Loan")).Click();
            _loanapplicationpage.selectexistingloan();
        }
        
        [Given(@"I confirm my acceptance of the terms and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTermsAndConditions()
        {
            // _driver.FindElement(By.Name("TermsAcceptance")).Click();
            _loanapplicationpage.TermsandConditions();
        }
        
        [When(@"I submit my Application")]
        public void WhenISubmitMyApplication()
        {
            // _driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
           _confirmationpage= _loanapplicationpage.SubmitApplication();
        }
        
        [Then(@"I should see the application complete confirmation for manu")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationForManu()
        {
            //IWebElement confirmationnamespan = _driver.FindElement(By.Id("firstName"));

            //string confirmationname = confirmationnamespan.Text;

            Assert.Equal("manu", _confirmationpage.Firstname);
        }

        [Then(@"I should see an error message telling me I must accept the terms and conditions")]
        public void ThenIShouldSeeAnErrorMessageTellingMeIMustAcceptTheTermsAndConditions()
        {
            IWebElement errormessage =
              _driver.FindElement(By.CssSelector("div.validation-summary-errors ul li"));

            Assert.Equal("You must accept the terms and conditions",errormessage.Text);
        }

        [AfterScenario]
        public void Disposewebdriver()
        {
            _driver.Dispose();
        }
    }
}
