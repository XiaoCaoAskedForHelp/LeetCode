namespace LeetCode.模拟;

public class Solution54螺旋矩阵
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        IList<int> res = new List<int>();
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return res;
        }

        int rows = matrix.Length, columns = matrix[0].Length;
        bool[,] visited = new bool[rows, columns];
        int total = rows * columns;
        int row = 0, column = 0;
        int[,] directions = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        int index = 0;
        for (int i = 0; i < total; i++)
        {
            res.Add(matrix[row][column]);
            visited[row, column] = true;
            int nextRow = directions[index, 0] + row, nextColumn = column + directions[index, 1];
            if (nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns ||
                visited[nextRow, nextColumn])
            {
                index = (index + 1) % 4;
            }

            row += directions[index, 0];
            column += directions[index, 1];
        }

        return res;
    }

    public IList<int> SpiralOrder1(int[][] matrix)
    {
        List<int> res = new List<int>();
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return res;
        }
        int rows = matrix.Length, columns = matrix[0].Length;
        int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
        while (left <= right && top <= bottom)
        {
            for (int column = left; column <= right; column++)
            {
                res.Add(matrix[top][column]);
            }

            for (int row = top+1; row <= bottom; row++)
            {
                res.Add(matrix[row][right]);
            }

            if (left < right && top < bottom)
            {
                for (int column = right-1; column > left; column--)
                {
                    res.Add(matrix[bottom][column]);
                }

                for (int row = bottom; row > top; row--)
                {
                    res.Add(matrix[row][left]);
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