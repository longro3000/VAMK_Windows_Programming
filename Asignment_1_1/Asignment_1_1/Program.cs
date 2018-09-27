using System;

namespace Assignment_1_1
{
    public class Progarm
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int num = r.Next(1, 10);
            int[,] matrix1 = new int[num, num];
            int[,] matrix2 = new int[num, num];
            int[,] matrix3 = new int[num, num];

            Console.WriteLine("The content of matrix 1 :");
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = r.Next(100);
                    Console.Write("{0,5}", matrix1[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("The content of matrix 2 :");
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = r.Next(100);
                    Console.Write("{0,5}", matrix2[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("The addition matrix of 2 matrix :");
            for (int i = 0; i < matrix3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3.GetLength(1); j++)
                {
                    matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    Console.Write("{0,5}", matrix3[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("The subtraction matrix of 2 matrix :");
            for (int i = 0; i < matrix3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3.GetLength(1); j++)
                {
                    matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
                    Console.Write("{0,5}", matrix3[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("The multiplication matrix of 2 matrix :");
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        matrix3[i, j] += matrix1[i, j] * matrix2[i, j];
                        Console.Write("{0,7}", matrix3[i, j]);
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

