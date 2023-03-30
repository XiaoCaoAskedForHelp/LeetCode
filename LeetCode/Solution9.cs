﻿namespace LeetCode;

// 1140. 石子游戏 II
public class Solution9
{
    public int StoneGameII(int[] piles)
    {
        //dp[i][j]表示剩余[i : len - 1]堆时，M = j的情况下，先取的人能获得的最多石子数
        var length = piles.Length;
        int sum = 0;
        int[][] dp = new int[length][];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[length + 1];
        }

        for (int i = length - 1; i >= 0; i--)
        {
            sum += piles[i];
            for (int M = 1; M <= length; M++)
            {
                //i + 2M >= len, dp[i][M] = sum[i : len - 1], 剩下的堆数能够直接全部取走，那么最优的情况就是剩下的石子总和
                if (i + 2 * M >= length)
                {
                    dp[i][M] = sum;
                }
                else
                {
                    // x表示选择走的步数
                    // dp[i + x][Math.Max(M, x)]为下一个人最多能取的值
                    // i + 2M < len, dp[i][M] = max(dp[i][M], sum[i : len - 1] - dp[i + x][max(M, x)]), 其中 1 <= x <= 2M，剩下的堆数不能全部取走，那么最优情况就是让下一个人取的更少。
                    for (int x = 1; x <= 2 * M; x++)
                    {
                        dp[i][M] = Math.Max(dp[i][M], sum - dp[i + x][Math.Max(M, x)]);
                    }
                }
            }
        }

        return dp[0][1];
    }
}