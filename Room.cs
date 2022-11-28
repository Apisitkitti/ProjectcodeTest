using System;
class Room
{
   
    string Roomname;
    int amount;
    public Room(string roomname,int amount )
    {
        
        this.Roomname = roomname;
        this.amount = amount;
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