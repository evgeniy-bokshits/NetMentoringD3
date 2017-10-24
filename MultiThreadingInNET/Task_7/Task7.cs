using System;
using System.Threading.Tasks;

namespace Task_7
{

    class Task7
    {
        public void Execute()
        {
            var parentTask = new Task(
                () =>
                {
                    ParentTask();
                });

            parentTask.ContinueWith(t =>
                {
                    Console.WriteLine("Working a) always task");
                })
                .ContinueWith(t => Console.WriteLine("working b) without success task"),
                    TaskContinuationOptions.OnlyOnFaulted)
                .ContinueWith(t => Console.WriteLine("working d) task would be cancelled"),
                    TaskContinuationOptions.OnlyOnCanceled)
                .ContinueWith(
                    t => Console.WriteLine(
                        "working c) parent task would be finished with fail and parent task thread should be reused for continuation"),
                    TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.RunContinuationsAsynchronously);
            parentTask.Start();

        }

        private void ParentTask()
        {
            Console.WriteLine("Working parent task");
        }

    }
}