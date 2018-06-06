using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace loggerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.ILog Logger = log4net.LogManager.GetLogger("AppLogger");

            Parallel.For(0, 10000, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
            {
                
                StringBuilder sb = new StringBuilder();
                CBA cba = new CBA();
                cba.executor(sb);
                Logger.InfoFormat("++Running as {0}", sb.ToString());
            });


            Logger.Error("This will appear in red in the console and still be written to file!");
            Console.ReadLine();
        }


        public class CBA
        {
            public void executor(StringBuilder sb)
            {
                for (int a = 0; a < 30; a++)
                {
                    sb.Append("A");
                }
            }
        }
    }
}
