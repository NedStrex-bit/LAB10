using Laba10;
using System;

namespace Библиотека_лаба_10
{
    public class RectangleArray : IInit
    {
        int count = 0; // Изменение статического поля на экземплярное

        Rectangle[] array;

        public int Length
        {
            get => array.Length;
        }

        public RectangleArray(int length)
        {
            array = new Rectangle[length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = new Rectangle(rnd.Next(10000), rnd.Next(10000));
                count++;
            }
        }

        public RectangleArray(RectangleArray other)
        {
            array = new Rectangle[other.Length];
            for (int i = 0; i < other.Length; i++)
                array[i] = new Rectangle(other.array[i]);
            count += other.Length;
        }

        public RectangleArray(Rectangle[] rectangles)
        {
            array = rectangles;
            count += rectangles.Length;
        }

        public RectangleArray()
        {
            array = new Rectangle[0];
            count++;
        }
        
        public Rectangle this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                else
                    throw new IndexOutOfRangeException("Индекс выходит за пределы коллекции ");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    throw new IndexOutOfRangeException("Индекс выходит за пределы коллекции ");
            }
        }

        // Реализация метода Init из интерфейса IInit
        public void Init()
        {
            Console.Write("Введите количество прямоугольников: ");
            int length = Convert.ToInt32(Console.ReadLine());
            array = new Rectangle[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Прямоугольник {i + 1}:");
                Console.Write("Ширина: ");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.Write("Высота: ");
                double height = Convert.ToDouble(Console.ReadLine());
                array[i] = new Rectangle(width, height);
                count++;
            }
        }



        public void RandomInit(int length)
        {
            Random rnd = new Random();
            array = new Rectangle[length];
            for (int i = 0; i < length; i++)
            {
                double width = rnd.NextDouble() * (46340.9499 - 0.0001) + 0.0001; // случайная ширина от 0.0001 до 46340.9499
                double height = rnd.NextDouble() * (46340.9499 - 0.0001) + 0.0001; // случайная высота от 0.0001 до 46340.9499
                array[i] = new Rectangle(width, height);
                count++;
            }
        }
        public int GetCount() { return count; } // Изменение метода GetCount() на экземплярный

        public void Show()
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив прямоугольников пуст.");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i].Show();
            }
        }
    }
}
