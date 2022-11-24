using System;
class Room
{
    string size;
    int amount;
    bool reservation;
    public Room(string size,int amount,bool reservation )
    {
        this.size = size;
        this.amount = amount;
        this.reservation = reservation;
    }
    public string GetSize()
    {
        return this.size;
    }
    public int GetAmount()
    {
        return this.amount;
    }
    

}