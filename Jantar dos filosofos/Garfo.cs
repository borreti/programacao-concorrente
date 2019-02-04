using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Garfo
    {
       public int NumGarfo { get; set; }
       public Mutex mutex { get; set; }

        public Garfo(int NumGarfo)
        {
            this.NumGarfo = NumGarfo;
            mutex = new Mutex();
        }
    }
}
