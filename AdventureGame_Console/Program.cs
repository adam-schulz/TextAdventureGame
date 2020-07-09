using AdventureGame_Console.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            AdventureGameUI ui = new AdventureGameUI();
            ui.Run();
        }
    }
}
