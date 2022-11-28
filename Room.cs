using System;
class Room
{
    string name;
    int amount;
    public Room(string name,int amount )
    {
        this.name = name;
        this.amount = amount;
    }
   
    public int GetAmount()
    {
        return this.amount;
    }
    public string GetName()
    {
        return this.name;
    }

    

}