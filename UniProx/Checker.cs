using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniProx
{
    public class Checker
    {
        public static void check()
        {
            OpenFileDialog o = new OpenFileDialog{
                Multiselect = false,
                Title = "Select Proxy List!",
                Filter = "txt files (*.txt)|*.txt"
            };
            o.ShowDialog();

            string[] proxies = File.ReadAllLines(o.FileName);

            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

            foreach (string prox in proxies)
            {
                if(testProxy(prox) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[+] Good - " + prox);
                    string append = File.ReadAllText("good-" + date + ".txt");
                    using (StreamWriter writer = new StreamWriter("good-" + date + ".txt"))
                    {
                        writer.WriteLine(append + prox);
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[-] Bad - " + prox);
                    string append = File.ReadAllText("bad-" + date + ".txt");
                    using (StreamWriter writer = new StreamWriter("bad-" + date + ".txt"))
                    {
                        writer.WriteLine(append + prox);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All good proxies were saved to: " + AppDomain.CurrentDomain.BaseDirectory + "good-" + date + ".txt");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All bad proxies were saved to: " + AppDomain.CurrentDomain.BaseDirectory + "bad-" + date + ".txt");
            Console.ReadKey();
            UniProx.Main();
        }

		static bool testProxy(string proxy)
        {
            string[] a = proxy.Split(':');
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.com");
            request.Proxy = new WebProxy(a[0], Convert.ToInt32(a[1]));
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36";
            request.Timeout = 1000;
            try
            {
                WebResponse rp = request.GetResponse();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
