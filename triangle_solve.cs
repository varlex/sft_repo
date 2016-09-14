using System;
using System.Diagnostics;
using System.IO;

namespace euler_18
{
    class Program
    {
        static void Main(string[] args)
        {

            solveTheTriangle();
        }

        static void solveTheTriangle()
        {
            string pathToFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\simple_triangle.txt";
            int[,] inputTriangle = readFile(pathToFile);

            int posSolutions = (int)Math.Pow(2, inputTriangle.GetLength(0) - 1);
            int largestSum = 0;
            int tempSum, index;

            for (int i = 0; i <= posSolutions; i++)
            {
                tempSum = inputTriangle[0, 0];
                index = 0;
                for (int j = 0; j < inputTriangle.GetLength(0) - 1; j++)
                {
                    index = index + (i >> j & 1);
                    tempSum += inputTriangle[j + 1, index];
                }

                if (tempSum > largestSum)
                {
                    largestSum = tempSum;
                }
            }
            Console.WriteLine(largestSum);
        }

       static int[,] readFile(string filename)
        {
            string line;
            string[] linePieces;
            int lines = 0;

            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
            {
                lines++;
            }

            int[,] inputTriangle = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputTriangle[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }

            r.Close();

            return inputTriangle;
        }
    }
}
