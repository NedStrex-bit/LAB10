using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab10
{
    public class YearComparer : IComparer<Watch>
    {
        public int Compare(Watch x, Watch y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            // Сравниваем объекты по году выпуска
            return x.Year.CompareTo(y.Year);
        }
    }
}