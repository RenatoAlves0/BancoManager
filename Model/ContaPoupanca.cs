//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace BancoManager.Model
{
    public class ContaPoupanca
    {
        public ContaPoupanca(decimal j, DateTime a, Cliente t, string agenciaId)
        {
            Juros = j;
            Aniversario = a;
            Titular = t;
            AgenciaId = agenciaId;
        }

        public decimal Saldo
        {
            get; set;
        }

        public Cliente Titular
        {
            get; set;
        }

        public decimal Juros
        {
            get; set;
        }

        public DateTime Aniversario
        {
            get; set;
        }

        public void Depositar(decimal v)
        {
            Saldo += v;
        }

        public void Sacar(decimal v)
        {
            if (v <= Saldo) Saldo -= v;
            else WriteLine("Valor não disponível.. Consulte seu saldo!");
        }

        public void AddRendimento()
        {
            if(DateTime.Now.Equals(Aniversario))
            {
                Depositar(Saldo * Juros);
            }
        }

        public string Id
        {
            get { return Titular.Id + "(CP)"; }
            set { }
        }

        public string AgenciaId{
            get; set;
        }

    }
}

//By Renato Alves de Oliveira
