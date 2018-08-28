using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Lilit\Desktop\project.txt";

            while (true)
            {
                EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset, "ProblemIsReady");
                wh.WaitOne();

                string ans = File.ReadLines(path).Last();

                using (StreamWriter sw=File.AppendText(path))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(Calculating(ans));
                }

                EventWaitHandle here = EventWaitHandle.OpenExisting("Solution Is Ready");
                here.Set();
            }
        }

        static string Calculating(string a)
        {
            char[] operators = new char[] { '+', '-', '*', '/' };

            foreach (char item in operators)
            {
                if (a.Contains(item))
                {
                    string[] arr = a.Split(item);
                    int x = int.Parse(arr[0]);
                    int y = int.Parse(arr[1]);

                    switch (item)
                    {
                        case '+':
                            return (x + y).ToString();
                        case '-':
                            return (x - y).ToString();
                        case '*':
                            return (x * y).ToString();
                        case '/':
                            return (x / y).ToString();                       
                    }
                }
            }
            return "Wrong Operator";
        }
    }
}
