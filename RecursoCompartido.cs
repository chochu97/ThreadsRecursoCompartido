using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursoCompartido
{
    public class RecursoCompartido
    {
        public static Queue<string> panes = new Queue<string>();

        public static object RCLock = new object();


    }
}
