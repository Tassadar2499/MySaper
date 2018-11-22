using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    class MatrixMaker
    {
        public const int HIGH = 20;
        public const int WIDTH = 20;
        public static int[,] numMatrix;
        public static int countOfMines;
        public static void MakeMatrix()
        {
            var random = new Random();
            var high = 20;
            var width = 20;
            countOfMines = 0;
            numMatrix = new int[high, width];
            for (int i = 0; i < high; i++)  //заполним матрицу коэффицентами
                for (int j = 0; j < width; j++)
                {
                    numMatrix[i, j] = random.Next(0, 20);
                    if (numMatrix[i, j] > 16) //16
                        countOfMines++;
                }

            for (int i = 0; i < high; i++) //заполним матрицу условными минами
                for (int j = 0; j < width; j++)
                    numMatrix[i, j] = (numMatrix[i, j] > 16) ? -1 : 0;


            for (int i = 0; i < high; i++)
                for (int j = 0; j < width; j++)
                    if (numMatrix[i, j] == -1)
                    {
                        if (j - 1 > -1)
                            if (numMatrix[i, j - 1] != -1)
                                numMatrix[i, j - 1]++;
                        if (j + 1 < width)
                            if (numMatrix[i, j + 1] != -1)
                                numMatrix[i, j + 1]++;
                        if (i + 1 < high)
                            if (numMatrix[i + 1, j] != -1)
                                numMatrix[i + 1, j]++;
                        if (i - 1 > -1)
                            if (numMatrix[i - 1, j] != -1)
                                numMatrix[i - 1, j]++;

                        if ((j - 1 > -1) && (i + 1 < high))
                            if (numMatrix[i + 1, j - 1] != -1)
                                numMatrix[i + 1, j - 1]++;
                        if ((j + 1 < width) && (i + 1 < high))
                            if (numMatrix[i + 1, j + 1] != -1)
                                numMatrix[i + 1, j + 1]++;
                        if ((j - 1 > -1) && (i - 1 > -1))
                            if (numMatrix[i - 1, j - 1] != -1)
                                numMatrix[i - 1, j - 1]++;
                        if ((j + 1 < width) && (i - 1 > -1))
                            if (numMatrix[i - 1, j + 1] != -1)
                                numMatrix[i - 1, j + 1]++;
                    }

            var output = "";
            for (int i = 0; i < high; i++)
            {
                for (int j = 0; j < width; j++)
                    output += numMatrix[i, j].ToString() + " ";
                output += "\r\n";
            }
            File.Delete("out.txt");
            File.AppendAllText("out.txt", output);
        }
    }
}
