namespace LeetCode.动态规划;

public class Solution1139最大的以1为边界的正方形
{
    public int Largest1BorderedSquare(int[][] grid)
    {
        // int length = grid.Length;
        // int width = grid[0].Length;
        // int border = length < width ? length : width;
        // while (border >= 1)
        // {
        //     for (int i = 0; i < length - border + 1; i++)
        //     {
        //         for (int j = 0; j < width - border + 1; j++)
        //         {
        //             bool flag = true;
        //             for (int k = 0; k < border; k++)
        //             {
        //                 if (grid[i][j + k] != 1)
        //                 {
        //                     flag = false;
        //                     continue;
        //                 }
        //
        //                 if (grid[i + k][j] != 1)
        //                 {
        //                     flag = false;
        //                     continue;
        //                 }
        //                 
        //                 if (grid[i + border - 1][j + k] != 1)
        //                 {
        //                     flag = false;
        //                     continue;
        //                 }
        //                 
        //                 if (grid[i + k][j + border - 1] != 1)
        //                 {
        //                     flag = false;
        //                     continue;
        //                 }
        //             }
        //
        //             if (flag)
        //             {
        //                 return border;
        //             }
        //         }
        //     }
        //
        //     border--;
        // }
        //
        // return border;

        // 动态规划
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] left = new int[m + 1][];
        int[][] up = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            left[i] = new int[n + 1];
            up[i] = new int[n + 1];
        }

        int border = 0;
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (grid[i - 1][j - 1] == 1)
                {
                    left[i][j] = left[i][j - 1] + 1;
                    up[i][j] = up[i - 1][j] + 1;
                    
                    int bord = Math.Min(left[i][j], up[i][j]);
                    while (left[i - bord + 1][j] < bord || up[i][j - bord + 1] < bord)
                    {
                        bord--;
                    }
                    border = Math.Max(bord, border);
                }
            }
        }

        return border * border;
    }
}