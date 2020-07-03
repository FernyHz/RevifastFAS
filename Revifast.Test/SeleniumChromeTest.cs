using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumChromeTest
    {
        private IWebDriver chrome;

        [TestInitialize]
        public void Initialize()
        {
            chrome = new ChromeDriver();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Manage().Window.Maximize();
            chrome.Navigate().GoToUrl("http://localhost:5000");            
        }

        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = chrome.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo7";
            var password = "Abc123456!";

            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = chrome.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();

            var usernameLabel = chrome.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }
        
        [TestMethod]
        public void IniciarSesion()
        {
            var btnIngresar = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();

            var username = "juantopo7"; var password = "Abc123456!";

            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);

            var loginButton = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            var usernameLabel = chrome.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestMethod]
        public void Editardatos()
        {
            //login
            var btnIngresar = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo7"; var password = "Abc123456!";
            
            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();
            
            //editaTelefono
            var manageAccButton = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[1]/a")); manageAccButton.Click();

            var phoneNum = "997998993";
            var phoneField = chrome.FindElement(By.XPath("//*[@id='Input_PhoneNumber']"));
            phoneField.Clear(); phoneField.SendKeys(phoneNum);

            var updateBtn = chrome.FindElement(By.XPath("//*[@id='update-profile-button']"));
            updateBtn.Click();
            
            var wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/main/div/div/div[2]/div[1]")));

            var alertSucess = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div/div[2]/div[1]"));
            Assert.IsTrue(alertSucess.Displayed);
        }

        [TestMethod]
        public void CrearVehiculo()
        {
            //login
            var btnIngresar = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo7"; var password = "Abc123456!";
            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            var vehiculosBtn = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[5]/a"));
            vehiculosBtn.Click();
            var addAutoBtn = chrome.FindElement(By.XPath("/html/body/div[1]/main/p/a")); addAutoBtn.Click();
            
            var placaField = chrome.FindElement(By.XPath("//*[@id='Placa']"));
            var modeloField = chrome.FindElement(By.XPath("//*[@id='Modelo']"));
            var categoriaField = chrome.FindElement(By.XPath("//*[@id='Categoria']"));
            string placa = "AFS203"; string modelo = "picanto"; string categoria = "D2";
            placaField.SendKeys(placa); modeloField.SendKeys(modelo); categoriaField.SendKeys(categoria);

            //click crear
            chrome.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input")).Click();
            
            var wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Vehiculos"));
            Assert.IsTrue(chrome.Url == "http://localhost:5000/Vehiculos");
        }     

        [TestMethod]
        public void CrearReserva()
        {
            //login
            var btnIngresar = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo7"; var password = "Abc123456!";
            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //reserva
            var reservasBtn = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[6]/a"));
            reservasBtn.Click();
            
            var placaDrDo = chrome.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = chrome.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            selectEmpresa.SelectByText("Farenet");

            //review
            var dateField = chrome.FindElement(By.XPath("//*[@id='Fecha']"));
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var createBtn = chrome.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            createBtn.Click();
            
            Assert.IsTrue(chrome.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EditarReserva()
        {
            //login
            var btnIngresar = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo7"; var password = "Abc123456!";
            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            /*reservas*/
            chrome.Navigate().GoToUrl("http://localhost:5000/Reservas");
            var EditReservaBtn = chrome.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[1]"));
            EditReservaBtn.Click();

            var placaDrDo = chrome.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = chrome.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            //otra Empresa
            selectEmpresa.SelectByText("ReviSeguros");

            var dateField = chrome.FindElement(By.XPath("//*[@id='Fecha']"));
            //mañana
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second); date = date.AddDays(1);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var saveBtn = chrome.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            saveBtn.Click();

            Assert.IsTrue(chrome.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EliminarReserva()
        {
            //login
            var btnIngresar = chrome.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo7"; var password = "Abc123456!";
            var emailField = chrome.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = chrome.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //reserva
            var DelReservaBtn = chrome.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[3]"));
            DelReservaBtn.Click();

            var confirmDelBtn = chrome.FindElement(By.XPath("/html/body/div[1]/main/div/form/input[2]"));
            confirmDelBtn.Click();

            Assert.IsTrue(chrome.Url == "http://localhost:5000/Reservas");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (chrome == null) return;
            chrome.Quit();
            chrome.Dispose();
        }
    }
}


/*
var confirmLink = chrome.FindElement(By.Id("confirm-link"));
confirmLink.Click();
var resultDiv = chrome.FindElement(By.CssSelector("div.alert.alert-success.alert-dismissible"));
var message = Regex.Replace(resultDiv.Text, @"[^\u0000-\u007F]+", string.Empty);
message = message.Replace(Environment.NewLine, string.Empty);
Assert.AreEqual("Thank you for confirming your email.", message);
*/
