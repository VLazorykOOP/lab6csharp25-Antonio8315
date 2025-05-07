using System;

namespace Task_3
{
    public class Task_3
    {
        abstract class Function
        {
            public abstract double Count(double x);
        }

        class Line : Function
        {
            protected float a;
            protected float b;

            public Line(float a, float b)
            {
                this.a = a; this.b = b;
            }

            public override double Count(double x)
            {
                return a * x + b;
            }
        }

        class Quadratic : Function
        {
            protected float a, b, c;

            public Quadratic(float a, float b, float c)
            {
                this.a = a; this.b = b; this.c = c;
            }

            public override double Count(double x)
            {
                return a * Math.Pow(x, 2) + b * x + c;
            }
        }

        // Тут спрацює виняток з / на 0
        class HyperbolaCalculationException : Exception
        {
            public HyperbolaCalculationException(string message) : base(message) { }
        }

        class Hyperbola : Function
        {
            protected float k;

            public Hyperbola(float k)
            {
                this.k = k;
            }

            public override double Count(double x)
            {
                try
                {
                    if (x == 0)
                        throw new DivideByZeroException("Ділення на нуль!");
                    
                    return k / x;
                }
                catch (DivideByZeroException ex)
                {
                    throw new HyperbolaCalculationException("Помилка при обчисленні гіперболи: " + ex.Message);
                }
            }
        }

        public void main3()
        {
            try
            {
                Line line1 = new Line(3, 4);
                Console.WriteLine("Line: " + line1.Count(8));

                Quadratic quadratic1 = new Quadratic(2, 3, 4);
                Console.WriteLine("Quadratic: " + quadratic1.Count(4.2));

                Hyperbola hyperbola1 = new Hyperbola(16);
                Console.WriteLine("Hyperbola: " + hyperbola1.Count(0)); 
            }
            catch (HyperbolaCalculationException ex)
            {
                Console.WriteLine("Власний виняток: " + ex.Message);
            }
        }
    }
}
