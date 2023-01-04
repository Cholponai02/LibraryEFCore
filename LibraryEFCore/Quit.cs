using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEFCore
{/// <summary>
/// Выход 
/// </summary>
    internal class Quit
    {
        /// <summary>
        /// выход
        /// </summary>
        public static void ExitFromApp()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Пока\n Хорошего дня!");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
    }
}
