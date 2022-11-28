using System;


class RoomSure
{
    string name;
    string surname;
    string id;
    string roomNum;
    int amount;

    public RoomSure(string name,string surname,string id, string roomNum,int amount)
    {
        this.name = name;
        this.surname = surname;
        this.id = id;
        this.roomNum = roomNum;
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
    public string GetID()
    {
        return this.id;
    }
    

}