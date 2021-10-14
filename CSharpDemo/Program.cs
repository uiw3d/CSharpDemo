using System;
using CSharpDemo;
using System.Collections.Generic;
enum PlayerState
{
    Idle,
    Walk,
    Die
}

class Orange
{
    //delegate
    public delegate bool SortRule(int x, int y);
    static SortRule AscendingRule = (x, y) => x > y;
    static SortRule DecendingRule = (x, y) => x < y;
    static SortRule ReverseRule = (x, y) => true;

    //lambda
    static Func<int, int, bool> AscendingFuc = (x, y) => x > y;

    //Action
    static Action<int, int> action = (x, y) => PrintObject("This is an action called");

    static void Main()
    {
        action(1, 2);
        //1 bit is a 0 or 1
        //1 byte is 8 bit
        //1 kb is 1024 kilobyte
        //1 mb is 1024 kilobyte
        //1 gb is 1024 megabyte

        //an int is 4 byte
        int intVar = (int)3.1f;

        float floatVar = 1.00000015f;
        char charVar = 'a';

        //string is an array of characters
        string stringVar = "name, sfsdis ,sdf s, sdfsdfsfsfvd sdfsdfsvsdf dmdfdf , sfdsdfsdfsdf";
        //just like this int array
        int[] array = { 1, 2, 3, 4 };

        System.Console.WriteLine(stringVar[3]);

        //short circuit
        if (GetABool() || GetAnoterBool())
        {

        }

        //while
        int i = 0;
        while (i < 10)
        {
            System.Console.WriteLine(i);
            i++;
        }
        System.Console.WriteLine(i);
        System.Console.WriteLine("=========================================================");

        for (int j = 0/*happens in the begining only once*/; j < 10/*happens in the begining of the loop*/; j++/*happens at the end of the loop*/)
        {
            System.Console.WriteLine(j);

        }

        System.Console.WriteLine("=========================================================");
        int k = 0;
        for (; k < 10;)
        {
            System.Console.WriteLine(k);
            k++;
        }

        do
        {
            System.Console.WriteLine("guarenteened to run at least once");
        } while (false);

        //using string is not only taking more memory, but also hard to track
        string payerStates = "Idling";
        //use a enum is cleaner
        PlayerState playerState = PlayerState.Walk;

        switch ((PlayerState)3)
        {
            case PlayerState.Idle:
                System.Console.WriteLine("Player is idle");
                break;
            case PlayerState.Walk:
                System.Console.WriteLine("Player is walking");
                break;
            case PlayerState.Die:
                System.Console.WriteLine("Player is dead");
                break;
            default:
                System.Console.WriteLine("Player is in a default state");
                break;
        }
        System.Console.WriteLine(sizeof(PlayerState));

        Dictionary<string, int> Employees = new Dictionary<string, int>();
        Employees.Add("Bob", 20);
        Employees.Add("Ugine", 21);

        Employees.TryGetValue("Ugine", out int BobAge);
        System.Console.WriteLine(BobAge);

        System.Collections.Generic.Dictionary<string, int>.KeyCollection keys = Employees.Keys;
        foreach (var key in keys)
        {
            System.Console.WriteLine(key);
        }

        var valus = Employees.Values;
        foreach (var val in valus)
        {
            System.Console.WriteLine(val);
        }

        Dictionary<PlayerState, int> stateNumbers = new Dictionary<PlayerState, int>();
        
        PrintObject<string, int>("haha", 3);
        PrintObject<int, float>(1, 1.2f);
        PrintObject<PlayerState, bool>(playerState, false);

        Animal animal = new Animal();

        Animal animal2 = new Animal("Mocha", 7, 21);
        PrintObject(animal2.GetAge());

        animal2.Weight = 23;
        PrintObject(animal2.Weight);

        int valueToIncrement = 0;
        IncrementInt(ref valueToIncrement);
        PrintObject(valueToIncrement);

        animal2.SetAge(2);
        IncrmentAnimalAge(animal2);
        PrintObject(animal2.GetAge());

        Dog dog = new Dog("Spike", 6, 70, "bacon");
        Bird bird = new Bird("Sparow", 4, 10, 200);
        Car car = new Car(20, "Toyota", "RV4", 2021);
        IObjectGenericInfo[] objs = { animal, animal2, dog, bird, car};

        car.healthComp.TakeDamage(10);

        foreach(IObjectGenericInfo animalItem in objs)
        {
            PrintObject(animalItem.GetName());
        }

        int[] intArryToSort = { 2, 1, 3, 5, 4 };


        
        Sort(intArryToSort, ReverseRule);
        
        //lambda 
        Sort(intArryToSort, AscendingFuc);
        
        foreach (int arrayItem in intArryToSort)
        {
            PrintObject(arrayItem);
        }
    }


    static void Sort(int[] arrayToSort, SortRule rule)
    {
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            for (int j = i + 1; j < arrayToSort.Length; j++)
            {
                bool SholdSwitch = rule(arrayToSort[i], arrayToSort[j]);
                if (SholdSwitch)
                {
                    int temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[j];
                    arrayToSort[j] = temp;
                }
            }
        }
    }

    static void Sort(int[] arrayToSort, Func<int, int, bool> rule)
    {
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            for (int j = i + 1; j < arrayToSort.Length; j++)
            {
                bool SholdSwitch = rule(arrayToSort[i], arrayToSort[j]);
                if (SholdSwitch)
                {
                    int temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[j];
                    arrayToSort[j] = temp;
                }
            }
        }
    }
    static void IncrmentAnimalAge(Animal animalToIncrement)
    {
        animalToIncrement.SetAge(animalToIncrement.GetAge() + 1);
    }

    static void IncrementInt(ref int intToIncrement)
    {
        intToIncrement++;
    }

    public static void PrintObject<T>(T ObjToPrint)
    {
        System.Console.WriteLine(ObjToPrint);
    }
    //generic programming, T, and T2 can be any type.
    static void PrintObject<T, T2>(T objectToPrint, T2 OtherObjToPrint)
    {
        System.Console.WriteLine(objectToPrint);
        System.Console.WriteLine(OtherObjToPrint);
    }

    static bool GetABool()
    {
        return true;
    }

    static bool GetAnoterBool()
    {
        System.Console.WriteLine("Getting another bool");
        return true;
    }
}
