using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using Библиотека_лаба_10;

namespace Lab10
{
    public class ElectroWatch : Watch, IInit, System.ICloneable, IComparable<ElectroWatch>
    {
        protected string opSystem;
        protected bool pulseSensor;
        protected string displayStyle;

        public string OpSystem
        {
            get => opSystem;
            set => opSystem = value;
        }

        public bool PulseSensor
        {
            get => pulseSensor;
            set => pulseSensor = value;
        }

        public string DisplayStyle
        {
            get => displayStyle;
            set => displayStyle = value;
        }

        public ElectroWatch() : base()
        {
            OpSystem = "";
            PulseSensor = false;
            DisplayStyle = "";
        }
        public new object Clone()
        {
            ElectroWatch clonedWatch = new ElectroWatch();
            clonedWatch.Brand = this.Brand;
            clonedWatch.Year = this.Year;
            clonedWatch.OpSystem = this.OpSystem;
            clonedWatch.PulseSensor = this.PulseSensor;
            clonedWatch.DisplayStyle = this.DisplayStyle;
            return clonedWatch;
        }
        public ElectroWatch(string brand, int year, string opSystem, bool pulseSensor, string displayStyle) : base(brand, year)
        {
            OpSystem = opSystem;
            PulseSensor = pulseSensor;
            DisplayStyle = displayStyle;
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Операционная система = {OpSystem}");
            Console.WriteLine($"Датчик пульса = {(PulseSensor ? "Да" : "Нет")}");
            Console.WriteLine($"Стиль дисплея = {DisplayStyle}");
        }

        public void Init()
        {
            Console.WriteLine("Введите бренд:");
            Brand = Console.ReadLine();
            Console.WriteLine("Введите год выпуска:");
            Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите операционную систему:");
            OpSystem = Console.ReadLine();
            Console.WriteLine("Наличие датчика пульса (true/false):");
            PulseSensor = bool.Parse(Console.ReadLine());
            Console.WriteLine("Введите стиль дисплея:");
            DisplayStyle = Console.ReadLine();
        }

        public static ElectroWatch RandomInit()
        {
            Random rnd = new Random();
            string[] brands = { "Xiaomi", "Apple", "GShock" }; // список брендов
            string randomBrand = brands[rnd.Next(brands.Length)]; // случайный бренд
            int randomYear = rnd.Next(1900, DateTime.Now.Year + 1); // случайный год от 1900 до текущего года
            string[] systems = { "System1", "System2", "System3" }; // список операционных систем
            string randomSystem = systems[rnd.Next(systems.Length)]; // случайная операционная система
            bool randomPulseSensor = rnd.Next(2) == 1; // случайное значение датчика пульса
            string[] styles = { "Style1", "Style2", "Style3" }; // список стилей дисплея
            string randomStyle = styles[rnd.Next(styles.Length)]; // случайный стиль дисплея
            return new ElectroWatch(randomBrand, randomYear, randomSystem, randomPulseSensor, randomStyle);
        }
        public int CompareTo(ElectroWatch other)
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

            // Если бренды и годы выпуска одинаковые, сравниваем по операционной системе
            return String.Compare(this.OpSystem, other.OpSystem, StringComparison.Ordinal);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ElectroWatch other = (ElectroWatch)obj;
            return (Brand == other.Brand && Year == other.Year && OpSystem == other.OpSystem && PulseSensor == other.PulseSensor && DisplayStyle == other.DisplayStyle);
        }
    }
}
