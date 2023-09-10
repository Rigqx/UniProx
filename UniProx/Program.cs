using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniProx
{
    public class UniProx : UniProxBase
    {
        public static void logo()
        {
            Console.Clear();
            Console.Title = "UniProx v0.1 | BEST PROXY SCRAPER & CHECKER";
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"┬ ┬┌┐┌┬┌─┐┬─┐┌─┐─┐ ┬ │
│ │││││├─┘├┬┘│ │┌┴┬┘ │
└─┘┘└┘┴┴  ┴└─└─┘┴ └─ │
─────────────────────┘
");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Welcome to ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("UniProx!");
            Console.WriteLine();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Use ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" help, ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" For help commands!");
            Console.WriteLine();
        }

        public static void command()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n $ ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            String choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "help")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
 - Help | Shows list of help commands!
 - Clear | Clears the terminal!
 - Scrape | Scrapes a list of proxies!
 - Check | Checks a list of proxies!");
            }
            else if (choice == "clear")
            {
                UniProx.logo();
                UniProx.command();
            } else if (choice == "check") {
                Checker.check();
            }
            else if (choice == "scrape")
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Type? [HTTPS/SOCKS4/SOCKS5]");

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n $ ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                String proxyType = Console.ReadLine();
                Console.WriteLine();

                Scrape.ScrapeProxies(proxyType);
            } else {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"Unkown command!");
            }
            command();
        }
    }
}
