using System;

namespace homework4
{
    class Program
    {
        public static void Eratosthenes(int high,int low)
        {
            int length = high - low;
            int[] array = new int[length + 1];
            for (int i = 0; i < length + 1; i++)
            {
                array[i] = i + 2;
            }
            for (int n = 2; n < high / 2; n++)
            {
                for (int i = 0; i < length + 1; i++)
                {
                    if (array[i] % n == 0 && array[i] != 2 && array[i] / n != 1)
                    {
                        array[i] = 0;
                    }
                }
            }
            for (int i = 0; i < length + 1; i++)
            {
                if (array[i] != 0)
                    Console.WriteLine(array[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入上界：");
            int high = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入下界：");
            int low = Convert.ToInt32(Console.ReadLine());
            Eratosthenes(high, low);
        }
    }
}
