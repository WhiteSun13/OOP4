using System;

namespace OOP4_Task1
{
    struct ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real * b.Real - a.Imaginary * b.Imaginary,
                                     a.Real * b.Imaginary + a.Imaginary * b.Real);
        }

        public static bool operator ==(ComplexNumber a, ComplexNumber b)
        {
            return a.Real.Equals(b.Real) && a.Imaginary.Equals(b.Imaginary);
        }

        public static bool operator !=(ComplexNumber a, ComplexNumber b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                return this == (ComplexNumber)obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() ^ Imaginary.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Real} {(Imaginary < 0 ? "-" : "+")} {Math.Abs(Imaginary)}i";
        }
    }

    class Program
    {
        static void Main()
        {
            ComplexNumber a = new ComplexNumber(3, 2);
            ComplexNumber b = new ComplexNumber(1, -4);

            ComplexNumber sum = a + b;
            ComplexNumber diff = a - b;
            ComplexNumber prod = a * b;

            Console.WriteLine($"Число a: {a}");
            Console.WriteLine($"Число b: {b}");

            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Разность: {diff}");
            Console.WriteLine($"Произведение: {prod}");

            Console.WriteLine($"Модуль числа a: {a.Modulus}");
            Console.WriteLine($"Модуль числа b: {b.Modulus}");

            Console.WriteLine($"a == b: {a == b}");
        }
    }
}
