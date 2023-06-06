namespace BaiTapHDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lớp trừu tượng Shape
abstract class Shape
        {
            public abstract double CalculateArea();
            public abstract double CalculatePerimeter();
        }

        // Lớp con Square
        class Square : Shape
        {
            private double side;

            public Square(double s)
            {
                side = s;
            }

            public override double CalculateArea()
            {
                return side * side;
            }

            public override double CalculatePerimeter()
            {
                return 4 * side;
            }
        }

        // Lớp con Circle
        class Circle : Shape
        {
            private double radius;

            public Circle(double r)
            {
                radius = r;
            }

            public override double CalculateArea()
            {
                return Math.PI * radius * radius;
            }

            public override double CalculatePerimeter()
            {
                return 2 * Math.PI * radius;
            }
        }

        // Sử dụng
        class Program
        {
            static void Main(string[] args)
            {
                Shape s1 = new Square(5);
                Console.WriteLine("Diện tích hình vuông: " + s1.CalculateArea());
                Console.WriteLine("Chu vi hình vuông: " + s1.CalculatePerimeter());

                Shape s2 = new Circle(3);
                Console.WriteLine("Diện tích hình tròn: " + s2.CalculateArea());
                Console.WriteLine("Chu vi hình tròn: " + s2.CalculatePerimeter());

                Console.ReadKey();
            }
        }

    }
}
}