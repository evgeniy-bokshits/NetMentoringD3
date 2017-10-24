﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    /// <summary>
    /// 2.	Write a program, which creates a chain of four Tasks. 
    /// First Task – creates an array of 10 random integer. 
    /// Second Task – multiplies this array with another random integer. 
    /// Third Task – sorts this array by ascending. 
    /// Fourth Task – calculates the average value. 
    /// All this tasks should print the values to console
    /// </summary>
    class Task2
    {
        int[] array = new int[10];
        public void Execute()
        {
            var firstTask = new Task(
                RunFirstTask);
            firstTask.ContinueWith((t) => RunSecondTask())
                .ContinueWith((t) => RunThirdTask())
                .ContinueWith((t) => RunFourthTask());
            firstTask.Start();
        }

        private void RunFirstTask()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                array[i] = rand.Next(1, 10000000);
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("-------------------------------------");
        }

        private void RunSecondTask()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                array[i] *= rand.Next(2, 15);
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("-------------------------------------");
        }

        private void RunThirdTask()
        {
            array = array.OrderBy(i => i).ToArray();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("-------------------------------------");
        }

        private void RunFourthTask()
        {
            Console.WriteLine(array.Average());
        }
    }
}
