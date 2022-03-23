using System;

namespace XOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Take Two Number:: ");
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            Console.Write("\nBefore XOR a: " + first + " b: " + second);

            first = first ^ second;
            second = first ^ second;
            first = first ^ second;

            Console.Write("\nAfter XOR a: " + first + " b: " + second);

            Console.Read();
        }
    }
}
