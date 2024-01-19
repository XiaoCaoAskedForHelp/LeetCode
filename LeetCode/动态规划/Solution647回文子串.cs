namespace LeetCode.动态规划;

public class Solution647回文子串
{
    public int CountSubstrings(string s)
    {
        int len = s.Length;
        int res = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                if (IsPalindrome(s, i, j))
                {
                    res++;
                }
            }
        }

        return res;
    }

    public bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
            {
                return false;
            }

            start++;
            end--;
        }

        return true;
    }

    //布尔类型的dp[i][j]：表示区间范围[i,j] （注意是左闭右闭）的子串是否是回文子串
    // 情况一：下标i 与 j相同，同一个字符例如a，当然是回文子串
    // 情况二：下标i 与 j相差为1，例如aa，也是回文子串
    // 情况三：下标：i 与 j相差大于1的时候，例如cabac，此时s[i]与s[j]已经相同了，我们看i到j区间是不是回文子串就看aba是不是回文就可以了，
    // 那么aba的区间就是 i+1 与 j-1区间，这个区间是不是回文就看dp[i + 1][j - 1]是否为true。

    // 遍历顺序：从下到上，从左到右遍历，dp[i,j]依赖的是dp[i + 1][j - 1]
    public int CountSubstrings1(string s)
    {
        int len = s.Length;
        bool[,] dp = new Boolean[len, len];
        int res = 0;
        for (int i = len - 1; i >= 0; i--)
        {
            for (int j = i; j < len; j++)
            {
                if (s[i] != s[j])
                {
                    dp[i, j] = false;
                }
                else
                {
                    // 情况一和情况二
                    if (j - i <= 2)
                    {
                        dp[i, j] = true;
                        res++;
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j - 1];
                        if (dp[i, j])
                        {
                            res++;
                        }
                    }
                }
            }
        }

        return res;
    }

    public int CountSubstrings2(string s)
    {
        bool[,] dp = new bool[s.Length, s.Length];
        int result = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            // 注意遍历顺序
            for (int j = i; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    if (j - i <= 1)
                    {
                        // 情况一 和 情况二
                        result++;
                        dp[i, j] = true;
                    }
                    else if (dp[i + 1, j - 1])
                    {
                        // 情况三
                        result++;
                        dp[i, j] = true;
                    }
                }
            }
        }

        return result;
    }

    public int CountSubstrings3(string s)
    {
        bool[,] dp = new bool[s.Length, s.Length];
        int result = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (s[i] == s[j] && (j - i <= 1 || dp[i + 1, j - 1]))
                {
                    result++;
                    dp[i, j] = true;
                }
            }
        }

        return result;
    }
}