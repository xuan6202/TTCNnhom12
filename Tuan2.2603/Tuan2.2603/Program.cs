using System;

namespace Tuan2
{
    class Program
    {
        static void Main(string[] args)
        {
            double width, height, woodLength, glassArea;
            const double max_width = 5;
            const double min_width = 0.5;
            const double max_height = 3;
            const double min_height = 0.75;

            string widthString, heightString;
            Console.Write("Give the width of the window: ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            if (width < min_width)
            {
                Console.WriteLine("width is too small \n");
                Console.WriteLine("using mininum");
                width = min_width;
            }
            if (width > max_width)
            {
                Console.WriteLine("width is too large \n");
                Console.WriteLine("using maxinum");
                width = max_width;
            }
            Console.Write("Give the height of the window: ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            if (height < min_height)
            {
                Console.WriteLine("Height is too small \n");
                Console.WriteLine("using mininum");
                height = min_height;
            }
            if (height > max_height)
            {
                Console.WriteLine("height is too large \n");
                Console.WriteLine("using maxinum");
                height = max_height;
            }

            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);
            Console.WriteLine("The length of the wood is " + woodLength + " feet");
            Console.WriteLine("The area of the glass is " + glassArea + " square metres");

        }
    }
}
