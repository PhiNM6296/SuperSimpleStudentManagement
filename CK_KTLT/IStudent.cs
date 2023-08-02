using System;

namespace CK_KTLT
{
    interface IStudent
    {
        int ID
        {
            get;
            set;
        }

        string FullName
        {
            get;
            set;
        }

        DateTime DateofBirth
        {
            get;
            set;
        }

        string School
        {
            get;
            set;
        }

        string Class
        {
            get;
            set;
        }


        int MSSV
        {
            get;
            set;
        }

        void Display();
        void Printfile();
       
    }
}
