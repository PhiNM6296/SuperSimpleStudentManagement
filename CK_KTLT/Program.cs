using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CK_KTLT
{
    internal class Program
    {
        static Dictionary<int, Student> listDictionary = new Dictionary<int, Student>();
        // Ham main
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("| STUDENTS MANAGEMENT SYSTEM |");
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("|1. Them sinh vien           |");
                Console.WriteLine("|2. Cap nhat thong tin       |");
                Console.WriteLine("|3. Xem danh sach sinh vien  |");
                Console.WriteLine("|4. Sap xep sv theo lop      |");
                Console.WriteLine("|5. Tim kiem sv              |");
                Console.WriteLine("|6. Exit                     |");
                Console.WriteLine("+----------------------------+");
                Console.Write("Lua chon cua ban: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Ban muon nhap tu ban phim hay lay du lieu tu file?");
                        Console.WriteLine("1. Nhap tu ban phim\n2. Nhap du lieu tu file input\n");
                        Console.Write("Lua chon cua ban: ");
                        int n = int.Parse(Console.ReadLine());
                        if (n==1) 
                        {
                            InsertStudent();
                        }
                        if (n==2)
                        {     
                        readList();
                        ViewList();
                        }

                        break;
                    case 2:
                        Update();
                        ViewList();
                        break;
                    case 3:
                        ViewList();
                        Console.WriteLine("\nBan co muon xuat dan sach ra file");
                        Console.Write("Lua chon cua ban: ");
                        Console.WriteLine("1. Co\n2. Khong\n");
                        int y = int.Parse(Console.ReadLine());
                        if (y == 1) printList();
                        if (y == 2) break;
                        break;
                    case 4:
                        ClassSearch();
                        break;
                    case 5:
                        Search();
                        break;
                    case 6:
                        return;
                        
                }
            }
        }
        // ham tim kiem sinh vien
        private static void Search()
        {
            Console.WriteLine("Ban muon tim kiem theo: ");
            Console.WriteLine("1. Ho ten\n2. MSSV\n3. Lop");
            Console.Write("Lua chon cua ban: ");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                bool found = false;
                Console.Write("Nhap ho ten sv: ");
                String search = Console.ReadLine();
                Console.WriteLine("Ket qua tim kiem cho sinh vien co ho ten: " + search);
                foreach (Student student in listDictionary.Values)
                {
                    if (student.FullName.Equals(search))
                    //if (String.Compare(student.Class, search, true) == 0)
                    {
                        Console.WriteLine("----------------------------");
                        student.Display();
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Khong tim thay sinh vien nao");

                }
            }
            if (n == 2)
            {
                bool found = false;
                Console.Write("Nhap MSSV muon tim: ");
                int search = int.Parse(Console.ReadLine());
                Console.WriteLine("Ket qua tim kiem cho sinh vien co MSSV: " + search);
                foreach (Student student in listDictionary.Values)
                {
                    if (student.MSSV.Equals(search))
                    //if (String.Compare(student.Class, search, true) == 0)
                    {
                        Console.WriteLine("----------------------------");
                        student.Display();
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Khong tim thay sinh vien nao");

                }
            }
            if (n == 3)
            {
                bool found = false;
                Console.Write("Nhap lop muon tim: ");
                String search = Console.ReadLine();
                Console.WriteLine("Ket qua tim kiem cho lop: " + search);
                foreach (Student student in listDictionary.Values)
                {
                    if (student.Class.Equals(search))
                    //if (String.Compare(student.Class, search, true) == 0)
                    {
                        Console.WriteLine("----------------------------");
                        student.Display();
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Khong tim thay sinh vien nao");
                }
            }
        }
        // ham cap nhat/xoa thong tin sinh vien
        private static void Update()
        {
            Console.WriteLine("Tim sinh vien ban muon xoa/cap nhat thong tin theo MSSV");
            Console.Write("Nhap MSSV muon tim: ");
            int search = int.Parse(Console.ReadLine());
            Console.WriteLine("Ket qua tim kiem cho sinh vien co MSSV: " + search);
            bool found = false;
            int n = 0;
            foreach (Student student in listDictionary.Values)
            {
                if (student.MSSV.Equals(search))
                //if (String.Compare(student.Class, search, true) == 0)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Sinh vien voi MSSV da nhap duoc tim thay:");
                    student.Display();
                    n = student.ID;
                    found = true;
                }
            }
                if (found)
                {
                    Console.WriteLine("Ban muon lam gi: ");
                    Console.WriteLine("1. Xoa thong tin sinh vien\n2. Cap nhat thong tin sinh vien");
                    Console.Write("Lua chon cua ban: ");
                    int k = int.Parse(Console.ReadLine());
                    if (k == 1)
                    {
                        listDictionary.Remove(n);
                        Console.WriteLine("Da xoa sinh vien voi mssv da chon\n");
                    }
                    if (k == 2)
                    {
                    Student student = new Student();
                    Console.Write("Nhap ho ten: ");
                    student.FullName = Console.ReadLine();

                    //Input date
                    while (true)
                    {
                        Console.Write("Nhap ngay sinh (thang/ngay/nam): ");
                        DateTime dDate;
                        try
                        {
                            student.DateofBirth = DateTime.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Khong dung dinh dang thang/ngay/nam");
                            Console.WriteLine(ex.Message);
                        }
                    }

                    //Input Native
                    Console.Write("Nhap ten vien: ");
                    student.School = Console.ReadLine();

                    //Input Class
                    Console.Write("Nhap ten lop: ");
                    student.Class = Console.ReadLine();


                    //Input Mobile
                    while (true)
                    {
                        Console.Write("Nhap MSSV: ");
                        try
                        {
                            student.MSSV = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Khong dung dinh dang");
                            Console.WriteLine(ex.Message);
                        }
                    }
                    listDictionary.Remove(n);
                    listDictionary.Add(n, student);
                    Console.WriteLine("Da cap nhat thong tin sinh vien so {0}\n", n);
                    ViewList();

                }    
                }
                if(!found)
                {
                    Console.WriteLine("Khong tim thay sinh vien voi MSSV da nhap\n");

                }


        }

        // ham sap xep sinh vien theo lop
        private static void ClassSearch()


        {
              
                List <string> classes = new List<string>();
                foreach (Student student in listDictionary.Values)
            {

                string n = student.Class;
                if(!classes.Contains(n)==true)
                    classes.Add(n);
            }    
                foreach(var s in classes)
            {     
                Console.WriteLine("Nhung lop trong danh sach da nhap: " + s);
            }

                foreach(string s in classes)
            {     
                Console.WriteLine("\nDanh sach sinh vien cua lop" + s);
                foreach (Student student in listDictionary.Values)
                {

                    if (student.Class.Equals(s))
                    //if (String.Compare(student.Class, search, true) == 0)
                    {
                        Console.WriteLine("----------------------------");
                        student.Display();
                        
                    }
                }
            }
        }


        // ham hien thi danh sach thong tin sinh vien
        private static void ViewList()
        {
           
            Console.WriteLine("Tong so luong sinh vien: "+listDictionary.Count);
 
            if (listDictionary.Count == 0)
            {
                Console.WriteLine("Danh sach trong");
            }
            else
            {
                Console.WriteLine("Danh sach thong tin sinh vien:");
                foreach (Student student in listDictionary.Values)
                {
                    Console.WriteLine("----------------------------");
                    student.Display();
                }
                
            }

        }
        // ham nhap thong tin sinh vien thong qua ban phim
            private static void InsertStudent()
            {

                Student student = new Student();

                //Increament ID
                student.ID = listDictionary.Count + 1;

                //Input name
                Console.Write("Nhap ho ten: ");
                student.FullName = Console.ReadLine();

                //Input date
                while (true)
                {
                    Console.Write("Nhap ngay sinh (thang/ngay/nam): ");
                    DateTime dDate;
                    try
                    {
                        student.DateofBirth = DateTime.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Khong dung dinh dang thang/ngay/nam");
                        Console.WriteLine(ex.Message);
                    }
                }

                //Input School
                Console.Write("Nhap ten vien: ");
                student.School = Console.ReadLine();

                //Input Class
                Console.Write("Nhap ten lop: ");
                student.Class = Console.ReadLine();


                //Input MSSV
                while (true)
                {
                    Console.Write("Nhap MSSV: ");
                    try
                    {
                        student.MSSV = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Khong dung dinh dang");
                        Console.WriteLine(ex.Message);
                    }
                }

                listDictionary.Add(student.ID, student);
                Console.WriteLine("Da them sinh vien so {0}\n", student.ID);
            }
        
        // ham xuat du lieu ra file
        private static void printList()
        {
 
                foreach (Student student in listDictionary.Values)
                {
                student.Printfile();
                }                    
        
                        Console.WriteLine("Da xuat du lieu ra file");

        }
        // ham doc du lieu tu file
        private static void readList()
        {
            
            string[] yourFile = System.IO.File.ReadAllLines(@"D:\Admin-DL\VisualStudio_codeCsharp\CK_KTLT\input.txt");

        List<Student> students = new List<Student>();

        foreach(string s in yourFile)
        {
            Student student = new Student();
            student.ID = listDictionary.Count + 1;

            string[] dividedLines = s.Split('|');
            foreach(string line in dividedLines)
            {                    
                string[] data = line.Split(':');
                switch(data[0])
                {
                    case "Name":
                    student.FullName = data[1];
                    break;
                    case "DB":
                    student.DateofBirth = DateTime.Parse(data[1]);
                    break;
                    case "School":
                    student.School= data[1];
                    break;
                    case "Class":
                    student.Class = data[1];
                    break;
                    case "ID":
                    student.MSSV = int.Parse(data[1]);
                    break;
                }
            }
            listDictionary.Add(student.ID, student);
            

        }
        Console.WriteLine("Da nhap du lieu tu file");
     
 
        }

        }
    }

