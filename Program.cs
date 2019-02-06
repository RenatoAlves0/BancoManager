//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using BancoManager.Model;
using System.Text;
//using (var context = new Context()) { }

namespace BancoManager
{
    public class Program
    {
        Context context = new Context();
        List<Banco> bancos = new List<Banco>();
        List<Cliente> clientes = new List<Cliente>();

        public static void Main(string[] args)
        {

            Program solicitacoes = new Program();

            solicitacoes.Logar();

            string op = "";

            while (!op.Equals("0"))
            {
                WriteLine("\n\nBem vind# ao BancoManager");
                WriteLine("0. Sair\n");

                WriteLine("Banco");
                WriteLine("1.1 Cadastrar");
                //WriteLine("1.2 Listar\n");

                WriteLine("Agência");
                WriteLine("2.1 Cadastrar");
                //WriteLine("2.2 Listar\n");

                WriteLine("Conta Poupança");
                WriteLine("3.1 Cadastrar");
                //WriteLine("3.2 Listar");
                //WriteLine("3.3 Saldo");
                //WriteLine("3.4 Depositar");
                //WriteLine("3.5 Sacar\n");

                WriteLine("Conta Corrente");
                WriteLine("4.1 Cadastrar");
                //WriteLine("4.2 Listar");
                //WriteLine("4.3 Saldo");
                //WriteLine("4.4 Depositar");
                //WriteLine("4.5 Sacar");
                Write("_");

                op = ReadLine();

                switch (op)
                {
                    case "1.1":
                        solicitacoes.AddBanco();
                        break;
                    case "1.2":
                        solicitacoes.ListBancos();
                        break;

                    case "2.1":
                        solicitacoes.AddAgencia();
                        break;
                    case "2.2":
                        solicitacoes.ListAgencias();
                        break;

                    case "3.1":
                        solicitacoes.AddContaPoupanca();
                        break;
                    case "3.2":
                        solicitacoes.ListContasPoupanca();
                        break;
                    case "3.3":
                        solicitacoes.ConsultarContaPoupanca();
                        break;
                    case "3.4":
                        solicitacoes.DepositarContaPoupanca();
                        break;
                    case "3.5":
                        solicitacoes.SacarContaPoupanca();
                        break;

                    case "4.1":
                        solicitacoes.AddContaCorrente();
                        break;
                    case "4.2":
                        solicitacoes.ListContasCorrente();
                        break;
                    case "4.3":
                        solicitacoes.ConsultarContaCorrente();
                        break;
                    case "4.4":
                        solicitacoes.DepositarContaCorrente();
                        break;
                    case "4.5":
                        solicitacoes.SacarContaCorrente();
                        break;
                }
            }
        }

        public Cliente Eu
        {
            get; set;
        }

        public Cliente Logar()
        {
            Cliente cliente = new Cliente();

            WriteLine("Para começar informe seu CPF: ");
            WriteLine("Coloque apenas números -> 00000000000 ");
            Write("_");
            cliente.Id = ReadLine();
            Eu = SearchCliente(cliente.Id);

            if (Eu == null)
            {
                WriteLine("\nPercebemos que você ainda não está cadastrad#!");
                WriteLine("Informe seu nome, para poder-mos lhe cadastrar ");
                Write("_");
                cliente.Nome = ReadLine();

                AddCliente(cliente);
                Eu = cliente;
                WriteLine("\nBem vind# " + cliente.Nome + " !\n");
                return Eu;
            }
            else
            {
                WriteLine("\nBem vind# " + Eu.Nome + " !");
                return Eu;
            }
        }

        public Cliente SearchCliente(string id)
        {
            try
            {
                var cliente = context.Clientes
                .Single(c => c.Id == id);
                return cliente;
            }
            catch (Exception)
            {
                WriteLine("\n!!! Cliente não cadastrado !!!\n");
                return null;
            }
        }

        public void AddCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void AddBanco()
        {
            WriteLine("\n*** Novo Banco ***\n");
            Banco b = new Banco();
            Write("Nome: ");
            b.Nome = ReadLine();
            Write("Identificador: ");
            b.Id = ReadLine();

            //bancos.Add(b);
            context.Bancos.Add(b);
            context.SaveChanges();
        }

        public void ListBancos()
        {
            WriteLine("\n*** Bancos ***\n");
            int i = 1;
            foreach (var b in bancos)
            {
                WriteLine(i + ".\nNome: " + b.Nome + "\nId: " + b.Id + "\n");
                i++;
            }
        }

        public Banco SearchBanco(string id)
        {
            using (var dataBase = new Context())
            {
                try
                {
                    var banco = dataBase.Bancos
                    .Single(b => b.Id == id);
                    return banco;
                }
                catch (Exception)
                {
                    WriteLine("\n!!! Banco não cadastrado !!!\n");
                    return null;
                }
            }
        }

        public void AddAgencia()
        {
            WriteLine("\n*** Dados do Banco ***\n");
            Banco banco;
            string opcao = "";
            Agencia agencia = new Agencia();

            Write("Identificador: ");
            banco = SearchBanco(ReadLine());
            if (banco == null) return;
            else
            {
                WriteLine("\n*** Nova Agência do " + banco.Nome + " ***\n");

                Write("Nome: ");
                agencia.Nome = ReadLine();
                Write("Identificador: ");
                agencia.Id = ReadLine();

                agencia.BandoId = banco.Id;
                context.Agencias.Add(agencia);
                context.SaveChanges();
                // banco.AddAgencia(agencia);

            }

            Write("\nCadastrar nova Agência? S/N :");
            opcao = ReadLine();

            if (opcao.ToLower().Equals("s"))
            {
                WriteLine("\n");
                AddAgencia();
            }
            else return;


        }

        public void ListAgencias()
        {
            WriteLine("\n*** Dados do Banco ***\n");
            Banco banco;
            Write("Identificador: ");
            banco = SearchBanco(ReadLine());
            if (banco != null) banco.ListAgencias();
        }

        // Poupança

        public void AddContaPoupanca()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;
            else
            {
                WriteLine("\n*** Dados da Conta ***\n");
                Write("Taxa de juros: ");
                decimal juros = Convert.ToDecimal(ReadLine());

                agencia.AddCp(juros, DateTime.Now, Eu, agencia.Id);
                agencia.ExibirCp(Eu.Id);
            }
        }

        public void ListContasPoupanca()
        {
            IdentificarAgencia().ListarCps();
        }

        public void ConsultarContaPoupanca()
        {
            IdentificarAgencia().ExibirCp(Eu.Id);
        }

        public void DepositarContaPoupanca()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do depósito: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.DepositarPoupanca(Eu.Id, valor);
        }

        public void SacarContaPoupanca()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do saque: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.SacarPoupanca(Eu.Id, valor);
        }

        // Corrente

        public void AddContaCorrente()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;
            else
            {
                agencia.AddCc(Eu, agencia.Id);
                agencia.ExibirCc(Eu.Id);
            }
        }

        public void ListContasCorrente()
        {
            IdentificarAgencia().ListarCcs();
        }

        public void ConsultarContaCorrente()
        {
            IdentificarAgencia().ExibirCc(Eu.Id);
        }

        public void DepositarContaCorrente()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do depósito: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.DepositarCorrente(Eu.Id, valor);
        }

        public void SacarContaCorrente()
        {
            Agencia agencia = IdentificarAgencia();
            if (agencia == null) return;

            Write("Valor do saque: R$ ");
            decimal valor = Convert.ToDecimal(ReadLine());
            agencia.SacarCorrente(Eu.Id, valor);
        }

        //Generic

        public Agencia IdentificarAgencia()
        {
            WriteLine("\n*** Dados do Banco ***\n");
            Agencia agencia;
            Banco banco;

            Write("Idenditifcador: ");
            banco = SearchBanco(ReadLine());
            if (banco == null)
            {
                WriteLine("\n!!! Banco não cadastrado !!!\n");
                WriteLine("\n!!! É necessário cadastrar um Banco antes de realizar esta operação !!!\n");
                return null;
            }
            else
            {
                WriteLine("\n*** Dados da Agência ***\n");
                Write("Identificador: ");
                agencia = banco.BuscarAgencia(ReadLine());
                if (agencia == null)
                {
                    WriteLine("\n!!! É necessário cadastrar uma Agência antes de realizar esta operação !!!\n");
                    return null;
                }
                else return agencia;
            }
        }
    }
}

//By Renato Alves de Oliveira
