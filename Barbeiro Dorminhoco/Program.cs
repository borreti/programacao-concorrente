using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Barbearia barbearia = new Barbearia();

            Thread ThreadBarbearia = new Thread(barbearia.TBarbeiro);
            Thread ThreadNovosClientes = new Thread(barbearia.TNovosCliente);

            ThreadBarbearia.Start();
            ThreadNovosClientes.Start();
        }
    }
}
