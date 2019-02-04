using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Buffer
    {
        public List<char> _Buffer { get; set; }
        public Semaphore semaphoreFull { get; set; }
        public Semaphore semaphoreEmpty { get; set; }
        public Mutex mutex { get; set; }

        public Buffer()
        {
            _Buffer = new List<char>();
            semaphoreFull = new Semaphore(0, 10);
            semaphoreEmpty = new Semaphore(10, 10);
            mutex = new Mutex();
        }
		
		 public bool BufferVazio()
        {
            if (_Buffer.Count == 0)
                return true;

            return false;
        }
    }
}
