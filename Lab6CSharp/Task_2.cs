using System;

namespace Task_2
{
    public class Task_2
    {
        // Інтерфейс Function, який успадковує інтерфейси .NET
        public interface IFunction : ICloneable, IComparable<IFunction>
        {
            double Count(double x); // метод обчислення значення функції
            string Info();          // метод виведення інформації
        }

        public class Line : IFunction
        {
            private float a, b;

            public Line(float a, float b)
            {
                this.a = a;
                this.b = b;
            }

            public double Count(double x)
            {
                return a * x + b;
            }

            public string Info()
            {
                return $"Пряма: y = {a}x + {b}";
            }

            public object Clone()
            {
                return new Line(a, b);
            }

            public int CompareTo(IFunction? other)
            {
                if (other == null) return 1;
                double x = 1;
                return Count(x).CompareTo(other.Count(x));
            }
        }

        public class Quadratic : IFunction
        {
            private float a, b, c;

            public Quadratic(float a, float b, float c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            public double Count(double x)
            {
                return a * x * x + b * x + c;
            }

            public string Info()
            {
                return $"Квадратична: y = {a}x² + {b}x + {c}";
            }

            public object Clone()
            {
                return new Quadratic(a, b, c);
            }

            public int CompareTo(IFunction? other)
            {
                if (other == null) return 1;
                double x = 1;
                return Count(x).CompareTo(other.Count(x));
            }
        }

        public class Hyperbola : IFunction
        {
            private float k;

            public Hyperbola(float k)
            {
                this.k = k;
            }

            public double Count(double x)
            {
                if (x == 0) throw new DivideByZeroException("x не може бути 0 для гіперболи");
                return k / x;
            }

            public string Info()
            {
                return $"Гіпербола: y = {k}/x";
            }

            public object Clone()
            {
                return new Hyperbola(k);
            }

            public int CompareTo(IFunction? other)
            {
                if (other == null) return 1;
                double x = 1;
                return Count(x).CompareTo(other.Count(x));
            }
        }


        public void main2()
        {
            double x = 2.0;
            IFunction[] functions = new IFunction[]
            {
                new Line(2, 3),
                new Quadratic(1, -2, 1),
                new Hyperbola(5)
            };

            foreach (var func in functions)
            {
                Console.WriteLine(func.Info());
                Console.WriteLine($"f({x}) = {func.Count(x)}\n");
            }
        }

    }
}
