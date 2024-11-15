using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecursoCompartido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Panadero panadero1 = new Panadero("Ivan Tomasevski");
            Panadero panadero2 = new Panadero("Mama de Ivan");

            Cliente cliente1 = new Cliente("Paula");
            Cliente cliente2 = new Cliente("Chochu");

            Thread prod1 = new Thread(() => panadero1.Hornear());
            Thread prod2 = new Thread(() => panadero2.Hornear());

            Thread cons1 = new Thread(() => cliente1.Comprar());
            Thread cons2 = new Thread(() => cliente2.Comprar());

            prod1.Start();
            prod2.Start();
            cons1.Start();
            cons2.Start();

            prod1.Join();
            prod2.Join();
            cons1.Join();
            cons2.Join();

            Console.WriteLine("Panaderia Cerrada por hoy.");
            Console.ReadKey();

        }
    }
}
