using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Pessoa
    {
        public string? CPF { get; set; }
        public string? Digito { get; set; }
        public string? Nome { get; set; }
        public string? Nascimento { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }
        public string? DDD { get; set; }
        public string? Telefone { get; set; }

        public Pessoa(string? cpf, string? digito, string? nome, string? nascimento, string? endereco, string? bairro, string? cidade, string? uf, string? cep, string? ddd, string? telefone)
        {
            CPF = cpf;
            Digito = digito;
            Nome = nome;
            Nascimento = nascimento;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            CEP = cep;
            DDD = ddd;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return
                $"Nome: {Nome}, CPF: {CPF}, Digito: {Digito}, Nascimento: {Nascimento}, Endereço: {Endereco}, Bairro: {Bairro}, Cidade: {Cidade}, UF: {UF}" +
                $"CEP: {CEP}, DDD: {DDD}, Telefone: {Telefone}";
        }
    }
}
