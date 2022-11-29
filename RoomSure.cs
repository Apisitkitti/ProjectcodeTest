using System;


class RoomSure
{
    string name;
    string surname;
    string roomname;
    int amount;

    public RoomSure(string name,string surname,string roomname,int amount)
    {
        this.name = name;
        this.surname = surname;
        this.roomname = roomname;
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
    public string GetRoomname()
    {
        return this.roomname;
    }
    public int GetAmount()
    {
        return this.amount;
    }
    

}