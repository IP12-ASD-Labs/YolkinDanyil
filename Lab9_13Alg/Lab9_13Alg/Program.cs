using System;

namespace Lab9_13Alg
{
    class Program
    {
        static void Main(string[] args)
        {
            const int m = 4;
            const int n = 5;
            double[,] matrix = new double[m,n];

            GenerateMatrix(matrix, m, n);
            PrintMatrix(matrix, m, n);
            Solve(matrix, m, n);
            PrintMatrix(matrix, m, n);

        }
        static void GenerateMatrix(double[,] matrix, int rows, int columns)
        {
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.NextDouble() * 200 - 100;
                }
            }
        }

        // Функція для виведення матриці
        static void PrintMatrix(double[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
            }
            Console.WriteLine();
        }

        // Функція для обчислення максимального елементу та зміни його індекса
        static void Solve(double[,] matrix, int rows, int columns)
        {
            double max = 0;
            int rowIndex = 0;
            int columnIndex = 0;
            Console.WriteLine("===========================");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(matrix[i,j] >= max) // >= - для того, щоб воно знаходило не просто максимальний елемент, а останній максимальний
                    {
                        max = matrix[i, j];
                        rowIndex = i;
                        columnIndex = j;
                    }
                }
                Console.WriteLine($"Max element in {i + 1}th row is {max}. It is located in {rowIndex + 1}th row and {columnIndex + 1}th column");
                matrix[i, columnIndex] = matrix[i, columns - 1];
                matrix[i, columns - 1] = max;
                max = 0;
            }
            Console.WriteLine("===========================");

        }

    }
}
