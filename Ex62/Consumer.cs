using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Consumer
    {

        public void Consumes(Buffer buffer)
        {

            buffer.semaphoreFull.WaitOne();
            buffer.mutex.WaitOne();

            int maxValue = 1000;
            Random r = new Random();
            char aux = buffer._Buffer[buffer._Buffer.Count - 1];
            Console.WriteLine("\nConsumidor consome: {0}", aux);
            buffer._Buffer.Remove(aux);

            if (buffer._Buffer.Count == 0)
                Console.WriteLine("Thread consumidora dorme.");

            buffer.mutex.ReleaseMutex();
            buffer.semaphoreEmpty.Release();

            Thread.Sleep(r.Next(0, maxValue));
        }
    }
}
