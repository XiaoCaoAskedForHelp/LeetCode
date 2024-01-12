namespace LeetCode.动态规划;

public class Solution392判断子序列
{
    // 双指针
    public bool IsSubsequence(string s, string t)
    {
        int sidx = 0, tidx = 0;
        while (sidx < s.Length && tidx < t.Length)
        {
            if (s[sidx] == t[tidx])
            {
                sidx++;
            }

            tidx++;
        }

        return sidx == s.Length;
    }

    public bool IsSubsequence1(string s, string t)
    {
        int slen = s.Length, tlen = t.Length;
        int[,] dp = new int[slen + 1, tlen + 1];
        for (int i = 1; i <= slen; i++)
        {
            for (int j = 1; j <= tlen; j++)
            {
                if (s[i - 1] == t[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    // if (s[i - 1] != t[j - 1])，此时相当于t要删除元素，t如果把当前元素t[j - 1]删除，那么dp[i][j] 的数值就是 看s[i - 1]与 t[j - 2]的比较结果了，即：dp[i][j] = dp[i][j - 1];
                    dp[i, j] = dp[i, j - 1];
                }
            }
        }

        return dp[slen, tlen] == slen;
    }

    public bool IsSubsequence2(string s, string t)
    {
        int slen = s.Length, tlen = t.Length;
        int[] dp = new int[tlen + 1];
        for (int i = 1; i <= slen; i++)
        {
            int pre = dp[0];
            for (int j = 1; j <= tlen; j++)
            {
                int temp = dp[j]; // 暂存一下给下一次循环用
                if (s[i - 1] == t[j - 1])
                {
                    dp[j] = pre + 1;
                }
                else
                {
                    // dp[j] = Math.Max(dp[j - 1], dp[j]);
                    dp[j] = dp[j - 1];
                }

                pre = temp;
            }
        }

        return dp[tlen] == slen;
    }
}