using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecursoCompartido
{
    public class Cliente
    {
        public string Nombre { get; set; }

        public static readonly object ClienteLock = new object();
        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        public void Comprar()
        {
            string pan;

            while (true)
            {
                Monitor.Enter(ClienteLock);

                try
                {
                    Monitor.Enter(RecursoCompartido.RCLock);

                    if(RecursoCompartido.panes.Count == 0)
                    {
                        Monitor.Wait(RecursoCompartido.RCLock);
                    }


                    pan = RecursoCompartido.panes.Dequeue();

                    Console.WriteLine($"El cliente {this.Nombre} compro {pan}");

                    Monitor.Pulse(RecursoCompartido.RCLock);
                    
                    Monitor.Exit(RecursoCompartido.RCLock);

                    Thread.Sleep(new Random().Next(50, 100));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    
                    Monitor.Exit(ClienteLock);
                }
            }
        }
    }
}
