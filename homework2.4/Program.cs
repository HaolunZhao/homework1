using System;

namespace homework2._4
{
    //形状抽象类（父类）
    abstract class Shape
    {
        //面积
        public abstract double Area();
        //周长
        public abstract double Perimeter();
        //初始化数据

        public abstract bool islegal();
    }
    //圆形
    class Circle : Shape
    {
        double r;
        /* public Circle()
         {
             Initialization();
         }*/
        public Circle(double r)
        {
            this.r = r;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(r, 2);
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * r;
        }
        public override bool islegal()
        {
            return r > 0;
        }
        /* public override void Initialization()
         {
             while (true)
             {
                 Console.WriteLine("请选择输入圆的半径or直径，如下:");
                 Console.WriteLine("1、半径 2、直径");
                 string rStr = Console.ReadLine();
                 string result = "";
                 if (rStr == "1")
                 {
                     Console.WriteLine("请输入圆的半径：");
                     result = Console.ReadLine();
                     if (!double.TryParse(result, out r))
                     {
                         Console.Write("输入数字非法，");
                         continue;
                     }
                     break;
                 }
                 else if (rStr == "2")
                 {
                     Console.WriteLine("请输入圆的直径：");
                     result = Console.ReadLine();
                     if (!double.TryParse(result, out r))
                     {
                         Console.Write("输入数字非法，");
                         continue;
                     }
                     r = r / 2;
                     break;
                 }
                 else
                 {
                     Console.Write("输入数字非法，");
                     continue;
                 }
             }
         }*/
    }
    //正方形
    class Square : Shape
    {
        double x;//正方形的边长
        /*  public Square()
          {
              Initialization();
          }*/
        public Square(double x)
        {
            this.x = x;
        }
        public override double Area()
        {
            return Math.Pow(x, 2);
        }
        public override double Perimeter()
        {
            return 4 * x;
        }
        public override bool islegal()
        {
            return x > 0;
        }
        /*public override void Initialization()
        {
            while (true)
            {
                Console.WriteLine("请输入正方形的边长:");
                string rStr1 = Console.ReadLine();

                if (!double.TryParse(rStr1, out x))
                {
                    Console.Write("输入数字非法，");
                    continue;
                }
                break;
            }

        }*/
    }
    //三角形
    class Triangle : Shape
    {

        double side1;
        double side2;
        double side3;
        /*  public Triangle()
          {
              Initialization();
          }*/
        public Triangle(double a, double b, double c)
        {
            side1 = a;
            side2 = b;
            side3 = c;
        }
        public override double Area()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Pow((p * (p - side1) * (p - side2) * (p - side3)), 0.5);//海伦公式
        }
        public override bool islegal()
        {
            return side1 > 0 && side2 > 0 && side3 > 0 && (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side2);
        }
        public override double Perimeter()
        {
            return side1 + side2 + side3;
        }
        /*  public override void Initialization()
          {
              while (true)
              {
                  Console.Write("请输入三角形第1个边长：");
                  string side1Str = Console.ReadLine();
                  Console.Write("请输入三角形第2个边长：");
                  string side2Str = Console.ReadLine();
                  Console.Write("请输入三角形第3个边长：");
                  string side3Str = Console.ReadLine();
                  if (!double.TryParse(side1Str, out side1) || !double.TryParse(side2Str, out side2)
                       || !double.TryParse(side3Str, out side3))
                  {
                      Console.WriteLine("您输入的数据出现非法字符，请重新输入！");
                      continue;
                  }
                  break;
              }
          }*/
    }
    //长方形
    class Rectangle : Shape
    {
        double x, y;//长方形的长和宽
        /* public Rectangle()
         {
             Initialization();
         }*/
        public Rectangle(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override double Area()
        {
            return x * y;
        }
        public override double Perimeter()
        {
            return 2 * x + 2 * y;
        }
        public override bool islegal()
        {
            return x > 0 && y > 0;
        }
        /* public override void Initialization()
         {
             while (true)
             {
                 Console.WriteLine("请输入长方形的长:");
                 string rStr1 = Console.ReadLine();
                 Console.WriteLine("请输入长方形的宽:");
                 string rStr2 = Console.ReadLine();

                 if (!double.TryParse(rStr1, out x) || !double.TryParse(rStr2, out y))
                 {
                     Console.Write("输入数字非法，");
                     continue;
                 }
                 break;
             }

         }*/
    }
    class Factory
    {

        public static Shape[] CreateShape(string name, int num)
        {
            Shape[] arr = new Shape[num];

            Random rd = new Random();
            switch (name)
            {

                case "1":
                    for (int i = 0; i < num; i++)

                    {
                        arr[i] = new Circle(rd.Next(1, 10));
                    }
                    break;

                case "2":

                    for (int i = 0; i < num; i++)

                    { arr[i] = new Rectangle(rd.Next(1, 10), rd.Next(1, 10)); }
                    break;

                case "3":

                    for (int i = 0; i < num; i++)

                    { arr[i] = new Square(rd.Next(1, 10)); }
                    break;
                case "4":
                    for (int i = 0; i < num; i++)

                    { arr[i] = new Triangle(rd.Next(1, 10), rd.Next(1, 10), rd.Next(1, 10)); }
                    break;
                default:
                    // Console.WriteLine("系统找不到您选择的形状！");
                    //Console.ReadKey();
                    return null;

            }
            return arr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请选择您要计算的形状，如下：");
            Console.WriteLine("1、圆 2、长方形 3、正方形 4、三角形");
            string name = Console.ReadLine();
            Console.WriteLine("输入一个形状数量：");
            int num = int.Parse(Console.ReadLine());

            double areaSum = 0;

            Shape[] shapeArray = Factory.CreateShape(name, num);

            for (int i = 0; i < num; i++)

            {

                areaSum += shapeArray[i].Area();

            }

            Console.WriteLine(areaSum);
        }
    }
}
