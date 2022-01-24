using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new TaskManager();
            while (true)
            {
                var str = Console.ReadLine();
                var comand =  str.Split(' ');

                if (comand[0].ToLower() == "printall")
                    obj.PrintAllTasks();

                else if (comand[0].ToLower() == "findtask")
                    obj.FindTask(comand[1]);

                else if (comand[0].ToLower() == "killbyid")
                {
                    try
                    {
                        obj.KillTaskById(Convert.ToInt32(comand[1]));
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nID is incorrect\n");
                        Console.ResetColor();
                    }
                } 

                else if (comand[0].ToLower() == "killbyname")
                    obj.KillTaskByName(comand[1]);

                else if (comand[0] == "exit")
                    Process.GetCurrentProcess().Kill();

                else if (comand[0] == "help")
                    obj.PrintAllComands();

                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPrint 'help' to see all commands\n");
                    Console.ResetColor();
                }
                    
            }
        }
    }
}
