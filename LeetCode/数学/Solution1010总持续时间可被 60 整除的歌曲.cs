namespace LeetCode.数学;

public class Solution1010总持续时间可被_60_整除的歌曲
{
    public int NumPairsDivisibleBy60(int[] time)
    {
        // 暴力 会超时
        int res = 0;
        for (int i = 0; i < time.Length; i++)
        {
            for (int j = i + 1; j < time.Length; j++)
            {
                if ((time[i] + time[j]) % 60 == 0)
                {
                    res++;
                }
            }
        }

        return res;
    }

    // 组合数学
    // 余数为0的歌曲需要与余数为0 的歌曲组成对
    // 余数为30的歌曲需要与余数为30的歌曲组成对
    // 余数为1-29的各族，需要与余数为60-i的歌曲组成对
    public int NumPairsDivisibleBy601(int[] time)
    {
        int[] cnt = new int[60];
        foreach (var t in time)
        {
            cnt[t % 60]++;
        }

        long res = 0;
        for (int i = 1; i < 30; i++)
        {
            res += cnt[i] * cnt[60 - i];
        }

        res += (long)cnt[0] * (cnt[0] - 1) / 2 + (long)cnt[30] * (cnt[30] - 1) / 2;
        return (int)res;
    }
}