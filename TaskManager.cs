using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleApp1
{
    interface ITaskManager
    {
        public void PrintAllTasks();
        public void KillTaskByName(string TaskName);
        public void KillTaskById(int Id);
        public void FindTask(string Str);
    }
    class TaskManager : ITaskManager
    {
        public void FindTask(string Str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nAll Process with {Str}: ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                if (task_list[i].ProcessName.ToLower().IndexOf(Str.ToLower()) != -1)
                {
                    Console.WriteLine($"{task_list[i].Id,7} {task_list[i].ProcessName}");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public void KillTaskById(int Id)
        {
            var flag = false;

            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                if (task_list[i].Id == Id)
                {
                    task_list[i].Kill();
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProcess with Id: {Id} was successfully killed\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nProcess with Id: {Id} was not found\n");
            }
            Console.ResetColor();
        }

        public void KillTaskByName(string TaskName)
        {
            var flag = false;

            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                if (task_list[i].ProcessName == TaskName)
                {
                    task_list[i].Kill();
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nProcess {TaskName} was successfully killed\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nProcess {TaskName} was not found\n");
            }
            Console.ResetColor();
        }

        public void PrintAllTasks()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{"Process Name", -40} {"Process Id"}\n");
            Console.ResetColor();

            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                Console.WriteLine($"{task_list[i].ProcessName, -40} {task_list[i].Id}");
            }
            Console.WriteLine();   
        }
        public void PrintAllComands() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n'PrintAll'   – to see all processes");
            Console.WriteLine("'FindTask'   – to search a process by name");
            Console.WriteLine("'KillById'   – to kill a process by Id");
            Console.WriteLine("'KillByName' – to kill a process by Name");
            Console.WriteLine("'exit'       – to exit");
            Console.WriteLine("'help'       – to see all commands\n");
            Console.ResetColor();
        }
    }
}