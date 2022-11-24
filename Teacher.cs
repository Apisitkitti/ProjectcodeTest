using System;
class Teacher:Person
{
   
    string citizen_id;
    public Teacher(string name,string surname,string citizen_id,string password)
    :base(name,surname,password)
    {
       
       this.citizen_id = citizen_id; 
       
    }

    public string GetId()
    {
        return this.citizen_id;
    }   
}