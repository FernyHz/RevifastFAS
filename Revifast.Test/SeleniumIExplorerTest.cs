using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Revifast.Test
{
    [TestClass]
    public class SeleniumIExplorerTest
    {
        private IWebDriver iexplorer;

        [TestInitialize]
        public void Initialize()
        {
            iexplorer = new InternetExplorerDriver();
            iexplorer.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            iexplorer.Manage().Window.Maximize();
            iexplorer.Navigate().GoToUrl("http://localhost:5000");
        }

        [TestMethod]
        public void CrearCuenta()
        {
            var registerButton = iexplorer.FindElement(By.CssSelector("a.nav-link.text-white.btn.btn-outline-primary.active"));
            registerButton.Click();
            var username = "juantopo12";
            var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var passwordConfirmField = iexplorer.FindElement(By.Id("Input_ConfirmPassword"));
            passwordConfirmField.SendKeys(password);
            passwordConfirmField.Submit();
            var usernameLabel = iexplorer.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestMethod]
        public void IniciarSesion()
        {
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();

            var username = "juantopo12"; var password = "Abc123456!";

            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);

            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            Thread.Sleep(TimeSpan.FromSeconds(5));
            var usernameLabel = iexplorer.FindElement(By.CssSelector("a.nav-link.text-light.text-capitalize"));
            Assert.AreEqual($"Hola {username}!".ToLower(), usernameLabel.Text.ToLower());
        }

        [TestMethod]
        public void EditarDatosConductor()
        {
            // iniciar sesion
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();
            var username = "juantopo12"; var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            // ir a la vista conductor
            var btnConductor = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[4]/a"));
            btnConductor.Click();

            // seleccionar registrar datos
            var btnRegistrarDatos = iexplorer.FindElement(By.Id("id-registrar-datos"));
            btnRegistrarDatos.Click();

            // registra datos
            var nombre = "Juan";
            var nombreField = iexplorer.FindElement(By.Id("id-conductor-nombre"));
            nombreField.SendKeys(nombre);
            var apellido = "Topos";
            var apellidoField = iexplorer.FindElement(By.Id("id-conductor-apellido"));
            apellidoField.SendKeys(apellido);
            var dni = "01234567";
            var dniField = iexplorer.FindElement(By.Id("id-conductor-dni"));
            dniField.SendKeys(dni);
            var celular = "912345678";
            var celularField = iexplorer.FindElement(By.Id("id-conductor-celular"));
            celularField.SendKeys(celular);
            var btnRegistrar = iexplorer.FindElement(By.Id("id-conductor-btn-registrar"));
            btnRegistrar.Click();

            var wait = new WebDriverWait(iexplorer, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Conductores"));
            Assert.IsTrue(iexplorer.Url == "http://localhost:5000/Conductores");
        }

        [TestMethod]
        public void CrearVehiculo()
        {
            //login
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo12"; var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            var vehiculosBtn = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[5]/a"));
            vehiculosBtn.Click();
            var addAutoBtn = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/p/a")); addAutoBtn.Click();

            var placaField = iexplorer.FindElement(By.XPath("//*[@id='Placa']"));
            var modeloField = iexplorer.FindElement(By.XPath("//*[@id='Modelo']"));
            var categoriaField = iexplorer.FindElement(By.XPath("//*[@id='Categoria']"));
            string placa = "AFS203"; string modelo = "picanto"; string categoria = "D2";
            placaField.SendKeys(placa); modeloField.SendKeys(modelo); categoriaField.SendKeys(categoria);

            //click crear
            iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input")).Click();

            var wait = new WebDriverWait(iexplorer, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Vehiculos"));
            Assert.IsTrue(iexplorer.Url == "http://localhost:5000/Vehiculos");
        }

        [TestMethod]
        public void EditarVehiculo()
        {
            // iniciar sesion
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a"));
            btnIngresar.Click();
            var username = "juantopo12"; var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            var vehiculosBtn = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[5]/a"));
            vehiculosBtn.Click();

            var btnEdit = iexplorer.FindElement(By.Id("editar-vehiculo"));
            btnEdit.Click();

            var placaField = iexplorer.FindElement(By.Id("id-placa"));
            placaField.Clear();
            string placa = "mod123";
            placaField.SendKeys(placa);
            var btnSave = iexplorer.FindElement(By.Id("id-save-edit"));
            btnSave.Click();

            var wait = new WebDriverWait(iexplorer, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Vehiculos"));
            Assert.IsTrue(iexplorer.Url == "http://localhost:5000/Vehiculos");
        }

        [TestMethod]
        public void CrearReserva()
        {
            //login
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo12"; var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            //reserva
            var reservasBtn = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[2]/li[6]/a"));
            reservasBtn.Click();

            var placaDrDo = iexplorer.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = iexplorer.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            selectEmpresa.SelectByText("Farenet");

            //review
            var dateField = iexplorer.FindElement(By.XPath("//*[@id='Fecha']"));
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var createBtn = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            createBtn.Click();

            var wait = new WebDriverWait(iexplorer, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Reservas"));
            Assert.IsTrue(iexplorer.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EditarReserva()
        {
            //login
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo12"; var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            /*reservas*/
            iexplorer.Navigate().GoToUrl("http://localhost:5000/Reservas");
            var EditReservaBtn = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[1]"));
            EditReservaBtn.Click();

            var placaDrDo = iexplorer.FindElement(By.XPath("//*[@id='VehiculoId']")); //select dropdown list
            var selectPlaca = new SelectElement(placaDrDo); //create SelectElement object
            selectPlaca.SelectByText("AFS203"); //or selectPlaca.SelectByValue("2");

            var empresaDrDo = iexplorer.FindElement(By.XPath("//*[@id='EmpresaId']"));
            var selectEmpresa = new SelectElement(empresaDrDo);
            //otra Empresa
            selectEmpresa.SelectByText("ReviSeguros");

            var dateField = iexplorer.FindElement(By.XPath("//*[@id='Fecha']"));
            //mañana
            DateTime date = DateTime.Now;
            date = date.AddSeconds(-date.Second); date = date.AddDays(1);
            dateField.SendKeys(date.ToShortDateString() + "\t" + date.ToShortTimeString());

            var saveBtn = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div/form/div[5]/input"));
            saveBtn.Click();

            var wait = new WebDriverWait(iexplorer, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Reservas"));
            Assert.IsTrue(iexplorer.Url == "http://localhost:5000/Reservas");
        }

        [TestMethod]
        public void EliminarReserva()
        {
            //login
            var btnIngresar = iexplorer.FindElement(By.XPath("/html/body/header/nav/div/div/ul[1]/li[2]/a")); btnIngresar.Click();
            var username = "juantopo12"; var password = "Abc123456!";
            var emailField = iexplorer.FindElement(By.Id("Input_Email"));
            emailField.SendKeys($"{username}@email.com");
            var passwordField = iexplorer.FindElement(By.Id("Input_Password"));
            passwordField.SendKeys(password);
            var loginButton = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/div[1]/section/form/div[5]/button"));
            loginButton.Click();

            iexplorer.Navigate().GoToUrl("http://localhost:5000/Reservas");

            //reserva
            var DelReservaBtn = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/table/tbody/tr/td[5]/a[3]"));
            DelReservaBtn.Click();

            var confirmDelBtn = iexplorer.FindElement(By.XPath("/html/body/div[1]/main/div/form/input[2]"));
            confirmDelBtn.Click();

            var wait = new WebDriverWait(iexplorer, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:5000/Reservas"));
            Assert.IsTrue(iexplorer.Url == "http://localhost:5000/Reservas");
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (iexplorer == null) return;
            iexplorer.Quit();
            iexplorer.Dispose();
        }
    }
}
