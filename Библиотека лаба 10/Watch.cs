using System;
using Библиотека_лаба_10;

namespace Lab10
{
   

    public class Watch : IInit, Библиотека_лаба_10.ICloneable, IComparable<Watch>
    {
        protected string brand;
        protected int year;
        protected IdNumber idNumber; // Добавленное ссылочное поле типа IdNumber
        
        public string Brand
        {
            get => brand;
            set => brand = value;
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 0)
                    year = 0;
                else
                    year = value;
            }
        }

        public IdNumber IdNumber
        {
            get => idNumber;
            set => idNumber = value;
        }

        public Watch()
        {
            Brand = "";
            Year = 0;
            IdNumber = new IdNumber(); // Инициализируем новый экземпляр IdNumber при создании объекта Watch
        }

        public Watch(string brand, int year)
        {
            Brand = brand;
            Year = year;
            IdNumber = new IdNumber(); // Инициализируем новый экземпляр IdNumber при создании объекта Watch
        }

        public void Show()
        {
            Console.WriteLine($"Бренд = {Brand} Год выпуска = {Year}");
        }

        public void Init()
        {
            Console.WriteLine("Введите бренд:");
            Brand = Console.ReadLine();
            Console.WriteLine("Введите год выпуска:");
            Year = int.Parse(Console.ReadLine());
        }

        public void RandomInit()
        {
            Random rnd = new Random();
            string[] brands = { "Xiaomi", "Apple", "GShock" }; // список брендов
            Brand = brands[rnd.Next(brands.Length)]; // случайный бренд
            Year = rnd.Next(1900, DateTime.Now.Year + 1); // случайный год от 1900 до текущего года
        }

        public object Clone()
        {
            Watch clonedWatch = new Watch();
            clonedWatch.Brand = this.Brand;
            clonedWatch.Year = this.Year;
            return clonedWatch;
        }
        public static string NewestBrand(Watch[] watches)
        {
            int newestYear = int.MinValue;
            string newestBrand = "";

            foreach (var watch in watches)
            {
                if (watch.Year > newestYear)
                {
                    newestYear = watch.Year;
                    newestBrand = watch.Brand;
                }
            }

            return newestBrand;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Watch other = (Watch)obj;
            return (Brand == other.Brand && Year == other.Year);
        }
        public Watch ShallowCopy()
        {
            return (Watch)this.MemberwiseClone();
        }
        public int CompareTo(Watch other)
        {
            // Сравниваем по году выпуска
            return this.Year.CompareTo(other.Year);
        }
        public override string ToString()
        {
            return $"Brand: {Brand}, Year: {Year}";
        }
        public virtual void ShowVirtual()
        {
            Console.WriteLine($"Бренд = {Brand} Год выпуска = {Year}");
        }
    }
}
