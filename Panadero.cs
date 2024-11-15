using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecursoCompartido
{
    public class Panadero
    {
        public string Nombre {  get; set; }

        public Panadero(string name)
        {
            Nombre = name;
        }

        public void Hornear()
        {
            for(int i = 1; i <= 10; i++)
            {
                Monitor.Enter(RecursoCompartido.RCLock);

                RecursoCompartido.panes.Enqueue($"Pan {i}");
                Console.WriteLine($"El panadero {this.Nombre} horneo el Pan {i}");

                Monitor.Pulse(RecursoCompartido.RCLock);

                Monitor.Exit(RecursoCompartido.RCLock);

                Thread.Sleep(new Random().Next(100, 400));
            }
        }

    }
}
