//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace BancoManager.Model
{
    public class ContaCorrente
    {
        public ContaCorrente(Cliente t)
        {
            Titular = t;
        }

        public const decimal Taxa = 0.10M;

        public decimal Saldo
        {
            get; set;
        }

        public Cliente Titular
        {
            get; set;
        }

        public string Id
        {
            get { return Titular.Id + "(CC)"; }
            set { }
        }

        public virtual void Depositar(decimal v)
        {
            Saldo += (v - (v * Taxa));
        }

        public virtual void Sacar(decimal v)
        {
            if ((v + (v * Taxa)) <= Saldo) Saldo -= (v + (v * Taxa));
            else WriteLine("Valor não disponível.. Consulte seu saldo!");
        }
    }
}

//By Renato Alves de Oliveira
