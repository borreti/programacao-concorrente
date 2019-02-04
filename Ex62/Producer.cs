using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Producer
    {

        public void Produz(Buffer buffer, char item)
        {
       
            buffer.semaphoreEmpty.WaitOne();
            buffer.mutex.WaitOne();

            Random r = new Random();
            int maxValue = 1000;
            buffer._Buffer.Add(item);
            Console.WriteLine("\nProdutor produz: {0}", item);

            if (buffer._Buffer.Count == 10)
                Console.WriteLine("Thread produtora dorme.");

           buffer.mutex.ReleaseMutex();
           buffer.semaphoreFull.Release();



            Thread.Sleep(r.Next(0, maxValue));
        }
    }
}
