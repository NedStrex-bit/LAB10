using Lab10;
using Библиотека_лаба_10;
using Laba10;

namespace UnitTestLab10
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AnalogWatch_Init_SetsPropertiesCorrectly()
        {
            // Arrange
            AnalogWatch watch = new AnalogWatch();

            // Act
            using (StringReader reader = new StringReader("TestBrand\n2022\nTestStyle"))
            {
                Console.SetIn(reader);
                watch.Init();
            }

            // Assert
            Assert.AreEqual("TestBrand", watch.Brand);
            Assert.AreEqual(2022, watch.Year);
            Assert.AreEqual("TestStyle", watch.WatchStyle);
        }

        [Test]
        public void AnalogWatch_Show_ReturnsCorrectString()
        {
            // Arrange
            AnalogWatch watch = new AnalogWatch("TestBrand", 2022, "TestStyle");
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            watch.Show();
            string result = sw.ToString().Trim();

            // Assert
            StringAssert.Contains("Brand: TestBrand, Year: 2022", result);
            StringAssert.Contains("Watch Style: TestStyle", result);
        }

        [Test]
        public void AnalogWatch_Clone_CreatesValidClone()
        {
            // Arrange
            AnalogWatch original = new AnalogWatch("TestBrand", 2022, "TestStyle");

            // Act
            AnalogWatch clone = (AnalogWatch)original.Clone();

            // Assert
            Assert.That(clone, Is.Not.SameAs(original));
            Assert.AreEqual(original.Brand, clone.Brand);
            Assert.AreEqual(original.Year, clone.Year);
            Assert.AreEqual(original.WatchStyle, clone.WatchStyle);
        }

        [Test]
        public void AnalogWatch_RandomInit_ReturnsWatchWithValidProperties()
        {
            // Act
            AnalogWatch watch = AnalogWatch.RandomInit();

            // Assert
            Assert.Contains(watch.Brand, new[] { "Xiaomi", "Apple", "GShock" });
            Assert.GreaterOrEqual(watch.Year, 1900);
            Assert.LessOrEqual(watch.Year, DateTime.Now.Year);
            Assert.Contains(watch.WatchStyle, new[] { "Style1", "Style2", "Style3" });
        }

        [Test]
        public void AnalogWatch_UniqueAnalogWatchStyles_ReturnsUniqueStyles()
        {
            // Arrange
            Watch[] watches = new Watch[]
            {
                new AnalogWatch("TestBrand1", 2022, "Style1"),
                new AnalogWatch("TestBrand2", 2023, "Style2"),
                new AnalogWatch("TestBrand3", 2024, "Style1"),
                new AnalogWatch("TestBrand4", 2025, "Style3"),
                new AnalogWatch("TestBrand5", 2026, "Style2")
            };

            // Act
            var uniqueStyles = AnalogWatch.UniqueAnalogWatchStyles(watches);

            // Assert
            Assert.AreEqual(3, uniqueStyles.Count);
            Assert.IsTrue(uniqueStyles.Contains("Style1"));
            Assert.IsTrue(uniqueStyles.Contains("Style2"));
            Assert.IsTrue(uniqueStyles.Contains("Style3"));
        }

        [Test]
        public void AnalogWatch_CompareTo_CorrectlyComparesWatches()
        {
            // Arrange
            AnalogWatch watch1 = new AnalogWatch("BrandA", 2022, "Style1");
            AnalogWatch watch2 = new AnalogWatch("BrandA", 2022, "Style1");
            AnalogWatch watch3 = new AnalogWatch("BrandB", 2022, "Style1");
            AnalogWatch watch4 = new AnalogWatch("BrandA", 2023, "Style1");
            AnalogWatch watch5 = new AnalogWatch("BrandA", 2022, "Style2");

            // Act & Assert
            Assert.AreEqual(0, watch1.CompareTo(watch2));
            Assert.Less(0, watch1.CompareTo(watch3));
            Assert.Less(0, watch1.CompareTo(watch4));
            Assert.Greater(0, watch4.CompareTo(watch1));
            Assert.Less(0, watch1.CompareTo(watch5));
        }

        [Test]
        public void AnalogWatch_Equals_ReturnsTrueForEqualWatches()
        {
            // Arrange
            AnalogWatch watch1 = new AnalogWatch("BrandA", 2022, "Style1");
            AnalogWatch watch2 = new AnalogWatch("BrandA", 2022, "Style1");
            AnalogWatch watch3 = new AnalogWatch("BrandB", 2022, "Style1");

            // Act & Assert
            Assert.IsTrue(watch1.Equals(watch2));
            Assert.IsFalse(watch1.Equals(watch3));
        }
        [Test]
        public void ElectroWatch_Init_SetsPropertiesCorrectly()
        {
            // Arrange
            ElectroWatch watch = new ElectroWatch();

            // Act
            using (StringReader reader = new StringReader("TestBrand\n2022\nTestSystem\ntrue\nTestStyle"))
            {
                Console.SetIn(reader);
                watch.Init();
            }

            // Assert
            Assert.AreEqual("TestBrand", watch.Brand);
            Assert.AreEqual(2022, watch.Year);
            Assert.AreEqual("TestSystem", watch.OpSystem);
            Assert.AreEqual(true, watch.PulseSensor);
            Assert.AreEqual("TestStyle", watch.DisplayStyle);
        }

        [Test]
        public void ElectroWatch_Show_ReturnsCorrectString()
        {
            // Arrange
            ElectroWatch watch = new ElectroWatch("TestBrand", 2022, "TestSystem", true, "TestStyle");
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            watch.Show();
            string result = sw.ToString().Trim();

            // Assert
            StringAssert.Contains("Brand: TestBrand, Year: 2022", result);
            StringAssert.Contains("Операционная система = TestSystem", result);
            StringAssert.Contains("Датчик пульса = Да", result);
            StringAssert.Contains("Стиль дисплея = TestStyle", result);
        }

        [Test]
        public void ElectroWatch_Clone_CreatesValidClone()
        {
            // Arrange
            ElectroWatch original = new ElectroWatch("TestBrand", 2022, "TestSystem", true, "TestStyle");

            // Act
            ElectroWatch clone = (ElectroWatch)original.Clone();

            // Assert
            Assert.That(clone, Is.Not.SameAs(original));
            Assert.AreEqual(original.Brand, clone.Brand);
            Assert.AreEqual(original.Year, clone.Year);
            Assert.AreEqual(original.OpSystem, clone.OpSystem);
            Assert.AreEqual(original.PulseSensor, clone.PulseSensor);
            Assert.AreEqual(original.DisplayStyle, clone.DisplayStyle);
        }

        [Test]
        public void ElectroWatch_RandomInit_ReturnsWatchWithValidProperties()
        {
            // Act
            ElectroWatch watch = ElectroWatch.RandomInit();

            // Assert
            Assert.Contains(watch.Brand, new[] { "Xiaomi", "Apple", "GShock" });
            Assert.GreaterOrEqual(watch.Year, 1900);
            Assert.LessOrEqual(watch.Year, DateTime.Now.Year);
            Assert.Contains(watch.OpSystem, new[] { "System1", "System2", "System3" });
            Assert.Contains(watch.DisplayStyle, new[] { "Style1", "Style2", "Style3" });
        }

        [Test]
        public void ElectroWatch_CompareTo_CorrectlyComparesWatches()
        {
            // Arrange
            ElectroWatch watch1 = new ElectroWatch("BrandA", 2022, "System1", true, "Style1");
            ElectroWatch watch2 = new ElectroWatch("BrandA", 2022, "System1", true, "Style1");
            ElectroWatch watch3 = new ElectroWatch("BrandB", 2022, "System2", false, "Style2");

            // Act & Assert
            Assert.AreEqual(0, watch1.CompareTo(watch2));
            Assert.Less(0, watch1.CompareTo(watch3));
            Assert.Greater(0, watch3.CompareTo(watch1));
        }

        [Test]
        public void ElectroWatch_Equals_ReturnsTrueForEqualWatches()
        {
            // Arrange
            ElectroWatch watch1 = new ElectroWatch("BrandA", 2022, "System1", true, "Style1");
            ElectroWatch watch2 = new ElectroWatch("BrandA", 2022, "System1", true, "Style1");
            ElectroWatch watch3 = new ElectroWatch("BrandB", 2022, "System2", false, "Style2");

            // Act & Assert
            Assert.IsTrue(watch1.Equals(watch2));
            Assert.IsFalse(watch1.Equals(watch3));
        }
        [Test]
        public void SmartWatch_Init_SetsPropertiesCorrectly()
        {
            // Arrange
            SmartWatch watch = new SmartWatch();

            // Act
            using (StringReader reader = new StringReader("TestBrand\n2022\nTestSystem\ntrue"))
            {
                Console.SetIn(reader);
                watch.Init();
            }

            // Assert
            Assert.AreEqual("TestBrand", watch.Brand);
            Assert.AreEqual(2022, watch.Year);
            Assert.AreEqual("TestSystem", watch.OpSystem);
            Assert.AreEqual(true, watch.PulseSensor);
        }

        [Test]
        public void SmartWatch_Show_ReturnsCorrectString()
        {
            // Arrange
            SmartWatch watch = new SmartWatch("TestBrand", 2022, "TestSystem", true);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            watch.Show();
            string result = sw.ToString().Trim();

            // Assert
            StringAssert.Contains("Brand: TestBrand, Year: 2022", result);
            StringAssert.Contains("Операционная система = TestSystem", result);
            StringAssert.Contains("Датчик пульса = Да", result);
        }

        [Test]
        public void SmartWatch_RandomInit_ReturnsWatchWithValidProperties()
        {
            // Act
            SmartWatch watch = SmartWatch.RandomInit();

            // Assert
            Assert.Contains(watch.Brand, new[] { "Brand1", "Brand2", "Brand3" });
            Assert.GreaterOrEqual(watch.Year, 1900);
            Assert.LessOrEqual(watch.Year, DateTime.Now.Year);
            Assert.Contains(watch.OpSystem, new[] { "System1", "System2", "System3" });
        }

        [Test]
        public void SmartWatch_SmartWatchesWithPulseSensorCount_ReturnsCorrectCount()
        {
            // Arrange
            Watch[] watches = new Watch[]
            {
                new SmartWatch("Brand1", 2022, "System1", true),
                new SmartWatch("Brand2", 2023, "System2", false),
                new SmartWatch("Brand3", 2024, "System3", true),
                new SmartWatch("Brand4", 2025, "System1", false),
                new SmartWatch("Brand5", 2026, "System2", true)
            };

            // Act
            int count = SmartWatch.SmartWatchesWithPulseSensorCount(watches);

            // Assert
            Assert.AreEqual(3, count);
        }

        [Test]
        public void SmartWatch_CompareTo_CorrectlyComparesWatches()
        {
            // Arrange
            SmartWatch watch1 = new SmartWatch("BrandA", 2022, "System1", true);
            SmartWatch watch2 = new SmartWatch("BrandA", 2022, "System1", true);
            SmartWatch watch3 = new SmartWatch("BrandB", 2023, "System2", false);

            // Act & Assert
            Assert.AreEqual(0, watch1.CompareTo(watch2));
            Assert.Less(0, watch1.CompareTo(watch3));
            Assert.Greater(0, watch3.CompareTo(watch1));
        }

        [Test]
        public void SmartWatch_Equals_ReturnsTrueForEqualWatches()
        {
            // Arrange
            SmartWatch watch1 = new SmartWatch("BrandA", 2022, "System1", true);
            SmartWatch watch2 = new SmartWatch("BrandA", 2022, "System1", true);
            SmartWatch watch3 = new SmartWatch("BrandB", 2023, "System2", false);

            // Act & Assert
            Assert.IsTrue(watch1.Equals(watch2));
            Assert.IsFalse(watch1.Equals(watch3));
        }
        [Test]
        public void Watch_Init_SetsPropertiesCorrectly()
        {
            // Arrange
            Watch watch = new Watch();

            // Act
            using (StringReader reader = new StringReader("TestBrand\n2022"))
            {
                Console.SetIn(reader);
                watch.Init();
            }

            // Assert
            Assert.AreEqual("TestBrand", watch.Brand);
            Assert.AreEqual(2022, watch.Year);
        }

        [Test]
        public void Watch_Show_ReturnsCorrectString()
        {
            // Arrange
            Watch watch = new Watch("TestBrand", 2022);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            watch.Show();
            string result = sw.ToString().Trim();

            // Assert
            StringAssert.Contains("Бренд = TestBrand Год выпуска = 2022", result);
        }

        [Test]
        public void Watch_NewestBrand_ReturnsCorrectBrand()
        {
            // Arrange
            Watch[] watches = new Watch[]
            {
                new Watch("Brand1", 2021),
                new Watch("Brand2", 2022),
                new Watch("Brand3", 2023)
            };

            // Act
            string newestBrand = Watch.NewestBrand(watches);

            // Assert
            Assert.AreEqual("Brand3", newestBrand);
        }

        [Test]
        public void Watch_Equals_ReturnsTrueForEqualWatches()
        {
            // Arrange
            Watch watch1 = new Watch("BrandA", 2022);
            Watch watch2 = new Watch("BrandA", 2022);
            Watch watch3 = new Watch("BrandB", 2023);

            // Act & Assert
            Assert.IsTrue(watch1.Equals(watch2));
            Assert.IsFalse(watch1.Equals(watch3));
        }

        [Test]
        public void Watch_Clone_CreatesValidClone()
        {
            // Arrange
            Watch original = new Watch("TestBrand", 2022);

            // Act
            Watch clone = (Watch)original.Clone();

            // Assert
            Assert.That(clone, Is.Not.SameAs(original));
            Assert.AreEqual(original.Brand, clone.Brand);
            Assert.AreEqual(original.Year, clone.Year);
        }

        [Test]
        public void Watch_CompareTo_CorrectlyComparesWatches()
        {
            // Arrange
            Watch watch1 = new Watch("BrandA", 2022);
            Watch watch2 = new Watch("BrandA", 2023);
            Watch watch3 = new Watch("BrandB", 2022);

            // Act & Assert
            Assert.Less(watch1.CompareTo(watch2), 0);
            Assert.Greater(watch1.CompareTo(watch3), 0);
            Assert.AreEqual(0, watch1.CompareTo(watch1));
        }

        [Test]
        public void Watch_ShallowCopy_CreatesShallowCopy()
        {
            // Arrange
            Watch original = new Watch("TestBrand", 2022);

            // Act
            Watch copy = original.ShallowCopy();

            // Assert
            Assert.That(copy, Is.Not.SameAs(original));
            Assert.AreEqual(original.Brand, copy.Brand);
            Assert.AreEqual(original.Year, copy.Year);

        }
        [Test]
        public void Rectangle_Init_SetsPropertiesCorrectly()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();

            // Act
            rectangle.Init();

            // Assert
            Assert.That(rectangle.Width, Is.GreaterThanOrEqualTo(0.0001).And.LessThanOrEqualTo(46340.9499));
            Assert.That(rectangle.Length, Is.GreaterThanOrEqualTo(0.0001).And.LessThanOrEqualTo(46340.9499));
        }

        [Test]
        public void Rectangle_Increase_IncreasesSizeCorrectly()
        {
            // Arrange
            Rectangle rectangle = new Rectangle(3, 4);

            // Act
            rectangle.Increase(2);

            // Assert
            Assert.AreEqual(6, rectangle.Width);
            Assert.AreEqual(8, rectangle.Length);
        }

        [Test]
        public void Rectangle_GetCount_ReturnsCorrectCount()
        {
            // Arrange
            Rectangle rectangle1 = new Rectangle();
            Rectangle rectangle2 = new Rectangle();

            // Act
            int count = Rectangle.GetCount();

            // Assert
            Assert.AreEqual(2, count);
        }

        [Test]
        public void Rectangle_CompareTo_CorrectlyComparesRectangles()
        {
            // Arrange
            Rectangle rectangle1 = new Rectangle(3, 4);
            Rectangle rectangle2 = new Rectangle(2, 6);

            // Act & Assert
            Assert.AreEqual(12, rectangle1.CompareTo(rectangle2));
        }

        [Test]
        public void Rectangle_Equals_ReturnsTrueForEqualRectangles()
        {
            // Arrange
            Rectangle rectangle1 = new Rectangle(3, 4);
            Rectangle rectangle2 = new Rectangle(3, 4);
            Rectangle rectangle3 = new Rectangle(2, 6);

            // Act & Assert
            Assert.IsTrue(rectangle1.Equals(rectangle2));
            Assert.IsFalse(rectangle1.Equals(rectangle3));
        }
        [Test]
        public void RectangleArray_Constructor_WithLength_CreatesArrayWithGivenLength()
        {
            // Arrange
            int length = 5;

            // Act
            RectangleArray rectangleArray = new RectangleArray(length);

            // Assert
            Assert.AreEqual(length, rectangleArray.Length);
        }

        [Test]
        public void RectangleArray_Constructor_Default_CreatesEmptyArray()
        {
            // Act
            RectangleArray rectangleArray = new RectangleArray();

            // Assert
            Assert.AreEqual(0, rectangleArray.Length);
        }

        [Test]
        public void RectangleArray_Init_AddsRectanglesToArray()
        {
            // Arrange
            RectangleArray rectangleArray = new RectangleArray();
            int expectedLength = 3;

            // Act
            rectangleArray.Init();

            // Assert
            Assert.AreEqual(expectedLength, rectangleArray.Length);
        }

        [Test]
        public void RectangleArray_RandomInit_AddsRectanglesToArray()
        {
            // Arrange
            RectangleArray rectangleArray = new RectangleArray();
            int expectedLength = 3;

            // Act
            rectangleArray.RandomInit(expectedLength);

            // Assert
            Assert.AreEqual(expectedLength, rectangleArray.Length);
        }

        [Test]
        public void RectangleArray_Indexer_AccessesCorrectElement()
        {
            // Arrange
            RectangleArray rectangleArray = new RectangleArray(3);
            Rectangle expectedRectangle = new Rectangle(1, 2);

            // Act
            rectangleArray[1] = expectedRectangle;

            // Assert
            Assert.AreEqual(expectedRectangle, rectangleArray[1]);
        }

        [Test]
        public void RectangleArray_GetCount_ReturnsTotalNumberOfRectangles()
        {
            // Arrange
            RectangleArray rectangleArray = new RectangleArray();
            int expectedCount = 5;
            rectangleArray.RandomInit(expectedCount);

            // Act
            int actualCount = rectangleArray.GetCount();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RectangleArray_Show_PrintsRectangles()
        {
            // Arrange
            RectangleArray rectangleArray = new RectangleArray();
            rectangleArray.RandomInit(3);

            // Act
            rectangleArray.Show();
        }

    }

}