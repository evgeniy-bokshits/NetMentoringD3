using System;
using System.Linq;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// 1.	Write a program, which creates an array of 100 Tasks, 
    /// runs them and wait all of them are not finished. 
    /// Each Task should iterate from 1 to 1000 and print into the console the following string:
    /// “Task #0 – {iteration number}”.
    /// </summary>
    class Task1
    {
        public void Execute()
        {
            var startTime = DateTime.Now;
            var tasksArrange = Enumerable.Range(1, 100).Select(i =>
                Task.Factory.StartNew(() => {
                        Iterate(i);
                    }
                )).ToArray();
            Task.WaitAll(tasksArrange);
            var timeDefference = DateTime.Now - startTime;
            Console.WriteLine($"Finish: {(int) timeDefference.TotalMilliseconds} ms");
        }

        private void Iterate(int numberTask)
        {
            for (int iteration = 1; iteration <= 1000; iteration++)
            {
                Console.WriteLine($"Task #{numberTask} – {iteration}");
            }
        }
    }
}
