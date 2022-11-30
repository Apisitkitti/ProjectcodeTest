using System;
//ส่วนMenu
enum MainMenu
{
    Register = 1,
    Login,
    CheckRoomm
}
enum RegisterMenu
{
    Student = 1,
    Teacher,
    Back
}
enum StudentMenu
{
    Reserve = 1,
    CheckRoomm,
    TLoguot
}
enum TeacherMenu
{
    Accept = 1,
    CheckRoomm,
    Check,
    TLoguot
}
 class Program
{
    static ListData data; 
    public static void Main()
    {
        PersonListLoad();
        Room(); 
        ChooseMenu();
    }
    //Menu ตัวเลือก login หรือ register
    static void ChooseMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Welcome to the room reservation system.");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("1.Register\n2.Login\n3.Check ReserveRoom");
        Console.WriteLine("---------------------------------------");
        ChooseMenuFromKeyboard();
    } 
    static void ChooseMenuFromKeyboard()
    {
       Console.Write("please choose your Menu : ");
       MainMenu menu = (MainMenu)(int.Parse(Console.ReadLine()));
       DisplayMenu(menu);
    }
    //registermenu   
     static void ChooseRegisterMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.WriteLine("         Register.        ");
        Console.WriteLine("--------------------------");
        Console.WriteLine("1.Student\n2.Teacher\n3.Back");
        Console.WriteLine("--------------------------");
        ChooseRegisterMenuFromKeyboard();
    }
    
     static void ChooseRegisterMenuFromKeyboard()
    {
        Console.Write("please choose your Menu : ");
       RegisterMenu menu = (RegisterMenu)(int.Parse(Console.ReadLine()));
       DisplayRegisterMenu(menu);
    }
    static void DisplayMenu(MainMenu menu)
    {
        switch(menu)
        {
            case MainMenu.Register: ChooseRegisterMenu();
            break;
            case MainMenu.Login: LoginFromKeyboard();
            break;
            case MainMenu.CheckRoomm: CheckReserveRoom();
            break;
        }
    }
   
    static void DisplayRegisterMenu(RegisterMenu menu)
    {
        switch(menu)
        {
            case RegisterMenu.Student: NewStudent();
            break;
            case RegisterMenu.Teacher: NewTeacher();
            break;
            case RegisterMenu.Back: BackToMainMemu();
            break;
        }
    }
    static void NewStudent()
    {
        Console.Clear();
        string name = InputName();
        string surname = InputSurname();
        Student student = new Student(name,surname,InputID(),InputClass_Year(),Password());
        
        bool checkdata = data.CheckRegis(name,surname);
        if(checkdata == true)
        {
            Program.data.PeopleAdd(student);
            ChooseMenu();
        }
        else if(checkdata == false)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("This user already register!!");
            Console.WriteLine("----------------------------");
            Console.ReadLine();
            NewStudent();
        }
     }
        
    static void NewTeacher()
     {
        Console.Clear();
        string name = InputName();
        string surname = InputSurname();
        Teacher teacher = new Teacher(name,surname,InputCitizenId(),Password());
        bool checkdata = data.CheckRegis(name,surname);
        if(checkdata == true)
        {
         Program.data.PeopleAdd(teacher);
        ChooseMenu();
        }
        else if(checkdata == false)
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("This user already register!!");
            Console.WriteLine("----------------------------");
            Console.ReadLine();
            NewTeacher();
        }  

    }
    //จบ regisster
    
    //Login
    static void LoginFromKeyboard()
    {
        Console.Clear();
        Console.WriteLine("--------------------------");
        Console.WriteLine("           Login.         ");
        Console.WriteLine("--------------------------");
        Console.Write("ID: ");
        string ID = Console.ReadLine();
        Console.Write("Password: ");
        string Password = Console.ReadLine();
        if(data.LoginCheck(ID,Password) == true)
        {
            if(data.Adminchecker(ID,Password) == true )
            {
                TeacherAccept(ID,Password);
            }
            else if(data.Adminchecker(ID,Password) == false)
            {
                StudentReserve(ID,Password);
            }
        }
         else if(data.LoginCheck(ID,Password) == false)
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("  Invalid ID/Password");
            Console.WriteLine("   !Please login again!");
            Console.WriteLine("--------------------------");
            PressToContinue();
        }
        
        //ส่วนMenuLoginนักศึกษาาาาาาาาาาาาาาาาาาาาาาาาาาาาาาาา
        static void StudentReserve(string id , string password)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("                Welcome.               ");
            Console.WriteLine("---------------------------------------");
            data.WHoisthat(id,password);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Choose Menu\n1.Reserve room\n2.Check ReserveRoom\n3.Logout");
            Console.WriteLine("---------------------------------------");
            Console.Write("please choose your Menu : ");
            StudentMenu menu = (StudentMenu)(int.Parse(Console.ReadLine()));
            SwitchStudentMenu(menu);

        }
        static void SwitchStudentMenu(StudentMenu menu)
        {
            switch(menu)
            {
               case StudentMenu.Reserve: Reserve();
               break; 
               case StudentMenu.CheckRoomm: CheckReserveRoom();
               break;
               case StudentMenu.TLoguot: BackToMainMemu();
               break;
            }
        } 
    
        //ส่วนMenuloginอาจารย์
        static void TeacherAccept(string id , string password)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("                Welcome.               ");
            Console.WriteLine("---------------------------------------");
            data.WHoisthat(id,password);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Choose Menu\n1.Accept room\n2.Check ReserveRoom\n3.Check Student\n4.Logout");
            Console.WriteLine("---------------------------------------");
            Console.Write("please choose your Menu : ");
            TeacherMenu menu = (TeacherMenu)(int.Parse(Console.ReadLine()));
            SwitchTeacherMenu(menu);

        }
        static void SwitchTeacherMenu(TeacherMenu menu)
        {
            switch(menu)
            {
               case TeacherMenu.Accept: AdminConfirm();
               break; 
               case TeacherMenu.CheckRoomm: CheckReserveRoom();
               break;
               case TeacherMenu.Check: Display_Student_CheckList();
               break;
               case TeacherMenu.TLoguot: BackToMainMemu();
               break;
            }
        } 
        static void Display_Student_CheckList()
        {
            Console.Clear();
            data.FetchData();
            Console.WriteLine("");
            PressToContinue();
        }  
        static void AdminConfirm()
        {
           Console.Clear();
           if(data.CheckDelete()== false)
           {
            Console.WriteLine("You dont have any reserve room!!");
            Console.ReadLine();
            BackToMainMemu();
           }
           else if(data.CheckDelete()== true)
           {
             data.ReserveRoom();
             Console.WriteLine("--------------------------------------");
             Console.Write("please Choose Info to reject room (Input -1 to for back to main menu ) : ");
            int choose = InputChoice();
            if(choose == -1)
            {
                 BackToMainMemu();
            }
            else
            {
              data.RoomDete(choose-1);
              PressToContinue();
            }

           }
        }
    }
    //ส่วนการจะใช้กกรอกข้อมูล
    public static string InputName()
    {
        Console.Write("please input your name : ");
        return Console.ReadLine();
    }
    public static string InputSurname()
    {
        Console.Write("please input your Surname : ");
        return Console.ReadLine();
    }
    public static string InputID()
    {
        Console.Write("please input your ID : ");
        return Console.ReadLine();
    }
    public static string InputClass_Year()
    {
        Console.Write("please Input class year : ");
        return Console.ReadLine();
    }
    public static string InputCitizenId()
    {
        Console.Write("please input yor CitizenID : ");
        return Console.ReadLine();
    }
    public static string Password()
    {
      Console.Write("please input your Password : ");
      return Console.ReadLine();
    }
    public static int InputAmount()
    {
        Console.Write("please input amount of your student : ");
        return int.Parse(Console.ReadLine());
    }
    public static int InputChoice()
    {
        return int.Parse(Console.ReadLine());
    }
    public static string InputActivity()
    {
        Console.Write("please input your activity to do in this room : ");
        return Console.ReadLine();
    }
    
    //เตรียมตัวเพื่อโหลดข้อมูล่วงหน้าจะได้ไม่บึ้ม
    static void PersonListLoad()
    {
        Program.data = new ListData();
    }
    //ส่วนเช็คห้อง
        static void CheckReserveRoom()
        {
        Console.Clear();

        Program.data.ReserveRoom();
        Console.WriteLine("");
        PressToContinue();
        }

    //ส่วนจอง
        static void Reserve()
        {
        Console.Clear();
        Console.WriteLine("--------------------------------");
        Console.WriteLine("            Room List           ");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1.room 403 | Max size 30 people\n2.room 604 | Max size 40 people\n3.Gym      | Max size 150 people\n4.Theater  | Max size 100 people");
        Console.WriteLine("--------------------------------");
        Console.Write("please choose your room : ");
        int roomNum = int.Parse(Console.ReadLine());
        Console.WriteLine("--------------------------------");
            if(roomNum == 1)
            {
                string name = InputName();
                string surname = InputSurname(); 
                string Roomname = "403" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
            else if(roomNum == 2)
            {
                string name = InputName();
                string surname = InputSurname();
                string Roomname = "604" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
            else if(roomNum == 3)
            {
                string name = InputName();
                string surname = InputSurname();
                string Roomname = "Gym" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);   
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
            else if(roomNum == 4)
            {
                string name = InputName();
                string surname = InputSurname();
                string Roomname = "Theater" ;
                int amount = InputAmount();
                string activity = InputActivity();
                Reserve reserve = new Reserve(name,surname,Roomname,amount,activity);   
                AddRoom(ref Roomname,ref amount,ref name,ref surname, ref reserve);
            }
        }
        //Methodaddlistเข้าห้อง
        public static void AddRoom(ref string Roomname,ref int amount,ref string name, ref string surname, ref Reserve reserve)
        {
            if(data.CheckRoomSUm(Roomname,name,surname) == true)
            {
                if(data.RoomAmountcheck(Roomname,amount)  == true)
                {
                    Program.data.RoomAdd(reserve);
                    ChooseMenu();
                 
                }
                else if(data.RoomAmountcheck(Roomname,amount)  == false)
                {
                     Console.Clear();
                    Console.WriteLine("Your student is more than room capacity!!");
                    Console.WriteLine("");
                    PressToContinue();
                }
                        
            }   
            else if(data.CheckRoomSUm(Roomname,name,surname) == false)
            {
                Console.Clear();
                Console.WriteLine("ํYou already reserve this room!!");
                Console.WriteLine("");
                PressToContinue();
            }
               
        }
        //ห้อง
        static void Room()
        {
            Room room1 = new Room("403",30);
            Room room2 = new Room("604",40);
            Room room3 = new Room("Gym",150);
            Room room4 = new Room("Theater",100);
            data.RoomInfoAdd(room1);
            data.RoomInfoAdd(room2);
            data.RoomInfoAdd(room3);
            data.RoomInfoAdd(room4);
        }
    
        
    //กลับสู่ main เมนู
        static void BackToMainMemu()
        {
            ChooseMenu();
        }
         static void PressToContinue()
        {
            Console.Write("Press enter to continue");
            string enter = Console.ReadLine();
            if (enter == "")
            {
                ChooseMenu();
            }
        }
}