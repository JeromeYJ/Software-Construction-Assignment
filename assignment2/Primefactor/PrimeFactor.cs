using System.Xml.Linq;

namespace PrimeFactor
{
    internal class PrimeFactor
    {
        public bool IsPrime(int n)      //判断是否为素数的方法
        {
            bool isPrime = true;
            for(int i=2;i<=Math.Sqrt(n);i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        public void PrimeFactors(int n, int[] prime, out int len)     //输出已知合数所有素数因子的方法
        {
            int i = 2;
            len = 0;
            while (n != 1)
            {
                if (n % i == 0)
                {
                    prime[len++] = i;
                    n /= i;
                }
                else i++;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Please input a positive integer:  ");
            int input;
            string s;
            s = Console.ReadLine();
            if (s == null)
            {
                Console.WriteLine("Error!");
                return;
            }
            input = Int32.Parse(s);

            int[] prime = new int[input];
            int len;

            PrimeFactor p = new PrimeFactor();
            if (input == 1)
            {
                Console.WriteLine("Error!");
                return;
            }
            if (p.IsPrime(input))
            {
                Console.WriteLine("Prime factor(s): ");
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Prime factor(s): ");
                p.PrimeFactors(input, prime, out len);
                for (int i = 0; i < len; i++)
                    Console.Write(prime[i] + " ");
                Console.WriteLine();
            }
        }
    }
}