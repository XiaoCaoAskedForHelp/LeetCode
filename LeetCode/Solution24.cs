namespace LeetCode;

/// <summary>
/// 剑指 Offer 47. 礼物的最大价值
/// </summary>
public class Solution24
{
    public int MaxValue(int[][] grid)
    {
        int width = grid.Length;
        int length = grid[0].Length;
        int[][] values = new int[2][];
        for (int i = 0; i < 2; i++)
        {
            values[i] = new int[length];
        }

        int index = 0;
        for (int i = 0; i < width; i++)
        {
            index = 1 - index;
            for (int j = 0; j < length; j++)
            {
                if (i > 0)
                {
                    values[index][j] = Math.Max(values[1 - index][j], values[index][j]);
                }

                if (j > 0)
                {
                    values[index][j] = Math.Max(values[index][j - 1], values[index][j]);
                }

                values[index][j] += grid[i][j];
            }
        }

        return values[index][length - 1];
    }
}