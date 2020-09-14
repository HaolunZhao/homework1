using System;

namespace homework3
{
    class Program
    {
        public static void getprimenumber(int num1)
        {
            int i;
            while (num1 > 1)
            {
                ;
                for (i = 2; i <= num1;)
                {
                    if (num1 % i == 0)
                    {
                        Console.WriteLine(i);
                        num1 = num1 / i;
                    }
                    else i++;

                }

            }
        }
            static void Main(string[] args)
            {
                Console.WriteLine("输入一个数字");
                int num1 = Convert.ToInt32(Console.ReadLine());
                getprimenumber(num1);

            }
        
    }
}

