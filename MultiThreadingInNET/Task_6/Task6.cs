using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task_6
{
    /// <summary>
    /// 6.	Write a program which creates two threads and a shared collection: 
    /// the first one should add 10 elements into the collection and the second 
    /// should print all elements in the collection after each adding. 
    /// Use Thread, ThreadPool or Task classes for thread creation and 
    /// any kind of synchronization constructions.
    /// </summary>
    class Task6
    {
        static Mutex sync = new Mutex();
        List<int> list = null;
        bool finished = false;
        public void Execute()
        {
            list = new List<int>();
            DateTime start = DateTime.Now;
            var taskPrintNewElement = Task.Factory.StartNew(PrintNewElement);
            var taskWorkWithCollection = Task.Factory.StartNew(WorkWithCollection);
            Task.WaitAll(taskWorkWithCollection, taskPrintNewElement);
            TimeSpan span = DateTime.Now - start;
            Console.WriteLine($"Finish: {(int)span.TotalMilliseconds} ms");
        }

        private void WorkWithCollection()
        {
            for (int i = 1; i <= 10; i++)
            {
                sync.WaitOne();
                list.Add(i);
                Console.WriteLine($"added {i} = ");
                sync.ReleaseMutex();
            }
            finished = true;
        }

        private void PrintNewElement()
        {
            while (!finished)
            {
                sync.WaitOne();
                foreach (var l in list)
                {
                    Console.WriteLine(l);
                }
                sync.ReleaseMutex();
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
