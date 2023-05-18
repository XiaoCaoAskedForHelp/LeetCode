namespace LeetCode.模拟;

public class Solution剑指Offer29顺时针打印矩阵
{
    public int[] SpiralOrder(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return new int[]{};
        }
        int rows = matrix.Length, columns = matrix[0].Length;
        int row = 0, column = 0;
        int max = rows * columns;
        int[] res = new int[max];
        int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        int index = 0;
        for (int i = 0; i < max; i++)
        {
            res[i] = matrix[row][column];
            matrix[row][column] = int.MinValue;
            int nextRow = row + directions[index, 0], nextColumn = column + directions[index, 1];
            if (nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns ||
                matrix[nextRow][nextColumn] == int.MinValue)
            {
                index = (index + 1) % 4;
            }

            row = row + directions[index, 0];
            column = column + directions[index, 1];
        }

        return res;
    }

    public int[] SpiralOrder2(int[][] matrix)
    {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return new int[]{};
        }
        int rows = matrix.Length, columns = matrix[0].Length;
        int[] res = new int[rows * columns];
        int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
        int index = 0;
        while (left <= right && top <= bottom)
        {
            for (int column = left; column <= right; column++)
            {
                res[index] = matrix[top][column];
                index++;
            }

            for (int row = top+1; row <= bottom; row++)
            {
                res[index] = matrix[row][right];
                index++;
            }

            if (left < right && top < bottom)
            {
                for (int column = right-1; column > left; column--)
                {
                    res[index] = matrix[bottom][column];
                    index++;
                }

                for (int row = bottom; row > top; row--)
                {
                    res[index] = matrix[row][left];
                    index++;
                }
            }

            left++;
            right--;
            top++;
            bottom--;
        }

        return res;
    }
}