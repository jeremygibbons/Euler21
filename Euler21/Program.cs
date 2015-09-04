using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler21
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> sums = new Dictionary<int, int>();

            sums.Add(0, 0);

            foreach (int n in Enumerable.Range(1, 10000))
            {
                if(sums.ContainsKey(n)== false)
                {
                    sums.Add(n, GetSumOfDivisors(n));
                }
                
                if(sums.ContainsKey(sums[n]) == false)
                {
                    sums.Add(sums[n], GetSumOfDivisors(sums[n]));
                }
            }

            HashSet<int> amicables = new HashSet<int>();
            foreach (var item in sums)
            {
                if (item.Key > 10000)
                    continue;

                if(item.Key == sums[item.Value] && item.Key != item.Value)
                {
                    amicables.Add(item.Key);
                    amicables.Add(item.Value);
                }
            }
            Console.WriteLine(amicables.Sum());
            Console.ReadLine();
        }

        private static int GetSumOfDivisors(int n)
        {
            int sq = (int) Math.Sqrt(n);
            HashSet<int> divisors = new HashSet<int>();
            for(int i = 1; i <= sq; i++)
            {
                if(n % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }
            divisors.Remove(n);
            return divisors.Sum();
        }
    }
}
