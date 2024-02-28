using Lab10;
using Laba10;
using System;
using System.Collections.Generic;
using Библиотека_лаба_10;

namespace Лаба_10_в3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arraySize = 20; // Размер массива объектов

            // Создание массива объектов
            Watch[] objectsArray = new Watch[arraySize];

            // Количество сгенерированных объектов
            int generatedObjectsCount = 0;

            // Заполнение массива случайно сгенерированными объектами
            Random rnd = new Random();
            while (generatedObjectsCount < arraySize)
            {
                int objectType = rnd.Next(4); // Генерация случайного типа объекта

                switch (objectType)
                {
                    case 0:
                        objectsArray[generatedObjectsCount] = new Watch();
                        objectsArray[generatedObjectsCount].RandomInit(); // Вызов метода RandomInit() через интерфейс IInit
                        break;
                    case 1:
                        objectsArray[generatedObjectsCount] = AnalogWatch.RandomInit();
                        break;
                    case 2:
                        objectsArray[generatedObjectsCount] = SmartWatch.RandomInit();
                        break;
                    case 3:
                        objectsArray[generatedObjectsCount] = ElectroWatch.RandomInit();
                        break;
                }

                generatedObjectsCount++;
            }

            // Вывод результатов запросов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЧАСТЬ 1: ОБЫЧНАЯ ФУНКЦИЯ ПРОСМОТРА");
            Console.ResetColor();

            // Вывод информации о каждом объекте в массиве
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Объект {i + 1}:");
                objectsArray[i].Show();

                // Проверка типа объекта и вывод атрибутов
                if (objectsArray[i] is AnalogWatch analogWatch)
                {
                    Console.WriteLine($"Стиль часов: {analogWatch.WatchStyle}");
                }
                else if (objectsArray[i] is SmartWatch smartWatch)
                {
                    Console.WriteLine($"Операционная система: {smartWatch.OpSystem}");
                    Console.WriteLine($"Датчик пульса: {(smartWatch.PulseSensor ? "Да" : "Нет")}");
                }
                else if (objectsArray[i] is ElectroWatch electroWatch)
                {
                    Console.WriteLine($"Стиль дисплея: {electroWatch.DisplayStyle}");
                    Console.WriteLine();
                }
            }

            // Вывод результатов запросов
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЧАСТЬ 1: ВИРТУАЛЬНАЯ ФУНКЦИЯ ПРОСМОТРА");
            Console.ResetColor();
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Объект {i + 1}:");
                objectsArray[i].ShowVirtual(); // Используем виртуальную функцию
                Console.WriteLine();
            }

            // Выполнение запросов и вывод результатов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЧАСТЬ 2: ЗАПРОСЫ");
            Console.ResetColor();
            string newestBrand = Watch.NewestBrand(objectsArray);
            int smartWatchesCount = SmartWatch.SmartWatchesWithPulseSensorCount(objectsArray);
            List<string> uniqueStyles = AnalogWatch.UniqueAnalogWatchStyles(objectsArray);

            Console.WriteLine($"Самый новый бренд часов: {newestBrand}");
            Console.WriteLine($"Количество умных часов с датчиком пульса: {smartWatchesCount}");
            Console.WriteLine("Уникальные стили аналоговых часов:");
            foreach (var style in uniqueStyles)
            {
                Console.WriteLine(style);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ЧАСТЬ 3");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("НОМЕР 4-5");
            Console.ResetColor();
            //
            RectangleArray[] rectangles = new RectangleArray[3];

            // Заполняем массив объектами
            rectangles[0] = new RectangleArray(3); // Создаем RectangleArray с использованием конструктора с параметром
            rectangles[1] = new RectangleArray();  // Создаем RectangleArray с использованием конструктора по умолчанию
            rectangles[2] = new RectangleArray(new Rectangle[] { new Rectangle(5, 10) });            // Создаем RectangleArray с использованием конструктора с объектом Rectangle

            // Выводим информацию о каждом элементе массива
            for (int i = 0; i < rectangles.Length; i++)
            {
                Console.WriteLine($"RectangleArray {i + 1}:");
                rectangles[i].Show();
                Console.WriteLine();
            }

            // Проверяем количество созданных объектов
            Console.WriteLine($"Количество созданных прямоугольников: {Rectangle.GetCount()}");

            IComparable[] objects = new IComparable[9]; // Создаем массив IComparable для объектов Watch
            Watch[] watches = new Watch[9];
            watches[0] = new AnalogWatch("Xiaomi", 2020, "Style1");
            watches[1] = new ElectroWatch("Apple", 2019, "System1", true, "Style2");
            watches[2] = new SmartWatch("Samsung", 2021, "System2", false);
            watches[3] = new AnalogWatch("Casio", 2018, "Style3");
            watches[4] = new ElectroWatch("Huawei", 2022, "System3", true, "Style4");
            watches[5] = new SmartWatch("Fitbit", 2017, "System4", false);
            watches[6] = new AnalogWatch("Seiko", 2023, "Style5");
            watches[7] = new ElectroWatch("Garmin", 2016, "System5", true, "Style6");
            watches[8] = new SmartWatch("Amazfit", 2024, "System6", false);

            Array.Sort(watches);

            Console.WriteLine("Отсортированный массив:");
            foreach (var watch in watches)
            {
                Console.WriteLine(watch.ToString());
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("НОМЕР 7");
            Console.ResetColor();
            Console.WriteLine("Введите значение для поиска (например, 2020):");
            int searchValue = int.Parse(Console.ReadLine());

            int index = Array.BinarySearch(watches, new AnalogWatch("", searchValue, ""));

            if (index >= 0)
            {
                Console.WriteLine($"Найдено значение по индексу: {index}");
            }
            else
            {
                Console.WriteLine("Значение не найдено в массиве.");
            }

            Array.Sort(watches, new YearComparer());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("НОМЕР 8");
            Console.ResetColor();
            // Выводим отсортированный массив
            Console.WriteLine("Отсортированный массив по году выпуска:");
            foreach (var watch in watches)
            {
                Console.WriteLine(watch);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("НОМЕР 12");
            Console.ResetColor();
            // Создаем экземпляр часов
            Watch originalWatch = new Watch("Rolex", 2020);

            // Клонируем часы
            Watch clonedWatch = (Watch)originalWatch.Clone();

            // Делаем поверхностную копию часов
            Watch shallowCopiedWatch = originalWatch.ShallowCopy();

            // Модифицируем исходные часы
            originalWatch.Brand = "Omega";

            // Выводим информацию об исходных часах
            Console.WriteLine("Исходные часы:");
            Console.WriteLine(originalWatch);

            // Выводим информацию о клонированных часах
            Console.WriteLine("\nКлонированные часы:");
            Console.WriteLine(clonedWatch);

            // Выводим информацию о поверхностно скопированных часах
            Console.WriteLine("\nПоверхностно скопированные часы:");
            Console.WriteLine(shallowCopiedWatch);
            //В этом коде после модификации исходных часов, мы видим, что значение марки в клонированных часах осталось прежним (Rolex), 
            //в то время как значение марки в поверхностно скопированных часах также изменится на "Omega", так как они ссылаются на один и тот же объект.
            Console.ReadLine();
        }
    }
}
