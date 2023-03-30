namespace LeetCode;

/// <summary>
/// 2373. 矩阵中的局部最大值
/// </summary>
public class Solution17
{
    public int[][] LargestLocal(int[][] grid)
    {
        int len = grid.Length;
        int[][] res = new int[len - 2][];
        for (int i = 0; i < len - 2; i++)
        {
            res[i] = new int[len - 2];
        }

        for (int i = 1; i < len - 1; i++)
        {
            for (int j = 1; j < len - 1; j++)
            {
                int max = 0;
                for (int k = i-1; k <= i+1; k++)
                {
                    for (int l = j-1; l <= j+1; l++)
                    {
                        max = Math.Max(grid[k][l], max);
                    }
                }

                res[i - 1][j - 1] = max;
            }
        }

        return res;
    }
}