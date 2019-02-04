using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Restaurante
    {
        int nFilosofos;
        Filosofo [] vetorFilosofos;
        Garfo[] vetorGarfos;
        Thread[] vetorThreads;

        public Restaurante(int nFilosofos)
        {
            vetorFilosofos = new Filosofo[nFilosofos];
            vetorGarfos = new Garfo[nFilosofos];
            vetorThreads = new Thread[nFilosofos];

            for (int a = 0; a < vetorFilosofos.Length; a++)
            {
                vetorFilosofos[a] = new Filosofo(a);
                vetorGarfos[a] = new Garfo(a);
            }

            OrganizarGarfos();
        }

        private void OrganizarGarfos()
        {
            int i = 0;

            foreach(Filosofo f in vetorFilosofos)
            {
                if (f.ID < vetorFilosofos.Length - 1)
                    vetorThreads[i] = new Thread(() => f.ComerEPensar(vetorGarfos[f.ID], vetorGarfos[f.ID+1]));

                else
                    vetorThreads[i] = new Thread(() => f.ComerEPensar(vetorGarfos[f.ID], vetorGarfos[0]));

                i++;
            }
        }

        public void IniciarJantar()
        {
            foreach (Thread thread in vetorThreads)
                thread.Start();
        }
    }
}
