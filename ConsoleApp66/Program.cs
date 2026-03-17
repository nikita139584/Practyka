class Program
{
    // створює бар'єр для 3 потоків з дією після завершення кожного етапу
    static Barrier barrier = new Barrier(4, (b) =>
    {
        Console.WriteLine($"\nЕтап {b.CurrentPhaseNumber + 1} завершено усіма, переходимо до наступного!\n");
    });

    static void Friend(object data)
    {
        var friendData = (Tuple<string, string[]>)data;
        string name = friendData.Item1;
        string[] actions = friendData.Item2;
        var random = new Random();

        foreach (var action in actions)
        {
            int duration = random.Next(1000, 2000);
            Console.WriteLine($"{name}: Розпочинає таку дію: {action}");
            Thread.Sleep(duration);
            Console.WriteLine($"{name}: Завершує цю дію");
            barrier.SignalAndWait(); // чекаємо, поки всі дійдуть до бар'єру
        }

        Console.WriteLine($"{name}: Готово!");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var friends = new[]
        {
            Tuple.Create("Костянтин", new[]
                {
                    "Договоритися о місці",
                }),
            Tuple.Create("Руслан", new[]
                {
                    "Договоритися о місці",
                }),
            Tuple.Create("Олена", new[]
                {
                    "Договоритися о місці",
                }),
            Tuple.Create("Oлег", new[]
                {
                    "Договоритися о місці",
                }),
        };

        var threads = new Thread[friends.Length];

        for (int i = 0; i < friends.Length; i++)
        {
            threads[i] = new Thread(Friend);
            threads[i].Start(friends[i]);
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("\n Зараз треба взяти напої і їжу\n");

        var TakeFoodOrdrinks = new[]
{
            Tuple.Create("Костянтин", new[]
                {
                    "Взяти їжу",
                    "Взяти напої",
                }),
            Tuple.Create("Руслан", new[]
                {
                    "Взяти їжу",
                    "Взяти напої",
                }),
            Tuple.Create("Олена", new[]
                {
                    "Взяти їжу",
                    "Взяти напої",
                }),
            Tuple.Create("Oлег", new[]
                {
                   "Взяти їжу",
                   "Взяти напої",
                }),
        };

        for (int i = 0; i < TakeFoodOrdrinks.Length; i++)
        {
            threads[i] = new Thread(Friend);
            threads[i].Start(TakeFoodOrdrinks[i]);
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        var go = new[]
{
            Tuple.Create("Костянтин", new[]
                {
                    "Йти до місця",
                    "Їхати до місця",
                }),
            Tuple.Create("Руслан", new[]
                {
                    "Йти до місця",
                    "Їхати до місця",
                }),
            Tuple.Create("Олена", new[]
                {
                    "Йти до місця",
                    "Їхати до місця",
                }),
            Tuple.Create("Oлег", new[]
                {
                    "Йти до місця",
                    "Їхати до місця",
                }),


        };


        for (int i = 0; i < friends.Length; i++)
        {
            threads[i] = new Thread(Friend);
            threads[i].Start(go[i]);
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        var kommen = new[]
        {
            Tuple.Create("Костянтин", new[]
                {
                    "Прийти",
                }),
            Tuple.Create("Руслан", new[]
                {
                    "Прийти",
                }),
            Tuple.Create("Олена", new[]
                {
                    "Прийти",
                }),
            Tuple.Create("Oлег", new[]
                {
                    "Прийти",
                }),


        };


        for (int i = 0; i < friends.Length; i++)
        {
            threads[i] = new Thread(Friend);
            threads[i].Start(kommen[i]);
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
        Console.WriteLine("\nУсі прийшли на пікнік");
    }
}