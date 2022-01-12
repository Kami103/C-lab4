namespace ConsoleApp4;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; }

    public Person(int id, string firstName, string lastName, string pesel)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Pesel = pesel;
    }
}