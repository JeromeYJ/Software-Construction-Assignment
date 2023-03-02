namespace CalculatorConsole
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            double d1, d2;
            string s;
            Console.WriteLine("Please input two numbers and an operator: ");
            Console.Write("The first number: ");
            s = Console.ReadLine();
            d1 = Double.Parse(s);
            Console.Write("The second number: ");
            s = Console.ReadLine();
            d2 = Double.Parse(s);
            Console.Write("The operator: ");
            char c;
            c = (char)Console.Read();
            double result = 0;
            if (c == '+')
                result = d1 + d2;
            else if (c == '-')
                result = d1 - d2;
            else if (c == '*')
                result = d1 * d2;
            else if (c == '/')
                result = d1 / d2;
            else if (c == '%')
                result = d1 % d2;
            else
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine("The result is: " + result);
        }
    }
}