using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercicios
{
    class Cliente
    {
        public int ID { get; set; }
        public bool EmEspera { get; set; }

        public Cliente (int ID)
        {
            this.ID = ID;
            EmEspera = false;
        }

    }
}
