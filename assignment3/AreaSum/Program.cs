using Shape;

namespace AreaSum
{
    class ShapeFactory     //工厂类
    {
        public static IShape CreateShape(string type, double side1, double side2, double side3)
        {
            if (type == "Rectangle")
            {
                Console.WriteLine("Create a Rectangle object!");
                return new Rectangle(side1, side2);
            }
            else if (type == "Square")
            {
                Console.WriteLine("Create a Square object!");
                return new Square(side1);
            }
            else if (type == "Triangle")
            {
                Console.WriteLine("Create a Triangle object!");
                return new Triangle(side1, side2, side3);
            }
            else
                throw new SystemException("出错！");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] shapeName = { "Rectangle", "Square", "Triangle" };
            IShape shape;
            int typeIndex;
            double side1, side2, side3;
            double areaSum = 0;
            for(int i = 0; i < 10; i++)
            {
                Random rd = new Random(Guid.NewGuid().GetHashCode());
                typeIndex = rd.Next(0, 3);
                side1 = rd.Next(1, 20);
                side2 = rd.Next(1, 20);
                side3 = side1 + side2 - 1;
                shape = ShapeFactory.CreateShape(shapeName[typeIndex], side1, side2, side3);  //通过工厂类创建各类对象
                areaSum += shape.CalArea();
            }
            Console.WriteLine("随机生成的10个形状对象的面积之和为：{0}", areaSum);
        }
    }
}