using Laba10;
using System;
using System.Collections.Generic;
using Библиотека_лаба_10;

namespace Laba10
{
    public class Rectangle : IInit, IComparable<Rectangle>
    {
        static int count = 0;
        private double width;
        private double length;

        public double Length
        {
            get => length;
            set
            {
                if (value < 0.0001)
                {
                    throw new ArgumentException("Длина не может быть меньше чем 0.0001");
                }
                else if (value > 46340.9499)
                {
                    throw new ArgumentException("Длина не может быть больше чем 46340.9499");
                }
                else
                {
                    length = value;
                }
            }
        }

        public double Width
        {
            get => width;
            set
            {
                if (value < 0.0001)
                {
                    throw new ArgumentException("Ширина не может быть меньше чем 0.0001");
                }
                else if (value > 46340.9499)
                {
                    throw new ArgumentException("Ширина не может быть больше чем 46340.9499");
                }
                else
                {
                    width = value;
                }
            }
        }

        public Rectangle(double w, double l)
        {
            Width = w;
            Length = l;
            count++;
        }

        public Rectangle()
        {
            Width = 1;
            Length = 1;
            count++;
        }

        public Rectangle(Rectangle previousRectangle)
        {
            Width = previousRectangle.Width;
            Length = previousRectangle.Length;
            count++;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Ширина {Width}, Высота {Length}.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            return $"Ширина {Width}, Высота {Length}.";
        }

        public static Rectangle IncreaseRectangle(int N, Rectangle r)
        {
            // Увеличиваем размеры прямоугольника
            r.Width *= N;
            r.Length *= N;

            return r;
        }

        public Rectangle Increase(int N)
        {
            Width *= N;
            Length *= N;

            return this;
        }

        public static int GetCount() { return count; }

        public static Rectangle operator ++(Rectangle r)
        {
            Rectangle result = new Rectangle(r);
            result.Width = result.Width + 1;
            result.Length = result.Length + 1;

            return result;
        }

        public static Rectangle operator --(Rectangle r)
        {
            Rectangle result = new Rectangle(r);
            result.Width = result.Width - 1;
            result.Length = result.Length - 1;

            return result;
        }

        public static explicit operator double(Rectangle r)
        {
            double result;
            result = Math.Pow(r.Width, 2) + Math.Pow(r.Length, 2);
            result = Math.Sqrt(result);
            result = result / 2;
            result = Math.PI * Math.Pow(result, 2);

            return result;
        }

        public static implicit operator bool(Rectangle r)
        {
            return r.Width == r.Length;
        }

        public static Rectangle operator +(Rectangle r, double d)
        {
            Rectangle sum = new Rectangle();
            sum.Width = r.Width + d;
            sum.Length = r.Length + d;

            return sum;
        }

        public static Rectangle operator +(double d, Rectangle r)
        {
            Rectangle sum = new Rectangle();
            sum.Width = r.Width + d;
            sum.Length = r.Length + d;

            return sum;
        }
        public void Init()
        {
            Random rnd = new Random();
            Width = rnd.NextDouble() * (46340.9499 - 0.0001) + 0.0001; // случайная ширина от 0.0001 до 46340.9499
            Length = rnd.NextDouble() * (46340.9499 - 0.0001) + 0.0001; // случайная длина от 0.0001 до 46340.9499
        }
        public void RandomInit()
        {
            Random rnd = new Random();
            Width = rnd.NextDouble() * (46340.9499 - 0.0001) + 0.0001; // случайная ширина от 0.0001 до 46340.9499
            Length = rnd.NextDouble() * (46340.9499 - 0.0001) + 0.0001; // случайная длина от 0.0001 до 46340.9499
        }
        public static Rectangle operator -(Rectangle r, double d)
        {
            Rectangle razn = new Rectangle();
            razn.Width = r.Width - d;
            razn.Length = r.Length - d;

            return razn;
        }

        public static Rectangle operator -(double d, Rectangle r)
        {
            Rectangle razn = new Rectangle();
            razn.Width = r.Width - d;
            razn.Length = r.Length - d;

            return razn;
        }

        public int CompareTo(Rectangle other)
        {
            // Сравниваем прямоугольники по их площади
            double thisArea = Width * Length;
            double otherArea = other.Width * other.Length;

            return thisArea.CompareTo(otherArea);
        }

        public override bool Equals(object obj)
        {
            bool equals = true;
            if (obj is Rectangle)
            {
                Rectangle r = (Rectangle)obj;
                equals &= (this.Width == r.Width) && (this.Length == r.Length);
            }
            return equals;
        }

        // Реализация метода RandomInit() из интерфейса IInit
        
    }
}
