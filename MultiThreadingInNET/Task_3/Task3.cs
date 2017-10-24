using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    /// <summary>
    /// 3.	Write a program, which multiplies two matrices and uses class Parallel. 
    /// </summary>
    class Task3
    {
        int m = 10;
        int n = 14;
        int q = 18;

        public void Execute()
        {
            int[,] A = new int[m, n];
            int[,] B = new int[n, q];

            InitializeMatrix(A);
            InitializeMatrix(B);
            Console.WriteLine("A:");
            PrintMatrix(A);
            Console.WriteLine("B");
            PrintMatrix(B);
            Console.WriteLine("A * B =");
            DateTime startTime = DateTime.Now;
            PrintMatrix(MultiplyMatrix(A, B));
            TimeSpan timeDefference = DateTime.Now - startTime;
            Console.WriteLine($"Finish: {(int) timeDefference.TotalMilliseconds} ms");
            
        }

        private void InitializeMatrix(int[,] array)
        {
            var rand = new Random(array.GetLength(0) + array.GetLength(1));
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(1, 100); ;
                }
            }
        }

        private int[,] MultiplyMatrix(int[,] a, int[,] b)
        {
            var resultMyltiply = new int[a.GetLength(0), b.GetLength(1)];
            Parallel.For(0, a.GetLength(0), i => {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        resultMyltiply[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
                      );
            return resultMyltiply;
        }

        private void PrintMatrix(int[,] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sb.Append(array[i, j]);
                    sb.Append(" ");
                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
