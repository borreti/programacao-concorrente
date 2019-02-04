using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Barbearia
    {
        int contador = 1;
        Semaphore semaphoreClientes = new Semaphore(5, 5);
        Semaphore semaphoreBarbeiro = new Semaphore(0, 5);
        Mutex mutex = new Mutex();
        Barbeiro Barbeiro1 { get; set; }
        Queue<Cliente> FilaClientes { get; set; }
        int limiteE = 0, limiteD = 10000; //limite inferior e superior do tempo entre cada cliente chegar

        public Barbearia()
        {
            Barbeiro1 = new Barbeiro();
            FilaClientes = new Queue<Cliente>();
        }

        public void TBarbeiro()
        {
            while (true)
            {
                if (FilaClientes.Count == 0 && !Barbeiro1.Dormindo)
                {
                    Console.WriteLine("\nNão há clientes na fila. Thread do barbeiro será bloqueada");
                    Barbeiro1.Dormir();
                }

                semaphoreBarbeiro.WaitOne();
                mutex.WaitOne();
                Cliente clienteFazendoBarba = FilaClientes.Dequeue(); //tira cliente da fila
                mutex.ReleaseMutex();
                Barbeiro1.FazerBarba(clienteFazendoBarba); //Barbeiro faz a barba do cliente
                semaphoreClientes.Release(); //incrementa no semaforo de clientes                   
            }
        }

    public void TNovosCliente()
    {
        while (true)
        {
            Random r = new Random();
            Thread.Sleep(r.Next(limiteE, limiteD));
            mutex.WaitOne();
            Cliente novoCliente = new Cliente(contador); //novo cliente gerado
            contador++;
            FilaClientes.Enqueue(novoCliente);//novo cliente adiciona a fila de espera
			
			 if (FilaClientes.Count == 5)
                    Console.WriteLine("\nFila de clientes está cheia. Thread de novos clientes será bloqueada.");
				
			semaphoreClientes.WaitOne();
            Console.WriteLine("\nCliente {0} entrou na fila.", novoCliente.ID);


                if (Barbeiro1.Dormindo) //se o barbeiro estiver dormindo
            {
                Barbeiro1.Acordar(); //acorda o barbeiro
            }

                semaphoreBarbeiro.Release();

            mutex.ReleaseMutex();
        }
    }
}
}
