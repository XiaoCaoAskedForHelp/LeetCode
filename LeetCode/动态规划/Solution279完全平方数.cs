namespace LeetCode.动态规划;

public class Solution279完全平方数
{
    public int NumSquares(int n)
    {
        List<int> squares = new List<int>();
        for (int i = 1; i * i <= n; i++)
        {
            squares.Add(i * i);
        }

        // var sqs = squares.ToArray();

        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            dp[i] = Int32.MaxValue;
        }

        for (int i = 0; i < squares.Count; i++)
        {
            for (int j = squares[i]; j <= n; j++)
            {
                if (dp[j - squares[i]] != Int32.MaxValue)
                {
                    dp[j] = Math.Min(dp[j], dp[j - squares[i]] + 1);
                }
            }
        }

        return dp[n];
    }

    public int NumSquares1(int n)
    {
        int[] dp = Enumerable.Repeat(Int32.MaxValue, n + 1).ToArray();
        dp[0] = 0;
        for (int i = 0; i <= n; i++) // 遍历背包
        {
            for (int j = 1; j * j <= i; j++) // 遍历物品
            {
                dp[i] = Math.Min(dp[i - j * j] + 1, dp[i]);
            }
        }

        return dp[n];
    }

    public int NumSquares2(int n)
    {
        int[] dp = Enumerable.Repeat(Int32.MaxValue, n + 1).ToArray();
        dp[0] = 0;
        for (int i = 1; i * i <= n; i++) // 遍历物品
        {
            for (int j = i * i; j <= n; j++) // 遍历背包
            {
                // 因为第一个是1，并且遍历背包是正序的，所以不会存在dp[i] + 1超出int32范围的
                dp[j] = Math.Min(dp[j - i * i] + 1, dp[j]);
            }
        }

        return dp[n];
    }
}