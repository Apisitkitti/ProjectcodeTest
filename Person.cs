using System;
class Person
{
    string name;
    string surname;
    string password;
    
    public Person(string name, string surname,string password)
    {
        this.name = name;
        this.surname = surname;
        this.password = password;
    }
    public string GetName()
    {
        return this.name;
    }   
    public string GetSurname()
    {
        return this.surname;
    }
    public string GetPassword()
    {
        return this.password;
    }
}