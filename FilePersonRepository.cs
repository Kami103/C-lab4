using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConsoleApp4;

public class FilePersonRepository:IPersonRepository

{
    private List<Person> list = new List<Person>();
    

    public void readDB()
    {
        using (var sr = new StreamReader("personDB.json"))
        {
            var json = sr.ReadToEnd();
            list = JsonConvert.DeserializeObject<List<Person>>(json);
        }
    }
    private void saveDC()
    {
        String json = JsonSerializer.Serialize(list);
        Console.WriteLine(json);
        using (var sr = new StreamWriter("personDB.json"))
        {
            sr.WriteLine(json);
            //sr.WriteLine(JsonSerializer.Serialize<List<Person>>(list));
            
        }
    }
    public List<Person> GetAll()
    {
        readDB();
        return list;
    }

    public Person GetById(int id)
    {
        readDB();
        foreach (Person person in list)
        {
            if (person.Id == id)
            {
                return person;
            }
        }
        return null;
    }

    public void Add(Person personToAdd)
    {
        list.Add(personToAdd);
        saveDC();
    }

    

    public void Update(Person personToUpdate)
    {
        //??????????
    }

    public void Remove(int id)
    {
        readDB();
        foreach (Person person in list)
        {
            if (person.Id == id)
            {
                list.Remove(person);
            }
        }
        saveDC();
    }

    public int CountPersonOverYrs(int yearsFromCount)
    {
        readDB();
        int ilosc=0;
        foreach (Person person in list)
        {
            int year = Convert.ToInt32(person.Pesel.Substring(0, 2));
            int month = Convert.ToInt32(person.Pesel.Substring(2, 2));
            if (month <= 12 && month >= 01)
            {
                year += 1900;
            } 
            else if (month <= 32 && month >= 21)
            {
                year += 2000;
                month -= 20;
            }
            else
            {
                Console.WriteLine("BLEDNY ROK");
                return -1;
            }

            if (year == yearsFromCount)
            {
                ilosc++;
            }
        }

        return ilosc;
    }
}