using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string ans;
            string path = @"C:\Users\Lilit\Desktop\project.txt";
            Console.WriteLine("\tCalculator");
            while (true)
            {
                ans = Console.ReadLine();

                if (ans.Contains('#'))
                {
                    break;
                }

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(ans);
                }

                EventWaitHandle wh = EventWaitHandle.OpenExisting("ProblemIsReady");
                wh.Set();

                EventWaitHandle here = new EventWaitHandle(false, EventResetMode.AutoReset, "Solution Is Ready");
                here.WaitOne();

                Console.WriteLine(File.ReadLines(path).Last());
            }
        }
    }
}
