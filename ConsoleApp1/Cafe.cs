using MenuItem_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItem_Console
{
    class Cafe
    {
        static void Main(string[] args) // [] after 'string' ???
        {
            CafeUI ui = new CafeUI();
            ui.Run();
        }
    }
}
