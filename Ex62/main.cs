// programa Ex62.cs
// programadores: Robert Victor Souza Cunha, Breno Vieira Soares, Jõao Gontijo
// data: 26/05/2018
// descricao: Problema do produtor e consumidor usando semaforo
// entrada(s): Nome e matrícula dos alunos
// saida(s: Produtor Consumidor sincronizado

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Ex62
    {
		
        static string characters;
        static Buffer b = new Buffer();
        static Producer p = new Producer();
        static Consumer c = new Consumer();
        static int lenght;

        static void Main(string[] args)
        {

            Console.WriteLine("Integrantes do grupo: Robert Victor Souza Cunha, Breno Vieira Soares, Jõao Gontijo \nArquivo fonte: Ex61.cs");

            foreach (string arg in args)
                 characters += arg;

            lenght = characters.Length - 1;

            Thread tProducer = new Thread(ThreadProducer);
            Thread tConsumer = new Thread(ThreadConsumer);

            tProducer.Start();
            tConsumer.Start();

            Console.ReadKey();
        }

        static void ThreadProducer()
        {
            while (lenght >= 0) //Enquanto houver caracteres para serem produzidos
            {
                char item = characters[lenght]; //Seleciona o item a ser produzido
                p.Produz(b, item); //Item é alocado no buffer
                lenght--; //Menos um item a ser produzido
            }
        }

        static void ThreadConsumer()
        {
            while (!b.BufferVazio() || lenght >=0) //Enquanto houver caracteres para serem produzidos ou o buffer não estiver completamente vazio
            {
                c.Consumes(b); //objeto consumer consome mais um caracter
            }
        }

    }
}
