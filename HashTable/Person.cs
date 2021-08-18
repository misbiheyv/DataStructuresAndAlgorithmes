public class Person
{
    public string Name { get; set; }
    
    public int Age { get; set; }

    public char Sex { get; set; }

    public Person(string name, int age, char sex)
    {
        Name = name;
        Age = age;
        Sex = sex;
    }

    public override string ToString()
    {
        return Name;
    }
}