namespace Eratosthenes
{
    internal class Eratosthenes
    {
        public void ESieve(int[] prime, out int len)
        {
            bool[] notPrime = new bool[101];  //元素默认值均为false
            len = 0;
            for(int i = 2; i <= Math.Sqrt(100); i++)
            {
                if (!notPrime[i])
                {
                    for (int j = 2 * i; j <= 100; j += i)
                        notPrime[j] = true;
                }
            }
            for (int i = 2; i < 101; i++)
                if (!notPrime[i])
                    prime[len++] = i;
        }
        static void Main(string[] args)
        {
            int[] prime = new int[99];     //元素默认值均为0
            int len;
            Console.WriteLine("用埃氏筛法所得的2到100中的素数为：");
            Eratosthenes e = new Eratosthenes();
            e.ESieve(prime, out len);
            for (int i = 0; i < len; i++)
                Console.Write(prime[i]+" ");
        }
    }
}