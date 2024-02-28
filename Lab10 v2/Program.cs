using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотека лаба 10;

namespace Lab10
{
    public class Program
    {

        static void Main(string[] args)
        {
            Watch w1 = new Watch();
            w1.Show();
            Watch w2 = new Watch("Xiaomi", 2022);
            w2.Show();
            SmartWatch w3 = new SmartWatch("Apple", 2023, "IOS", true);
            w3.Show();
        }
    }
}
