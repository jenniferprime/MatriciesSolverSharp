using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriciesSolverSharp_Net
{
    internal class Program
    {
        public static bool debug_enable_global = true;
        static void Main(string[] args)
        {
            //Setup the thing
            Console.WriteLine("Hello, welcome to MatriciesSolverSharp (.NET), version: idk");

            MatriciesSolverSharpMenu menu = new MatriciesSolverSharpMenu();
            menu.InitializeCLIMenu();
            menu.RunCLIMenu();
            menu.FinalizeCLIMenu();

            if (debug_enable_global)
            {
                Console.WriteLine("[Debug] Execution finished, for debugging purposes the process is only closed after [Return]-Key was receieved.");
                Console.ReadLine();
            }
        
        }
    }
}
