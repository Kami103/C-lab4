using ConsoleApp4;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Wybierz nr zadania:");
        int nr = Int16.Parse(Console.ReadLine());
        Console.Clear();
        switch (nr)
        {
            case 1:
                Zadanie1();
                break;
            case 2:
                Zadanie2();
                break;
            case 3:
                Zadanie3();
                break;
            case 4:
                Zadanie4();
                break;
            case 5:
                Zadanie5();
                break;
            default:
                Console.WriteLine("Zły numer.");
                break;
        }
    }

    public static void Zadanie1()
    {
        using (var sw = new StreamWriter("zadanie1.txt"))
        {
            sw.WriteLine("Mój nr indexu:");
            sw.WriteLine("117798");
        }

        using (var sr = new StreamReader("zadanie1.txt"))
        {
            var line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
        }
    }

    public static void Zadanie2()
    {
        using (var sw = new StreamWriter("zadanie2.1.txt"))
        {
            sw.WriteLine("plik 1 z zadnia 2");
        }

        using (var sw = new StreamWriter("zadanie2.2.txt"))
        {
            sw.WriteLine("plik 2 z zadnia 2");
        }

        Console.WriteLine("Dodaj nazwę pliku do wczytnia.");
        Console.WriteLine("Dostępne pliki:");
        Console.WriteLine("zadanie2.2.txt");
        Console.WriteLine("zadanie2.2.txt");
        String path = Console.ReadLine();
        using (var sr = new StreamReader(path))
        {
            var line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
        }
    }

    public static void Zadanie3()
    {
        int k = 0;
        int m = 0;
        using (var sr = new StreamReader("pesels.txt"))
        {
            var line = sr.ReadLine();
            while (line != null)
            {
                if (line[9] % 2 == 1)
                {
                    m++;
                }
                else
                {
                    k++;
                }

                line = sr.ReadLine();
            }
        }

        Console.WriteLine("Kobiet: " + k);
        Console.WriteLine("Mężczyzn: " + m);
    }

    public static void Zadanie4()
    {
        List<Root> list = new List<Root>();
        using (var sr = new StreamReader("db.json"))
        {
            var json = sr.ReadToEnd();

            list = JsonConvert.DeserializeObject<List<Root>>(json);
        }

        //a
        int date1 = 0;
        int date2 = 0;
        foreach (var VARIABLE in list)
        {
            if (VARIABLE.country.id.Equals("IN") && int.Parse(VARIABLE.date) == 1970)
            {
                date1 = int.Parse(VARIABLE.value);
            }

            if (VARIABLE.country.id.Equals("IN") && int.Parse(VARIABLE.date) == 2000)
            {
                date2 = int.Parse(VARIABLE.value);
            }
        }

        Console.WriteLine("a) " + (date2 - date1));
        //b
        foreach (var VARIABLE in list)
        {
            if (VARIABLE.country.id.Equals("US") && int.Parse(VARIABLE.date) == 1965)
            {
                date1 = int.Parse(VARIABLE.value);
            }

            if (VARIABLE.country.id.Equals("US") && int.Parse(VARIABLE.date) == 2010)
            {
                date2 = int.Parse(VARIABLE.value);
            }
        }
        Console.WriteLine("b) " + (date2 - date1));
        //c
        foreach (var VARIABLE in list)
        {
            if (VARIABLE.country.id.Equals("CN") && int.Parse(VARIABLE.date) == 1980)
            {
                date1 = int.Parse(VARIABLE.value);
            }

            if (VARIABLE.country.id.Equals("CN") && int.Parse(VARIABLE.date) == 2018)
            {
                date2 = int.Parse(VARIABLE.value);
            }
        }
        Console.WriteLine("c) " + (date2 - date1));
        //d
        Console.WriteLine("Wybierz kraj:");
        String kraj = Console.ReadLine();
        Console.WriteLine("Wybierz rok:");
        String rok = Console.ReadLine();
        
        foreach (var VARIABLE in list)
        {
            if (VARIABLE.country.value.Equals(kraj) && VARIABLE.date.Equals(rok))
            {
                date1 = int.Parse(VARIABLE.value);
            }
            
        }
        
        Console.WriteLine("d) " + date1);
        
        //e
        Console.WriteLine("Wybierz kraj:");
        kraj = Console.ReadLine();
        Console.WriteLine("Wybierz rok 1:");
        rok = Console.ReadLine();
        Console.WriteLine("Wybierz rok 2:");
        string rok2 = Console.ReadLine();

        foreach (var VARIABLE in list)
        {
            if (VARIABLE.country.value.Equals(kraj) && VARIABLE.date.Equals(rok))
            {
                date1 = int.Parse(VARIABLE.value);
            }
            if (VARIABLE.country.value.Equals(kraj) && VARIABLE.date.Equals(int.Parse(rok2).ToString()))
            {
                date2 = int.Parse(VARIABLE.value);
            }
            
        }
        Console.WriteLine("e) " + (date2-date1));
        //f
        Console.WriteLine("Wybierz kraj:");
        kraj = Console.ReadLine();
        Console.WriteLine("Wybierz rok:");
        rok = Console.ReadLine();
        
        foreach (var VARIABLE in list)
        {
            if (VARIABLE.country.value.Equals(kraj) && VARIABLE.date.Equals(rok))
            {
                date1 = int.Parse(VARIABLE.value);
            }
            if (VARIABLE.country.value.Equals(kraj) && VARIABLE.date.Equals((int.Parse(rok)-1).ToString()))
            {
                date2 = int.Parse(VARIABLE.value);
            }
            
        }
        double date3 = (date2 - date1) / date2;
        Console.WriteLine("f) " + date3+ "%");
    }

    public static void Zadanie5()
    {
        FilePersonRepository repository = new FilePersonRepository();
        Person p1 = new Person(1, "Kamil", "Kowalski","37320937432");
        repository.Add(p1);
        repository.GetById(1);
        repository.GetAll();
        repository.Remove(1);
        repository.GetAll();
    }
}
