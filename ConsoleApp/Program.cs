using System.IO;
using DbfDataReader;
using System.Data.Odbc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        // Abrir a conexão com o arquivo MT.dbf
        var stream = new FileStream(@"C:\\ProjetoC#\\Dinho\\BancoDados\\MT.DBF", FileMode.Open);
        var reader = new DBFReader(stream);

        // Ler o primeiro registro do arquivo
        reader.Read();

        // Obter os valores do CPF e data de nascimento do registro
        string cpf = reader.GetString("CPF");
        string dataNascimento = reader.GetDateTime("DT_NASC").ToString("ddMMyyyy");

        // Fechar a conexão com o arquivo
        reader.Dispose();
        stream.Dispose();

        // Configurar o driver do Selenium
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        // var driver = new ChromeDriver(options);
        var driver = new ChromeDriver(@"C:\ChromeDriver");


        // Navegar até a página de login
        driver.Navigate().GoToUrl("https://cnp3.consorciocanopus.com.br/Newcon.AutoAtendimento.Web/valor-receber");

        // Preencher o campo de CPF
        var campoCpf = driver.FindElementById("inscricaoNacional");
        campoCpf.SendKeys(cpf);

        // Preencher o campo de data de nascimento
        var campoDataNascimento = driver.FindElementById("dataNascimentoFundacao");
        campoDataNascimento.SendKeys(dataNascimento);

        // Submeter o formulário
        var botaoEntrar = driver.FindElementByXPath("//button[contains(., 'Entrar')]");
        botaoEntrar.Click();

        // Fechar o driver
        driver.Quit();
    }
}