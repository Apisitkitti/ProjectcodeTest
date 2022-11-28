using System;
class Reserve:Room
{
   string name;
   string surname;
    public Reserve(string name,string surname,string room, int  amount)
    :base(room,amount)
    {
        this.name = name;
        this.surname = surname;
    }
    public string GetName()
    {
        return this.name;
    }
    public string GetSurname()
    {
        return this.surname;
    }
   
}