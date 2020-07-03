using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumFirefoxTest
    {
        private IWebDriver firefox;

        [TestInitialize]
        public void Initialize()
        {
            firefox = new FirefoxDriver();
            firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            firefox.Manage().Window.Maximize();
            firefox.Navigate().GoToUrl("http://localhost:5000");
        }

        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = firefox.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo10";
            var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = firefox.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();
            var usernameLabel = firefox.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestMethod]
        public void IniciarSesion()
        {
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();

            var username = "juantopo10"; var password = "Abc123456!";

            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);

            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            var usernameLabel = firefox.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestMethod]
        public void EditarDatosConductor()
        {
            // iniciar sesion
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            // ir a la vista conductor
            var btnConductor = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[4]/a"));
            btnConductor.Click();

            // seleccionar registrar datos
            var btnRegistrarDatos = firefox.FindElement(By.Id("id-registrar-datos"));
            btnRegistrarDatos.Click();

            // registra datos
            var nombre = "Juan";
            var nombreField = firefox.FindElement(By.Id("id-conductor-nombre"));
            nombreField.SendKeys(nombre);
            var apellido = "Topos";
            var apellidoField = firefox.FindElement(By.Id("id-conductor-apellido"));
            apellidoField.SendKeys(apellido);
            var dni = "01234567";
            var dniField = firefox.FindElement(By.Id("id-conductor-dni"));
            dniField.SendKeys(dni);
            var celular = "912345678";
            var celularField = firefox.FindElement(By.Id("id-conductor-celular"));
            celularField.SendKeys(celular);
            var btnRegistrar = firefox.FindElement(By.Id("id-conductor-btn-registrar"));
            btnRegistrar.Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Conductores"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Conductores");
        }

        [TestMethod]
        public void CrearVehiculo()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            var vehiculosBtn = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[5]/a"));
            vehiculosBtn.Click();
            var addAutoBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/p/a")); addAutoBtn.Click();

            var placaField = firefox.FindElement(By.XPath("//*[@id='Placa']"));
            var modeloField = firefox.FindElement(By.XPath("//*[@id='Modelo']"));
            var categoriaField = firefox.FindElement(By.XPath("//*[@id='Categoria']"));
            string placa = "AFS203"; string modelo = "picanto"; string categoria = "D2";
            placaField.SendKeys(placa); modeloField.SendKeys(modelo); categoriaField.SendKeys(categoria);

            //click crear
            firefox.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input")).Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Vehiculos"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Vehiculos");
        }

        [TestMethod]
        public void EditarVehiculo()
        {
            // iniciar sesion
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            var vehiculosBtn = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[5]/a"));
            vehiculosBtn.Click();

            var btnEdit = firefox.FindElement(By.Id("editar-vehiculo"));
            btnEdit.Click();

            var placaField = firefox.FindElement(By.Id("id-placa"));
            placaField.Clear();
            string placa = "mod123";
            placaField.SendKeys(placa);
            var btnSave = firefox.FindElement(By.Id("id-save-edit"));
            btnSave.Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Vehiculos"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Vehiculos");
        }

        [TestMethod]
        public void CrearReserva()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //reserva
            var reservasBtn = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[6]/a"));
            reservasBtn.Click();

            var placaDrDo = firefox.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = firefox.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            selectEmpresa.SelectByText("Farenet");

            //review
            var dateField = firefox.FindElement(By.XPath("//*[@id='Fecha']"));
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var createBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            createBtn.Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Reservas"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EditarReserva()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            /*reservas*/
            firefox.Navigate().GoToUrl("http://localhost:5000/Reservas");
            var EditReservaBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[1]"));
            EditReservaBtn.Click();

            var placaDrDo = firefox.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = firefox.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            //otra Empresa
            selectEmpresa.SelectByText("ReviSeguros");

            var dateField = firefox.FindElement(By.XPath("//*[@id='Fecha']"));
            //mañana
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second); date = date.AddDays(1);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var saveBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            saveBtn.Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Reservas"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EliminarReserva()
        {
            //login
            var btnIngresar = firefox.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo10"; var password = "Abc123456!";
            var emailField = firefox.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = firefox.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            firefox.Navigate().GoToUrl("http://localhost:5000/Reservas");

            //reserva
            var DelReservaBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[3]"));
            DelReservaBtn.Click();

            var confirmDelBtn = firefox.FindElement(By.XPath("/html/body/div[1]/main/div/form/input[2]"));
            confirmDelBtn.Click();

            var wait = new WebDriverWait(firefox, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Reservas"));
            Assert.IsTrue(firefox.Url == "http://localhost:5000/Reservas");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (firefox == null) return;
            firefox.Quit();
            firefox.Dispose();
        }
    }
}