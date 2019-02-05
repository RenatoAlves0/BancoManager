//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace BancoManager.Model
{
    public class Banco
    {
        public List<Agencia> agencias = new List<Agencia>();

        public string Nome
        {
            get; set;
        }

        public string Id
        {
            get; set;
        }

        public void AddAgencia (Agencia a)
        {
            agencias.Add(a);
        }

        public void ListAgencias ()
        {
            WriteLine("*** LISTA DE AGÊNCIAS ***");

            int i = 1;
            foreach (var a in agencias)
            {
                WriteLine(i + "\n Nome: " + a.Nome + "\n Id: " + a.Id);
                i++;
            }
        }

        public int BuscarAgencia (string id)
        {
            foreach (var a in agencias)
            {
                if (id.Equals(a.Id)) return agencias.IndexOf(a);
            }

            WriteLine("!!! Agência não cadastrada !!!");
            return -1;
        }
    }
}

//By Renato Alves de Oliveira
