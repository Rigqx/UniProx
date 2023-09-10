using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniProx
{
    public class Scrape
    {
        public static void ScrapeProxies(String type)
        {
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[!] Scraping proxies... (" + type + ")");
                WebClient wc = new WebClient();
                string proxyScrape = wc.DownloadString($"https://api.proxyscrape.com/v2/?request=displayproxies&protocol={type}&timeout=10000&country=all&ssl=all&anonymity=all");
                string proxyScan = wc.DownloadString($"https://www.proxyscan.io/download?type={type}.txt");
                string githubProxy = wc.DownloadString($"https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/{type}.txt");
                string githubProxy1 = wc.DownloadString($"https://raw.githubusercontent.com/jetkai/proxy-list/blob/main/online-proxies/txt/proxies-" + type + ".txt");
                string githubProxy2 = wc.DownloadString($"https://raw.githubusercontent.com/jetkai/proxy-list/blob/main/archive/txt/proxies-" + type + ".txt");
                string githubProxy3 = wc.DownloadString($"https://raw.githubusercontent.com/ShiftyTR/Proxy-List/master/{type}.txt");
                string githubProxy4 = wc.DownloadString($"https://raw.githubusercontent.com/UptimerBot/proxy-list/main/proxies/{type}.txt");
                string githubProxy5 = wc.DownloadString($"https://raw.githubusercontent.com/roosterkid/openproxylist/main/" + type.ToUpper() + "_RAW.txt");
                string githubProxy6 = wc.DownloadString($"https://raw.githubusercontent.com/clarketm/proxy-list/master/proxy-list-raw.txt");
                string githubProxy7 = wc.DownloadString($"https://api.good-proxies.ru/getfree.php?count=1000&ping=8000&time=600&works=500&key=freeproxy");
                string githubProxy8 = wc.DownloadString($"https://raw.githubusercontent.com/ShiftyTR/Proxy-List/master/proxy.txt");
                string githubProxy9 = wc.DownloadString($"https://raw.githubusercontent.com/clarketm/proxy-list/master/proxy-list-raw.txt");
                string rootjazz = wc.DownloadString($"http://rootjazz.com/proxies/proxies.txt");

                string data = rootjazz + proxyScrape + proxyScan + githubProxy + githubProxy1 + githubProxy2 + githubProxy3 + githubProxy4 + githubProxy5 + githubProxy6 + githubProxy7 + githubProxy8 + githubProxy9;

                File.WriteAllText(Environment.CurrentDirectory + "/scraped-" + date + ".txt", data);
                Console.WriteLine("[!] Proxies scraped..!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[!] Could not download any proxies..\nPress a key to goto main menu...");
                Console.WriteLine("Error - " + ex.Message);
                Console.ReadKey();
                UniProx.Main();
            }
        }
    }
}
