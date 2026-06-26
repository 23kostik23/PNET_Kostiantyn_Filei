using System;

namespace Filei_PNet_2
{
    // Класи для демонстрації коваріантності та контрваріантності
    class Animal { public string Name { get; set; } }
    class Dog : Animal { public void Bark() { Console.WriteLine("Гав!"); } }

    delegate Animal AnimalFactoryDelegate();
    delegate void AnimalActionDelegate(Dog dog);

    delegate void OperationDelegate();

    class Program
    {
        static void StaticMethod() => Console.WriteLine("[Статика] Виклик статичного методу.");

        void InstanceMethod() => Console.WriteLine("[Екземпляр] Виклик екземплярного методу.");

        static Dog CreateDog() => new Dog { Name = "Рекс" };

        static void FeedAnimal(Animal a) => Console.WriteLine($"Годуємо тварину на ім'я {a.Name}");

        static void Main()
        {
            Console.WriteLine("--- 1. Статичні та екземплярні методи (Invoke vs () ) ---");
            OperationDelegate staticDel = StaticMethod;
            staticDel(); 

            Program prog = new Program();
            OperationDelegate instanceDel = prog.InstanceMethod;
            instanceDel.Invoke(); 

            Console.WriteLine("\n--- 2. Коваріантність та контрваріантність ---");
            AnimalFactoryDelegate factory = CreateDog; 
            Animal myAnimal = factory();
            Console.WriteLine($"Створено тварину: {myAnimal.Name}");

            AnimalActionDelegate action = FeedAnimal; 
            action((Dog)myAnimal);

            Console.WriteLine("\n--- 3. Ланцюжок делегатів (Multicast) ---");
            OperationDelegate chain = staticDel;
            chain += instanceDel; 
            chain += () => Console.WriteLine("[Лямбда] Анонімний метод у ланцюжку.");

            Console.WriteLine("Виклик повного ланцюжка:");
            chain();

            Console.WriteLine("\nВидалення екземплярного методу з ланцюжка (-=):");
            chain -= instanceDel;
            chain();

            Console.WriteLine("\nВиклик довільного (першого) делегата через GetInvocationList():");
            Delegate[] invocationList = chain.GetInvocationList();
            if (invocationList.Length > 0)
            {
                ((OperationDelegate)invocationList[0]).Invoke();
            }

            Console.WriteLine("\n--- 4. Узагальнені делегати vs Власні ---");
            Func<int, int, int> addFunc = (x, y) => x + y;
            Console.WriteLine($"Результат виконання Func<int, int, int>: 5 + 10 = {addFunc(5, 10)}");
        }
    }
}
