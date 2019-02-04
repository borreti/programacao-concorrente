using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Barbeiro
    {
        public bool Dormindo { get; set; }

        public void FazerBarba(Cliente cliente)
        {
            int limiteE = 0, limiteD = 10000;
            Random r = new Random();
            Console.WriteLine("\nBarbeiro inicia a barba do cliente {0}.", cliente.ID);
            Thread.Sleep(r.Next(limiteE, limiteD));
            Console.WriteLine("\nBarba finalizada.");
        }

        public void Dormir()
        {
            Console.WriteLine("\nBarbeiro dorme.");
            Dormindo = true;
        }

        public void Acordar()
        {
            Console.WriteLine("\nBarbeiro acorda.");
            Dormindo = false;
        }
    }
}
