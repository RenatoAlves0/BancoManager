//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace BancoManager.Model
{
    public class Agencia
    {

        public List<ContaCorrente> contasCorrentes = new List<ContaCorrente>();
        public List<ContaPoupanca> contasPoupancas = new List<ContaPoupanca>();

        public string Nome
        {
            get; set;
        }

        public string Id
        {
            get; set;
        }

        public string BandoId
        {
            get; set;
        }

        // Poupança

        public void AddCp(decimal juros, DateTime aniversario, Cliente cliente, string agenciaId)
        {
            using (var context = new Context())
            {
                try
                {
                    ContaPoupanca cp = new ContaPoupanca(juros, aniversario, cliente, agenciaId);
                    context.ContasPoupanca.Add(cp);
                    context.SaveChanges();
                    WriteLine("\nConta cadastrada com sucesso !\n");

                }
                catch (Exception)
                {
                    WriteLine("Você não pode ter duas Contas Poupança!");
                }
            }
        }

        public void ListarCps()
        {
            Write("\n");
            int i = 1;
            foreach (var c in contasPoupancas)
            {
                WriteLine(i + "\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id + "\n Aniversário: " + c.Aniversario);
                i++;
            }
            Write("\n");
        }

        public ContaPoupanca SearchCP(string id)
        {
            string idConta = id + "(CP)";
            foreach (var c in contasPoupancas)
            {
                if (idConta.Equals(c.Id))
                {
                    return c;
                }
            }

            Write("!!! Conta não encontrada !!!");
            return null;
        }

        public void ExibirCp(ContaPoupanca c)
        {
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id + "\n Aniversário: " + c.Aniversario);
        }

        public void ExibirCp(string id)
        {
            ContaPoupanca c = SearchCP(id);
            if (c == null) return;
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id + "\n Aniversário: " + c.Aniversario);
        }

        public void DepositarPoupanca(string id, decimal valor)
        {
            ContaPoupanca conta = SearchCP(id);
            if (conta == null) return;

            conta.Depositar(valor);
            ExibirCp(conta);
        }

        public void SacarPoupanca(string id, decimal valor)
        {
            ContaPoupanca conta = SearchCP(id);
            if (conta == null) return;

            conta.Sacar(valor);
            ExibirCp(conta);
        }

        // Corrente

        public void AddCc(Cliente cliente, string agenciaId)
        {
            using (var context = new Context())
            {
                try
                {
                    ContaCorrente cc = new ContaCorrente(cliente, agenciaId);
                    context.ContasCorrente.Add(cc);
                    context.SaveChanges();
                    WriteLine("\nConta cadastrada com sucesso !\n");

                }
                catch (Exception)
                {
                    WriteLine("Você não pode ter duas Contas Corrente!");
                }
            }
        }

        public void ListarCcs()
        {
            Write("\n");
            int i = 1;
            foreach (var c in contasCorrentes)
            {
                WriteLine(i + "\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id);
                i++;
            }
            Write("\n");
        }

        public ContaCorrente SearchCC(string id)
        {
            string idConta = id + "(CC)";
            foreach (var c in contasCorrentes)
            {
                if (idConta.Equals(c.Id))
                {
                    return c;
                }
            }

            Write("!!! Conta não encontrada !!!");
            return null;
        }

        public void ExibirCc(ContaCorrente c)
        {
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id);
        }

        public void ExibirCc(string id)
        {
            ContaCorrente c = SearchCC(id);
            if (c == null) return;
            WriteLine("\n Titular: " + c.Titular.Nome + "\n Saldo: " + c.Saldo + "\n Id: " + c.Id);
        }

        public void DepositarCorrente(string id, decimal valor)
        {
            ContaCorrente conta = SearchCC(id);
            if (conta == null) return;

            conta.Depositar(valor);
            ExibirCc(conta);
        }

        public void SacarCorrente(string id, decimal valor)
        {
            ContaCorrente conta = SearchCC(id);
            if (conta == null) return;

            conta.Sacar(valor);
            ExibirCc(conta);
        }
    }
}

//By Renato Alves de Oliveira
