using System;
class Room
{
    string name;
    string surname;
    string Roomname;
    int amount;
    public Room(string name,string surname,string roomname,int amount )
    {
        this.name = name;
        this.surname = surname;
        this.Roomname = roomname;
        this.amount = amount;
    }
   
   public string GetName()
    {
        return this.name;
    }   
    public string GetSurname()
    {
        return this.surname;
    }
    public int GetAmount()
    {
        return this.amount;
    }
    public string GetRoomname()
    {
        return this.Roomname;
    }

    

}