using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Filosofo
    {
        public int ID { get; set; }


        public Filosofo(int ID)
        {
            this.ID = ID;
        }

        private void Comer(Garfo g1, Garfo g2)
        {
            Console.WriteLine("\nFilosofo {0} aguarda os garfos ficarem disponíveis", ID);
            g1.mutex.WaitOne();
            g2.mutex.WaitOne();

            Random r = new Random();
            int tempoComendo = r.Next(0, 10000);
            Console.WriteLine("\nFilosofo {0} está comendo com os garfos {1} e {2}", ID, g1.NumGarfo, g2.NumGarfo);
            Thread.Sleep(tempoComendo);
            Console.WriteLine("\nFilosofo {0} terminou de comer e liberou os garfos {1} e {2}", ID, g1.NumGarfo, g2.NumGarfo);

            g1.mutex.ReleaseMutex();
            g2.mutex.ReleaseMutex();
        }

        private void Pensar()
        {
            Random r = new Random();
            int tempoPensando = r.Next(0, 10000);

            Console.WriteLine("\nFilosofo {0} está pensando", ID);
            Thread.Sleep(tempoPensando);
        }

        public void ComerEPensar(Garfo g1, Garfo g2)
        {
            while (true)
            {
                Pensar();
                Comer(g1, g2);
            }
        }
    }
}
