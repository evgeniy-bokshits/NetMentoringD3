using System;
using System.Threading;

namespace Task_4
{
    /// <summary>
    /// 4.	Write a program which recursively creates 10 threads. 
    /// Each thread should be with the same body and receive a threadState with integer number, 
    /// decrement it, print and pass as a threadState into the newly created thread.
    /// Use Thread class for this task and Join for waiting threads.
    /// </summary>
    class Task4
    {
        int threadState = 15;
        public void Execute()
        {
            DateTime start = DateTime.Now;
            Recursia(10);
            TimeSpan timeDifference = DateTime.Now - start;
            Console.WriteLine($"Finish: {(int)timeDifference.TotalMilliseconds} ms");
        }

        private int Recursia(int i)
        {
            if (i == 0)
            {
                return 0;
            }
            i -= 1;
            var thread = new Thread(CountDown);
            thread.Start(threadState);
            thread.Join();
            Recursia(i);
            return i;
        }

        private void CountDown(object s)
        {
            var count = (int)s;
            threadState = count - 1;
            Console.WriteLine(threadState);
        }
    }
}
