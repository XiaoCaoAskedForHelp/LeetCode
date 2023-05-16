namespace LeetCode.模拟;

public class Solution59螺旋矩阵II
{
    public int[][] GenerateMatrix(int n)
    {
        int[][] answer = new int[n][];
        for (int i = 0; i < n; i++)
        {
            answer[i] = new int[n];
        }

        int start = 0;
        int end = n - 1;
        int tmp = 1;
        while (tmp < n * n)
        {
            for (int i = start; i < end; i++)
            {
                answer[start][i] = tmp++;
            }

            for (int i = start; i < end; i++)
            {
                answer[i][end] = tmp++;
            }

            for (int i = end; i > start; i--)
            {
                answer[end][i] = tmp++;
            }

            for (int i = end; i > start; i--)
            {
                answer[i][start] = tmp++;
            }

            start++;
            end--;
        }

        if (n % 2 == 1)
        {
            answer[n / 2][n / 2] = tmp;
        }

        return answer;
    }

    public int[][] GenerateMatrix2(int n)
    {
        int maxNum = n * n;
        int curNum = 1;
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[n];
        }

        int row = 0, column = 0;
        int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        int index = 0;
        while (curNum <= maxNum)
        {
            matrix[row][column] = curNum;
            curNum++;
            int nextRow = row + directions[index, 0], nextColumn = column + directions[index, 1];
            if (nextRow < 0 || nextRow >= n || nextColumn < 0 || nextColumn >= n || matrix[nextRow][nextColumn] != 0)
            {
                index = (index + 1) % 4;
            }

            row = row + directions[index, 0];
            column = column + directions[index, 1];
        }

        return matrix;
    }
}