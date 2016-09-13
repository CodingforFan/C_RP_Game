using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //╔╗╚╝═║
            //Console.wi
            Console.Write("╔" + new string('═', Console.WindowWidth - 5) + "[X]" +"╗" );
            for (int i = 0; i < (Console.WindowHeight - 4); i++)
            {
                Console.Write("║" + new string(' ', Console.WindowWidth - 2) + "║");
            }
            Console.Write("╠" + new string('═', Console.WindowWidth - 2) + "╣");
            Console.Write("║" + new string(' ', Console.WindowWidth - 2) + "║");
            Console.Write("╚" + new string('═', Console.WindowWidth - 2) + "╝");
            //Console.SetCursorPosition(2, Console.CursorTop - 2);
            //Console.Write(Console.WindowHeight);
            Console.ReadKey();
        }
    }
}
