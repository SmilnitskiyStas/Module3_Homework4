using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndLinQ.Models
{
    internal class Starter
    {
        public delegate int SumHandler(int x, int y);

        public event SumHandler EventForSumMethod;

        public void Run()
        {
            LinQProcessing linQProcessing = new LinQProcessing();

            ProcessingMethod(linQProcessing);
        }

        private int Sum(int x, int y)
        {
            return x + y;
        }

        private void ProcessingMethod(LinQProcessing linQProcessing)
        {
            Random random = new Random();

            try
            {
                EventForSumMethod += Sum;

                int first = EventForSumMethod(random.Next(0, 15), random.Next(15, 25));

                EventForSumMethod += Sum;

                int second = EventForSumMethod(random.Next(25, 35), random.Next(35, 45));

                int sum = Sum(first, second);

                Console.WriteLine(sum);

                linQProcessing.LinqRun();
            }
            catch (Exception)
            {
                Console.WriteLine("Errror");
            }
        }
    }
}
