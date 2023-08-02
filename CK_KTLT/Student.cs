using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CK_KTLT
{
    class Student : IStudent
    {
        string ClassName;
        public string Class
        {
            get
            {
                return ClassName;
            }

            set
            {
                ClassName = value;
            }
        }

        DateTime dateofBirth;
        public DateTime DateofBirth
        {
            get
            {
                return dateofBirth;
            }

            set
            {
                dateofBirth = value;
            }
        }

        string fullName;
        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        int id;
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        int mssv;
        public int MSSV
        {
            get
            {
                return mssv;
            }

            set
            {
                mssv = value;
            }
        }

        string school;
        public string School
        {
            get
            {
                return school;
            }

            set
            {
                school = value;
            }
        }

        public void Display()
        {
            Console.WriteLine("Ho ten: " + FullName);
            Console.WriteLine("Ngay sinh (ngay/thang/nam): " + DateofBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("Vien: " + School);
            Console.WriteLine("Lop: " + Class);
            Console.WriteLine("MSSV: " + MSSV);
        }
        public void  Printfile()
        {
            StreamWriter writer = new StreamWriter(@"D:\Admin-DL\VisualStudio_codeCsharp\CK_KTLT\data.txt", true);
            writer.WriteLine("----------------------------");
            writer.WriteLine("Ho ten: " + FullName);
            writer.WriteLine("Ngay sinh (thang/ngay/nam): " + DateofBirth.ToString("dd/MM/yyyy"));
            writer.WriteLine("Vien: " + School);
            writer.WriteLine("Lop: " + Class);
            writer.WriteLine("MSSV: " + MSSV);
            writer.Close(); 
        }
 

    }
}