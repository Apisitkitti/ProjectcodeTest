using System;
class Student:Person
{
    string id;
    string class_year;
    public Student(string name,string surname,string id,string class_year,string password)
    :base(name,surname,password)
    {
        this.id = id;
        this.class_year = class_year;
    }
    public string GetID()
    {
        return this.id;
    }
    public string GetClassYear()
    {
        return this.class_year;
    }
}