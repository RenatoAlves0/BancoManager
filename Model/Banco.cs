//By Renato Alves de Oliveira

using System;
using static System.Console;
using System.Linq;
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

        public Agencia BuscarAgencia (string id)
        {
            using (var context = new Context()) {
                try
                {
                    var agencia = context.Agencias
                    .Single(a => a.Id == id);
                    return agencia;
                }
                catch (Exception)
                {
                    WriteLine("\n!!! Agência não cadastrada !!!\n");
                    return null;
                }
            }
        }
    }
}

//By Renato Alves de Oliveira
