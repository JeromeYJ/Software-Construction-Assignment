using System;

namespace Toeplitz
{
    internal class Toeplitz
    {
        public bool IsToeplitz(int[,] matrix,int rowNum,int colNum)  //二维数组的类型写法与C++不同，需要注意
        {
            int row, col, tmp;
            for (int i = 0; i < rowNum-1; i++)
            {
                row = i; col = 0;
                tmp = matrix[i,0];
                while (row < rowNum && col < colNum)
                {
                    if (matrix[row,col] != tmp)
                        return false;
                    row++; col++;
                }
            }
            for(int j = 1; j < colNum-1; j++)
            {
                row = 0; col = j;
                tmp = matrix[0,j];
                while (row < rowNum && col < colNum)
                {
                    if (matrix[row, col] != tmp)
                        return false;
                    row++; col++;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Toeplitz t = new Toeplitz();
            Console.WriteLine("您需要输入一个矩阵。");
            Console.WriteLine("该矩阵的行数为：");
            int rowNum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("该矩阵的列数为：");
            int colNum = Int32.Parse(Console.ReadLine());

            int[,] matrix = new int[rowNum,colNum];
            Console.WriteLine("请依次输入数组的元素：");
            for(int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    Console.Write($"matrix[{i},{j}]: ");
                    matrix[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine(t.IsToeplitz(matrix, rowNum, colNum));
            //是托普利茨矩阵时输出True，否则输出False
        }
    }
}