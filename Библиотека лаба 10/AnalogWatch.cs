using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотека_лаба_10;
using ICloneable = System.ICloneable;

namespace Lab10
{
    public class AnalogWatch : Watch, IInit, ICloneable, IComparable<AnalogWatch>
    {
        protected string watchStyle;

        public string WatchStyle
        {
            get => watchStyle;
            set => watchStyle = value;
        }
        
        public AnalogWatch() : base()
        {
            WatchStyle = "";
        }

        public AnalogWatch(string brand, int year, string watchStyle) : base(brand, year)
        {
            WatchStyle = watchStyle;
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Стиль часов = {WatchStyle}");
        }
        public override void ShowVirtual()
        {
            base.ShowVirtual(); // Вызываем базовый метод
            Console.WriteLine($"Стиль часов = {WatchStyle}");
        }
        public static List<string> UniqueAnalogWatchStyles(Watch[] watches)
{
    List<string> uniqueStyles = new List<string>();

    foreach (var watch in watches)
    {
        if (watch is AnalogWatch analogWatch && !uniqueStyles.Contains(analogWatch.WatchStyle))
        {
            uniqueStyles.Add(analogWatch.WatchStyle);
        }
    }

    return uniqueStyles;
}
        public void Init()
        {
            Console.WriteLine("Введите бренд:");
            Brand = Console.ReadLine();
            Console.WriteLine("Введите год выпуска:");
            Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите стиль часов:");
            WatchStyle = Console.ReadLine();
        }
        public new object Clone()
        {
            AnalogWatch clonedWatch = new AnalogWatch();
            clonedWatch.Brand = this.Brand;
            clonedWatch.Year = this.Year;
            clonedWatch.WatchStyle = this.WatchStyle;
            return clonedWatch;
        }
        public static AnalogWatch RandomInit()
        {
            Random rnd = new Random();
            string[] brands = { "Xiaomi", "Apple", "GShock" }; // список брендов
            string randomBrand = brands[rnd.Next(brands.Length)]; // случайный бренд
            int randomYear = rnd.Next(1900, DateTime.Now.Year + 1); // случайный год от 1900 до текущего года
            string[] styles = { "Style1", "Style2", "Style3" }; // список стилей часов
            string randomStyle = styles[rnd.Next(styles.Length)]; // случайный стиль часов
            return new AnalogWatch(randomBrand, randomYear, randomStyle);
        }
        public int CompareTo(AnalogWatch other)
        {
            // Сначала сравниваем по бренду
            int brandComparison = String.Compare(this.Brand, other.Brand, StringComparison.Ordinal);
            if (brandComparison != 0)
            {
                return brandComparison;
            }

            // Если бренды одинаковые, сравниваем по году выпуска
            int yearComparison = this.Year.CompareTo(other.Year);
            if (yearComparison != 0)
            {
                return yearComparison;
            }

            // Если бренды и годы выпуска одинаковые, сравниваем по стилю часов
            return String.Compare(this.WatchStyle, other.WatchStyle, StringComparison.Ordinal);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            AnalogWatch other = (AnalogWatch)obj;
            return (Brand == other.Brand && Year == other.Year && WatchStyle == other.WatchStyle);
        }
    }
}