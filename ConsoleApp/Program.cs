using System.Data;
using System.IO;
using DbfDataReader;
using System.Data.Odbc;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleApp;
using Microsoft.Office.Interop.Outlook;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

internal class Program
{
    private static void Main(string[] args)
    {
        // Configurar o driver do Selenium
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        // var driver = new ChromeDriver(options);
        var driver = new EdgeDriver(@"C:\Webdriver\msedgedriver.exe");

        var dbfPath = "C:\\Users\\jbrun\\Downloads\\ProjetoC#\\ProjetoC#\\Dinho\\BancoDados\\MT.dbf";
        var skipDeleted = true;
        List<string> valores = new List<string>();

        using (var dbfTable = new DbfTable(dbfPath, Encoding.UTF8))
        {
            var dbfRecord = new DbfRecord(dbfTable);

            while (dbfTable.Read(dbfRecord))
            {
                if (skipDeleted && dbfRecord.IsDeleted)
                {
                    continue;
                }


                //foreach (var dbfValue in dbfRecord.Values)
                //{
                //    var teste = dbfValue.GetValue();
                //}

                Pessoa p = new Pessoa(dbfRecord.GetValue(0).ToString(), dbfRecord.GetValue(1).ToString(),
                    dbfRecord.GetValue(2).ToString(),
                    dbfRecord.GetValue(3).ToString(), dbfRecord.GetValue(4).ToString(),
                    dbfRecord.GetValue(5).ToString(), dbfRecord.GetValue(6).ToString(),
                    dbfRecord.GetValue(7).ToString(), dbfRecord.GetValue(8).ToString(),
                    dbfRecord.GetValue(9).ToString(), dbfRecord.GetValue(10).ToString());

                Console.WriteLine($"{p}\n");
                break;
            }

        }


        // Navegar até a página de login
        driver.Navigate().GoToUrl("https://cnp3.consorciocanopus.com.br/Newcon.AutoAtendimento.Web/valor-receber");

        // Preencher o campo de CPF
        var campo = GetCpfInputWebElement();
        campo.Click();
        Thread.Sleep(1000);

        var campoNascimento = GetNascimentoInputWebElement();
        campoNascimento.Click();
        Thread.Sleep(1000);

        // Fechar o driver
        driver.Quit();


        IWebElement GetCpfInputWebElement()
        {
            var campoCPF= new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("html.h100 body#block-sub-menu.h100 div#root.h100 div main.sc-bxivhb.lhSCcI div.box-login.sc-ifAKCX.iymHTE form.ant-form.ant-form-horizontal.nw-form.sc-EHOje.edRFCv div.ant-row.ant-form-item.nw-form-item.sc-bZQynM.bCqhlb div.ant-form-item-control-wrapper div.ant-form-item-control span.ant-form-item-children input#inscricaoNacional.ant-input.nw-input.sc-dnqmqq.cSUyVI")));
            return campoCPF;
        }

        IWebElement GetNascimentoInputWebElement()
        {
            var campo = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("html.h100 body#block-sub-menu.h100 div#root.h100 div main.sc-bxivhb.lhSCcI div.box-login.sc-ifAKCX.iymHTE form.ant-form.ant-form-horizontal.nw-form.sc-EHOje.edRFCv div.ant-row.ant-form-item.nw-form-item.sc-bZQynM.bCqhlb div.ant-form-item-control-wrapper div.ant-form-item-control span.ant-form-item-children input#dataNascimentoFundacao.ant-input.nw-input.sc-dnqmqq.cSUyVI")));
            return campo;
        }
    }

}

