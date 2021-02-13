using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Scheduling
{
    class Scheduling
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToBeKilled = int.Parse(Console.ReadLine());
            int threadKiller = 0;
            while (tasks.Count != 0 && threads.Count != 0)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (thread >= task)
                {
                    tasks.Pop();
                }
                if (task == taskToBeKilled)
                {
                    threadKiller = thread;
                    break;
                }
                threads.Dequeue();
            }
            Console.WriteLine($"Thread with value {threadKiller} killed task {taskToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
