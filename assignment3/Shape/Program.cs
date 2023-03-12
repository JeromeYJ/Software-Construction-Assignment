using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Shape
{
    public interface IShape
    {
        double CalArea();
        bool IsValid();
    }
    public class Rectangle:IShape
    {
        protected double width;
        protected double height;

        public Rectangle(double width,double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Width
        {
            get => width;
            set => width = value;
        }
        public double Height
        {
            get => height;
            set => height = value;
        }
        public double CalArea()
        {
            if (!IsValid())
                throw new SystemException("输入的长宽不合法！");
            return width * height;
        }
        public bool IsValid()
        {
            return (width > 0 && height > 0);
        }
    }
    public class Square:Rectangle
    {
        public Square(double side) : base(side, side) {}
    }
    public class Triangle:IShape
    {
        double side1, side2, side3;

        public Triangle(double side1,double side2,double side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public double Side1
        {
            get => side1;
            set => side1 = value;
        }
        public double Side2
        {
            get => side2;
            set => side2 = value;
        }
        public double Side3
        {
            get => side3;
            set => side3 = value;
        }
        public double CalArea()
        {
            if (!IsValid())
                throw new SystemException("输入的边长不合法！");
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        public bool IsValid()
        {
            return (side1>0 &&side2>0 && side3>0 &&
                  side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1);
        }
    }

    internal class Test
    {
        static void Main(string[] args)
        {
            Rectangle r= new Rectangle(1,2);
            r.Width = 3;
            Console.WriteLine(r.CalArea());
            IShape shape = r;
            Console.WriteLine(shape.CalArea());
            shape = new Square(2);
            Console.WriteLine(shape.CalArea());
            shape = new Triangle(1, 2, 3);
            Console.WriteLine(shape.CalArea());
        }
    }
}