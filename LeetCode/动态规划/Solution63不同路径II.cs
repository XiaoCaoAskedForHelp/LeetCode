namespace LeetCode.动态规划;

public class Solution63不同路径II
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        if (obstacleGrid[m - 1][n - 1] == 1 || obstacleGrid[0][0] == 1)
        {
            return 0;
        }

        int[,] dp = new int[m, n];
        for (int i = 0; i < m && obstacleGrid[i][0] == 0; i++) dp[i, 0] = 1;
        for (int i = 0; i < n && obstacleGrid[0][i] == 0; i++) dp[0, i] = 1;

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1) continue;
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m - 1, n - 1];
    }

    public int UniquePathsWithObstacles1(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;
        if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1 )
        {
            return 0;
        }

        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (obstacleGrid[0][i] == 0)
            {
                dp[i] = 1;
            }
            else
            {
                break;
            }
        }

        for (int i = 1; i < obstacleGrid.Length; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    dp[j] = 0;
                }
                else if (j != 0)
                {
                    dp[j] += dp[j - 1];
                }
            }
        }

        return dp[n - 1];
    }
}