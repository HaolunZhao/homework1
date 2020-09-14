using System;

namespace homework1
{
    class Program
    {
        public static void getarray(int length)
        {
         
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("value{0}:", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(array);//排序
            double sum = 0, average;
            for (int i = 0; i < length; i++)
            {
                sum += array[i];
            }
            average = sum / length;//平均值
            Console.WriteLine("最大值" + array[length - 1]);
            Console.WriteLine("最小值" + array[0]);
            Console.WriteLine("平均值" + average);
            Console.WriteLine("和" + sum);
            Console.WriteLine("");


        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度：");
            int length = Convert.ToInt32(Console.ReadLine());//数组长度
            getarray(length);
        }
    }
}
