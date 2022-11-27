using System;
//ส่วนMenu
enum MainMenu
{
    Register = 1,
    Login
}
enum RegisterMenu
{
    Student = 1,
    Teacher
}
enum TeacherMenu
{
    Accept = 1,
    Check
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
        Console.WriteLine("1.Register\n2.Login\n3.Check ReserveRoom");
        ChooseMenuFromKeyboard();
    } 
    static void ChooseMenuFromKeyboard()
    {
        Console.Write("Pls choose your Menu : ");
       MainMenu menu = (MainMenu)(int.Parse(Console.ReadLine()));
       DisplayMenu(menu);
    }
    //registermenu   
     static void ChooseRegisterMenu()
    {
        Console.WriteLine("1.Student\n2.Teacher");
        ChooseRegisterMenuFromKeyboard();
    }
    
     static void ChooseRegisterMenuFromKeyboard()
    {
        Console.Write("Pls choose your Menu : ");
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
            Console.WriteLine("This user already register");
            NewTeacher();
        }  

    }
    //จบ regisster
    
    //Login
    static void LoginFromKeyboard()
    {
       
        Console.Write("ID: ");
        string ID = Console.ReadLine();
        Console.Write("Password: ");
        string Password = Console.ReadLine();
        if(data.LoginCheck(ID,Password) == true)
        {
            if(data.Adminchecker() == true )
            {
                TeacherAccept(ID,Password);
            }
            else if(data.Adminchecker() == false)
            {
                StudentReserve(ID,Password);
            }
        }
        else if(data.LoginCheck(ID,Password) == false)
        {
            Console.Clear();
            Console.WriteLine("Invalid Email/Password");

            LoginFromKeyboard();
        }
        //ส่วนMenuLoginนักศึกษา
        static void StudentReserve(string id , string password)
        {
            Console.Clear();
            Console.WriteLine("Welcome");
            data.WHoisthat(id,password);
        }
        
        //ส่วนMenuloginอาจารย์
        static void TeacherAccept(string id , string password)
        {
            Console.Clear();
            Console.WriteLine("Welcome");
            data.WHoisthat(id,password);
            Console.WriteLine("Choose Menu\n1. Accept room\n2. Check Student");
            Console.Write("Choose: ");
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
        Console.Write("Pls input your name : ");
        return Console.ReadLine();
    }
    public static string InputSurname()
    {
        Console.Write("Pls input your Surname : ");
        return Console.ReadLine();
    }
    public static string InputID()
    {
        Console.Write("Pls input your ID : ");
        return Console.ReadLine();
    }
    public static string InputClass_Year()
    {
        Console.Write("Pls Input class year : ");
        return Console.ReadLine();
    }
    public static string InputRole()
    {
        Console.Write("Pls input your role : ");
        return Console.ReadLine();
    }
    public static string InputCitizenId()
    {
        Console.Write("Pls input yor CitizenID : ");
        return Console.ReadLine();
    }
    public static string Password()
    {
      Console.Write("Pls input your Password: ");
      return Console.ReadLine();
    }
    //เตรียมตัวเพื่อโหลดข้อมูล่วงหน้าจะได้ไม่บึ้ม
    static void PersonListLoad()
    {
        Program.data = new ListData();
    }   
}