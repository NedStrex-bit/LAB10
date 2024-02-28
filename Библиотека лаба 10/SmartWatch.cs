using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотека_лаба_10;

namespace Lab10
{
    public class SmartWatch : Watch, IInit, IComparable<SmartWatch>
    {
        protected string opSystem;
        protected bool pulseSensor;

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

        public SmartWatch() : base()
        {
            OpSystem = "";
            PulseSensor = false;
        }

        public SmartWatch(string brand, int year, string opSystem, bool pulseSensor) : base(brand, year)
        {
            OpSystem = opSystem;
            PulseSensor = pulseSensor;
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Операционная система = {OpSystem}");
            Console.WriteLine($"Датчик пульса = {(PulseSensor ? "Да" : "Нет")}");
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
        }

        public static SmartWatch RandomInit()
        {
            Random rnd = new Random();
            string[] brands = { "Brand1", "Brand2", "Brand3" }; // список брендов
            string randomBrand = brands[rnd.Next(brands.Length)]; // случайный бренд
            int randomYear = rnd.Next(1900, DateTime.Now.Year + 1); // случайный год от 1900 до текущего года
            string[] systems = { "System1", "System2", "System3" }; // список операционных систем
            string randomSystem = systems[rnd.Next(systems.Length)]; // случайная операционная система
            bool randomPulseSensor = rnd.Next(2) == 1; // случайное значение датчика пульса
            return new SmartWatch(randomBrand, randomYear, randomSystem, randomPulseSensor);
        }
        public static int SmartWatchesWithPulseSensorCount(Watch[] watches)
        {
            int count = 0;

            foreach (var watch in watches)
            {
                if (watch is SmartWatch smartWatch && smartWatch.PulseSensor)
                {
                    count++;
                }
            }

            return count;
        }
        public int CompareTo(SmartWatch other)
        {
            // Сначала сравниваем по бренду
            int brandComparison = String.Compare(this.Brand, other.Brand, StringComparison.Ordinal);
            if (brandComparison != 0)
            {
                return brandComparison;
            }

            // Если бренды одинаковые, сравниваем по году выпуска
            return this.Year.CompareTo(other.Year);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            SmartWatch other = (SmartWatch)obj;
            return (Brand == other.Brand && Year == other.Year && OpSystem == other.OpSystem && PulseSensor == other.PulseSensor);
        }
    }
}

