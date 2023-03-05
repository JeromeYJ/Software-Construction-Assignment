using System.Buffers;

namespace IntArray
{
    internal class IntArray
    {
        public void ArrayData(int[] arr,int len,out int max,out int min,out double avg,out double sum)
        {
            max = arr[0];
            min = arr[0];
            sum = arr[0];
            for(int i = 1; i < len; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
                sum += arr[i];
            }
            avg = sum / len;
        }
        static void Main(string[] args)
        {
            Console.Write("请输入整数数组的长度： ");
            int len = Int32.Parse(Console.ReadLine());
            Console.WriteLine("请输入整数数组的各元素： ");
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
                arr[i] = Int32.Parse(Console.ReadLine());
            int max, min;
            double avg, sum;
            IntArray array = new IntArray();
            array.ArrayData(arr, len, out max, out min, out avg, out sum);
            Console.WriteLine($"整数数组的最大值为：{max}");
            Console.WriteLine($"整数数组的最小值为：{min}");
            Console.WriteLine($"整数数组的平均值为：{avg}");
            Console.WriteLine($"整数数组的所有数组元素的和为：{sum}");
        }
    }
}