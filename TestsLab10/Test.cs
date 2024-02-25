using Lab10_Library;
namespace TestsLab10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Animals expected = new Animals();
            //Act
            Animals actual = new Animals(expected);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            Cats expected = new Cats(0, "cat", "мужской", 0, 1, "cat", "blue", 0);
            //Act
            Cats actual = new Cats(-5, "cat", "мужской", -6, -1, "cat", "blue", -23);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            Fishes expected = new Fishes(0, "fish", "мужской", 2, "fish", 0);
            //Act
            Fishes actual = new Fishes(0, "fish", "мужской", 2, "fish", -5);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            Fishes expected = new Fishes();
            //Act
            Fishes actual = new Fishes(1, "Безымянный", "мужской", 0, "пресноводная", 3);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            Mammals expected = new Mammals();
            //Act
            Mammals actual = new Mammals(1, "Безымянный", "мужской", 0, 1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            //Arrange
            double expected = 1;
            //Act
            Mammals animal1 = new Mammals();
            Cats animal2 = new Cats();
            Mammals animal3 = new Mammals(1, "m", "женский", 3, 5);
            Animals[] array = { animal1, animal2, animal3 };
            double actual = Animals.SrWeight(array);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod7()
        {
            //Arrange
            string[] expected = { "cat1", "cat3" };
            //Act
            Cats animal1 = new Cats(3, "cat1", "женский", 15, 10, "cat", "рыжий", 20);
            Cats animal2 = new Cats();
            Cats animal3 = new Cats(2, "cat3", "женский", 12, 14, "cat", "рыжий", 22);
            Animals[] array = { animal1, animal2, animal3 };
            string[]actual = Animals.SpecialCats(array);
            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }
        [TestMethod]
        public void TestMethod8()
        {
            //Arrange
            string expected = "fish3";
            //Act
            Fishes animal1 = new Fishes(3, "fish1", "женский", 3, "морская", 5);
            Fishes animal2 = new Fishes();
            Fishes animal3 = new Fishes(2, "fish3", "женский", 7, "морская", 5);
            Animals[] array = { animal1, animal2, animal3 };
            string actual = Animals.ElderFish(array);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod9()
        {
            //Arrange
            Mammals expected = new Mammals();
            //Act
            Fishes actual = new Fishes();
            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
        }
        [TestMethod]
        public void TestMethod10()
        {
            Fishes animal1 = new Fishes(3, "fish1", "женский", 3, "морская", 5);
            Fishes animal2 = new Fishes(2, "afish2", "женский", 7, "морская", 5);
            Fishes animal3 = new Fishes(2, "fish3", "женский", 7, "морская", 5);
            //Arrange
            Fishes[] expected = { animal2, animal1, animal3 };
            //Act
            Fishes[] actual = {animal1, animal2, animal3 };
            Array.Sort(actual);
            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[2], actual[2]);
        }
        [TestMethod]
        public void TestMethod11()
        {
            //Arrange
            Mammals expected = new Mammals();
            //Act
            Mammals actual = (Mammals)expected.ShallowCopy();
            actual.Id.Number = 100;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod12()
        {
            //Arrange
            Animals expected = new Animals();
            //Act
            Animals actual = (Animals)expected.Clone();
            actual.Id.Number = 100;
            //Assert
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod13()
        {
            Fishes animal1 = new Fishes(3, "fish1", "женский", 6, "морская", 5);
            Fishes animal2 = new Fishes(2, "fish2", "женский", 1, "морская", 5);
            Fishes animal3 = new Fishes(2, "fish3", "женский", 7, "морская", 5);
            Fishes animal4 = new Fishes(2, "fish4", "женский", 7, "морская", 5);
            //Arrange
            Fishes[] expected = { animal2, animal1, animal3, animal4 };
            //Act
            Fishes[] actual = { animal1, animal2, animal3, animal4 };
            Array.Sort(actual, new SortByAge());
            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }
}