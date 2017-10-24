using System;
using System.Threading;

namespace Task_5
{
    /// <summary>
    /// 5.	Write a program which recursively creates 10 threads. 
    /// Each thread should be with the same body and receive a threadState with integer number, 
    /// decrement it, print and pass as a threadState into the newly created thread. 
    /// Use ThreadPool class for this task and Semaphore for waiting threads.
    /// </summary>
    class Task5
    {
        int threadState = 15;
        static Semaphore sem = new Semaphore(1, 1);
        public void Execute()
        {
            Recursia(10);
        }

        private int Recursia(int i)
        {
            if (i == 0)
            {
                return 0;
            }
            i -= 1;
            ThreadPool.QueueUserWorkItem(CountDown);
            Recursia(i);
            return i;
        }

        private void CountDown(object obj)
        {
            sem.WaitOne();
            threadState -= 1;
            sem.Release();
            Console.WriteLine(threadState);
        }
    }
}
