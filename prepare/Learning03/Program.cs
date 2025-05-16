using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction_1 = new Fraction();
        Console.WriteLine(fraction_1.GetFractionString());
        Console.WriteLine(fraction_1.GetDecimalValue());

        Fraction fraction_2 = new Fraction(5);
        Console.WriteLine(fraction_2.GetFractionString());
        Console.WriteLine(fraction_2.GetDecimalValue());

        Fraction fraction_3 = new Fraction(3, 4);
        Console.WriteLine(fraction_3.GetFractionString());
        Console.WriteLine(fraction_3.GetDecimalValue());

        Fraction fraction_4 = new Fraction(1,3);
        Console.WriteLine(fraction_4.GetFractionString());
        Console.WriteLine(fraction_4.GetDecimalValue());
    }
}