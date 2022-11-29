using System;
class Reserve:Room
{
   string name;
   string surname;
   string activity;
    public Reserve(string name,string surname,string room, int  amount, string activity)
    :base(room,amount)
    {
        this.name = name;
        this.surname = surname;
        this.activity = activity;
    }
    public string GetName()
    {
        return this.name;
    }
    public string GetSurname()
    {
        return this.surname;
    }
    public string GetActivity()
    {
        return this.activity;
    }
   
}