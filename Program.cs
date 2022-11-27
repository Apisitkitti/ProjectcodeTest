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
    Teacher
}
enum StudentMenu
{
    
    Reserve = 1,
    Check,
    TLoguot
}
enum TeacherMenu
{
    Accept = 1,
    Check,
    TLoguot
}
 class Program
{
    static ListData data;
   
    public static void Main()
    {
        PersonListLoad();
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
        Console.WriteLine("1.Student\n2.Teacher");
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
            Console.WriteLine("This user already register");
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
            Console.WriteLine("This user already register");
            Console.ReadLine();
            NewTeacher();
        }  

    }
    //จบ regisster
    
    //Login
    static void LoginFromKeyboard()
    {
        Console.Clear();
        Console.WriteLine("");
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
            Console.WriteLine("  Invalid Email/Password");
            Console.WriteLine("    Please login again");
            Console.WriteLine("--------------------------");
            PressToContinue();
        }
        
        //ส่วนMenuLoginนักศึกษา
        static void StudentReserve(string id , string password)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("                Welcome.               ");
            Console.WriteLine("---------------------------------------");
            data.WHoisthat(id,password);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Choose Menu\n1.Reserve room\n2.Check Student\n3.Logout");
            Console.WriteLine("---------------------------------------");
            Console.Write("please choose your Menu : ");
            StudentMenu menu = (StudentMenu)(int.Parse(Console.ReadLine()));
            SwitchStudentMenu(menu);

        }
        static void SwitchStudentMenu(StudentMenu menu)
        {
            switch(menu)
            {
               case StudentMenu.Reserve:Reserve();
               break; 
               case StudentMenu.Check:Display_tudent_CheckList();
               break;
               case StudentMenu.TLoguot:BackToMainMemu();
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
            Console.WriteLine("Choose Menu\n1.Accept room\n2.Check Student\n3.Logout");
            Console.WriteLine("---------------------------------------");
            Console.Write("please choose your Menu : ");
            TeacherMenu menu = (TeacherMenu)(int.Parse(Console.ReadLine()));
            SwitchTeacherMenu(menu);

        }
        static void SwitchTeacherMenu(TeacherMenu menu)
        {
            switch(menu)
            {
               case TeacherMenu.Accept:AdminConfirm();
               break; 
               case TeacherMenu.Check:Display_tudent_CheckList();
               break;
               case TeacherMenu.TLoguot:BackToMainMemu();
               break;
            }
        } 
        static void Display_tudent_CheckList()
        {
            data.FetchData();
        }  
        static void AdminConfirm()
        {
            Console.WriteLine("Commingsoon");
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
    public static string InputRole()
    {
        Console.Write("please input your role : ");
        return Console.ReadLine();
    }
    public static string InputCitizenId()
    {
        Console.Write("please input yor CitizenID : ");
        return Console.ReadLine();
    }
    public static string Password()
    {
      Console.Write("please input your Password: ");
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
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("                 Room.                 ");
        Console.WriteLine("---------------------------------------");
        PressToContinue();
        }

    //ส่วนจอง
        static void Reserve()
        {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("             comming soon              ");
        Console.WriteLine("---------------------------------------");
        PressToContinue();
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