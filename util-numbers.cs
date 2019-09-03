using System;

namespace util_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IntegerMath(args);
        }

        private static void IntegerMath(string[] args)
        {
            int a = 18;
            int b = 6;
            int c = a + b;
            int e = a - b;
            int i = a * b;
            int f = a / b;
            Console.WriteLine("Integer Math #1: " + c);
            Console.WriteLine("Integer Math #2: " + e);
            Console.WriteLine("Integer Math #3: " + i);
            Console.WriteLine("Integer Math #4: " + f);

            OrderOperations(args);
        }

        private static void OrderOperations(string[] args)
        {
            //You can change the order of operations beyond what is automatic by adding parentheses
            //You can also include actual numbers with variables
            int a = 5;
            int b = 4;
            int c = 2;
            int d = a + b * c;
            int e = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            Console.WriteLine("Order of Operations #1: " + d);
            Console.WriteLine("Order of Operations #2: " + e);

            IntegerPrecision(args);
        }

        private static void IntegerPrecision(string[] args)
        {
            //You can get the remainder of a division problem by using the modulo (%) character
            int a = 7;
            int b = 4;
            int c = 3;
            int d = (a + b) / c;
            int e = (a + b) % c;
            Console.WriteLine($"Integer Precision #1: quotient: {d}, remainder {e}");
            //Also notice how I added variables to strings in the console here vs using the + sign as I did above

            IntegerFlow(args);
        }

        private static void IntegerFlow(string[] args)
        {
            //C# integers (int) have min and max limits as seen here
            int max = int.MaxValue;
            int min = int.MinValue;
            Console.WriteLine($"The range of integers is {min} to {max}");

            OverflowExample(args);
        }

        private static void OverflowExample(string[] args)
        {
            //If a calculation produces a value that exceeds those limits, you have an underflow or overflow condition. The answer appears to wrap from one limit to the other. 
            //Notice that the answer is very close to the minimum (negative) integer. It's the same as min + 2. 
            //The addition operation overflowed the allowed values for integers. 
            //The answer is a very large negative number because an overflow "wraps around" from the largest possible integer value to the smallest.

            //Supposedly that is what happens; however, in the latest version of Visual Studio, it simply creates a compiling error, preventing the program from running

            //   int what = int.MaxValue + 3;
            // Console.WriteLine($"An example of overflow: {what}");

            DoubleType(args);
        }

        private static void DoubleType(string[] args)
        {
            //The double numeric type represents a double-precision floating point number. 
            //A floating point number is useful to represent non-integral numbers that may be very large or small in magnitude. 
            //Double -precision means that these numbers are stored using greater precision than single-precision. 

            double a = 5;
            double b = 4;
            double c = 2;
            double d = (a + b) / c;
            Console.WriteLine($"Double-precision type #1: {d}");

            double e = 19;
            double f = 23;
            double g = 8;
            double h = (e + f) / g;
            Console.WriteLine($"Double-precision type #2: {h}");

            double max = double.MaxValue;
            double min = double.MinValue;
            Console.WriteLine($"The range of double is {min} to {max}");

            //There can still be errors with rounding, like with repeating decimals
            double third = 1.0 / 3.0;
            Console.WriteLine($"Example of rounding errors in repeating decimals: 1/3 = {third}");

            FixedPoint(args);
        }

        private static void FixedPoint(string[] args)
        {
            //The decimal type has a smaller range but greater precision than double. The term FIXED POINT means that the decimal point (or binary point) doesn't move. 

            decimal min = decimal.MinValue;
            decimal max = decimal.MaxValue;
            Console.WriteLine($"The range of the decimal type is {min} to {max}");

            double a = 1.0;
            double b = 3.0;
            Console.WriteLine($"Double example: { a / b}");

            decimal c = 1.0M;
            decimal d = 3.0M;
            Console.WriteLine($"Decimal example: {c / d}");
            //M is how you indicate that a constant should use the decimal type.  Notice that it contains more digits to the right of the decimal point than the doubles.

            double radius = 2.50;
            double area = Math.PI * radius * radius;
            Console.WriteLine($"The area of the circle is {area} cm2");
            //You get an error saying that doubles and decimals cannot be used in multiplication for some reason, you can ignore it as the program runs fine anyways
        }
    }
}
