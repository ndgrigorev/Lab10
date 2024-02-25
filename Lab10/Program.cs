using Lab10_Library;
using System.ComponentModel.Design;
namespace Lab10
{
    internal class Program
    {
        static void Main()
        {
            Animals[] animals = new Animals[20];
            for (int i = 0; i < 5; i++)
            {
                Animals temp = new Animals();
                temp.RandomInit();
                animals[i] = temp;
            }
            for (int i = 5; i < 10; i++)
            {
                Mammals temp = new Mammals();
                temp.RandomInit();
                animals[i] = temp;
            }
            for (int i = 10; i < 15; i++)
            {
                Cats temp = new Cats();
                temp.RandomInit();
                animals[i] = temp;
            }
            for (int i = 15; i < 20; i++)
            {
                Fishes temp = new Fishes();
                temp.RandomInit();
                animals[i] = temp;
            }
            foreach (Animals animal in animals)
            {
                animal.Show();
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Средний вес млекопитающих мужского пола = {Animals.SrWeight(animals)}");
            Console.WriteLine("Рыжие кошки женского пола: ");
            string [] arrayNames = Animals.SpecialCats(animals);
            if (arrayNames[0] != null)
            {
                foreach (string name in arrayNames)
                {
                    if (name == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(name);
                    }
                }
            }
            else
            {
                Console.WriteLine("В массиве нет рыжих кошек женского пола");
            }
            string elderFish = Animals.ElderFish(animals);
            if (elderFish != null)
            {
                Console.WriteLine($"Самая старшая морская рыба - {elderFish}");
            }
            else
            {
                Console.WriteLine("В массиве нет морских рыб");
            }
            IInit[] array = new IInit[20];
            int[] arrayCount = { 0, 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                array[i] = animal;
            }
            for (int i = 4; i < 8; i++)
            {
                Mammals animal = new Mammals();
                animal.RandomInit();
                array[i] = animal;
            }
            for (int i = 8; i < 12; i++)
            {
                Cats animal = new Cats();
                animal.RandomInit();
                array[i] = animal;
            }
            for (int i = 12; i < 16; i++)
            {
                Fishes animal = new Fishes();
                animal.RandomInit();
                array[i] = animal;
            }
            for (int i = 16; i < 20; i++)
            {
                CalendarDate date = new CalendarDate();
                date.RandomInit();
                array[i] = date;
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            foreach (var item in array)
            {
                Console.WriteLine(item);
                if (item is Animals)
                {
                    arrayCount[0]++;
                }
                if (item is Mammals) 
                {
                    arrayCount[1]++;
                }
                if (item is Cats)
                {
                    arrayCount[2]++;
                }
                if (item is Fishes)
                {
                    arrayCount[3]++;
                }
                if (item is CalendarDate)
                {
                    arrayCount[4]++;
                }
            }
            Console.WriteLine($"Всего в массиве {arrayCount[0]} Animals, {arrayCount[1]} Mammals, {arrayCount[2]} Cats, {arrayCount[3]} Fishes, {arrayCount[4]} CalendarDate");
            Animals newAnimal = new Animals(100, "Умка", "мужской", 10);
            animals[0] = newAnimal;
            Array.Sort(animals);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Отсортированный первый массив по именам");
            foreach (Animals animal in animals)
            {
                Console.WriteLine(animal);
            }
            int pos = Array.BinarySearch(animals, new Animals(100, "Умка", "мужской", 10));
            if (pos < -0)
            {
                Console.WriteLine("Такого элемента нет");
            }
            else
            {
                Console.WriteLine($"Позиция искомого элемента = {pos + 1}");
            }
            Array.Sort(animals, new SortByAge());
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Отсортированный первый массив по возрасту");
            foreach (Animals animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Копирование");
            Animals originalAnimal = new Animals();
            originalAnimal.RandomInit();
            Animals clone = (Animals)originalAnimal.Clone();
            Animals copy = (Animals)originalAnimal.ShallowCopy();
            Console.WriteLine(originalAnimal); 
            Console.WriteLine(clone);
            Console.WriteLine(copy);
            Console.WriteLine("После изменения");
            copy.Name = "copy " + originalAnimal.Name;
            clone.Name = "clone " + originalAnimal.Name;
            copy.Id.Number = 100;
            clone.Id.Number = 200;
            Console.WriteLine(originalAnimal);
            Console.WriteLine(clone);
            Console.WriteLine(copy);
        }
    }
}
