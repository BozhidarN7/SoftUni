using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProcessorScheduling
{
    class ProcessorScheduling
    {
        static void Main(string[] args)
        {
            int taskCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < taskCount; i++)
            {
                int[] taskTokens = Console.ReadLine().Split(new char[] { ' ','-'},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int value = taskTokens[0];
                int deadline = taskTokens[1];

                Task task = new Task(i + 1, value, deadline);
                tasks.Add(task);
            }

            tasks.Sort((x, y) => y.Value.CompareTo(x.Value));

            List<Task> executedTasks = new List<Task>();
            int maxDeadLine = tasks.Max(t => t.Deadline);
            foreach (var task in tasks)
            {
                executedTasks.Add(task);
            }

            executedTasks = executedTasks.Take(maxDeadLine).ToList();
            executedTasks.Sort();

            int totalValue = 0;

            foreach (var task in executedTasks)
            {
                totalValue += task.Value;
            }

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", executedTasks)}");
            Console.WriteLine($"Total value: {totalValue}");
        }
    }

    class Task : IComparable<Task>
    {
        public int TaskNumber { get; set; }   
        public int Value{ get; set; }
        public int Deadline { get; set; }

        public Task(int TaskNumber, int value, int deadline)
        {
            this.TaskNumber = TaskNumber;
            this.Value = value;
            this.Deadline = deadline;
        }

        public int CompareTo(Task other)
        {
            int compare = this.Deadline.CompareTo(other.Deadline);

            if (compare==0)
            {
                compare = other.Value.CompareTo(this.Value);
            }

            return compare;
        }

        public override string ToString()
        {
            return this.TaskNumber.ToString();
        }
    }
}
