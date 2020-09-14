using System;

namespace homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入矩阵行数：");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("输入矩阵列数：");
            int n = int.Parse(Console.ReadLine());
            Matrix x1 = new Matrix();
            x1.x = CreatMatrix.creaM(m, n);
            ShowMatrix.showM(x1.x);
            var res = judgeToeplitzMatrix(x1.x);
            Console.WriteLine(res);

            Console.ReadKey();

        }


        public static bool judgeToeplitzMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i + 1, j + 1] != matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    public class Matrix//矩阵类
    {
        public int[,] x;//定义一个矩阵字段
    }
    public class CreatMatrix//为矩阵随机赋值
    {
        public static int[,] creaM(int m, int n)
        {
            int[,] x = new int[m, n];//初始化矩阵
           
            for (int i = 0; i < m; i++)//对二维矩阵所有点遍历
            {
                for (int j = 0; j < n; j++)
                {
                    //x[i, j] = r.Next(0, 10);//对二维矩阵每个点赋值
                    x[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return x;
        }
    }
    public class ShowMatrix//展示二维数组
    {
        public static void showM(int[,] x)//传入数组
        {
            //int k = x.Rank;//获取数组维度
            int m = x.GetLength(0);//获取行数
            int n = x.GetLength(1);//获取行列
            //GetLength() 获取指定维度长度,而对于多维数组的维度如[5,7,9]
            //5是一维的长度，7是二维的长度，9是三维的长度
            for (int i = 0; i < m; i++)//每一行
            {
                for (int j = 0; j < n; j++)//每一列
                {
                   Console. Write("{0} ", x[i, j]);                   // 输出数组中的元素
                }
               Console. WriteLine();                                //换行
            }
        }
    }
}
    //矩阵打包成类，矩阵为m * n,直接调用
   