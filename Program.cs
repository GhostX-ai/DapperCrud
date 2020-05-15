using System;
using DapperCrud.Models;

namespace DapperCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            DbActions db = new DbActions();
            int Id = 0;
            int chs = 0;
            while (true)
            {
                Console.WriteLine("Welcome To The Hell Hight Level");
                db.Select().ForEach(s =>
                {
                    Console.WriteLine($"Id = {s.Id}\nFullName = {s.FullName}\nAge = {s.Age}");
                });
                Console.Write("You can add one enter 1 or Select one enter 2:");
                chs = int.Parse(Console.ReadLine());
                if (chs == 1)
                {
                    Student st = new Student();
                    Console.Write("Enter FullName:");
                    st.FullName = Console.ReadLine();
                    Console.Write("Ener Age:");
                    st.Age = int.Parse(Console.ReadLine());
                    db.Add(st);
                }
                else if (chs == 2)
                {
                    Console.WriteLine("Select one from sight(I need just Id) enter 2:");
                    try
                    {
                        Id = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    Console.Write("What will you do?\nYou can delete this poor student or update his or her values(I know you are cruel and you are in dark side)\n1 for delete\n2 for update\n:");
                    try
                    {
                        chs = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Somethink went wrong please try again");
                        continue;
                    }
                    if (chs == 1)
                    {
                        db.Delete(Id);
                        Console.Clear();
                        Console.WriteLine("Congratulation my hopes were not rejected");
                        continue;
                    }
                    else if (chs == 2)
                    {
                        Student st = new Student();
                        st.Id = Id;
                        Console.WriteLine("You are so soft. ok Enter FullName:");
                        st.FullName = Console.ReadLine();
                        bool z = true;
                        while (z)
                        {
                            Console.WriteLine("Enter Age:");
                            try
                            {
                                st.Age = int.Parse(Console.ReadLine());
                                z = false;
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.Write("There was an error try it again!\n");
                                continue;
                            }
                        }
                        db.Update(st);
                        Console.Clear();
                    }
                }
            }
        }
    }
}
