using Microsoft.CodeAnalysis;

namespace LeetCode.哈希表;

public class Solution438找到字符串中所有字母异位词
{
    public IList<int> FindAnagrams(string s, string p)
    {
        int sLen = s.Length, pLen = p.Length;

        if (sLen < pLen)
        {
            return new List<int>();
        }

        int[] scount = new int[26];
        int[] pcount = new int[26];
        IList<int> res = new List<int>();

        for (int i = 0; i < pLen; i++)
        {
            ++scount[s[i] - 'a'];
            ++pcount[p[i] - 'a'];
        }

        if (Enumerable.SequenceEqual(scount, pcount))
        {
            res.Add(0);
        }

        // 让窗口开始滑动
        for (int i = 0; i < sLen - pLen; i++)
        {
            --scount[s[i] - 'a'];
            ++scount[s[i + pLen] - 'a'];

            if (Enumerable.SequenceEqual(scount, pcount))
            {
                res.Add(i + 1);
            }
        }

        return res;
    }

    // 优化滑动窗口，通过字母不同的数量进行判别
    public IList<int> FindAnagrams1(string s, string p)
    {
        int sLen = s.Length, pLen = p.Length;

        if (sLen < pLen)
        {
            return new List<int>();
        }

        IList<int> res = new List<int>();
        int[] count = new int[26];
        for (int i = 0; i < pLen; i++)
        {
            ++count[s[i] - 'a'];
            --count[p[i] - 'a'];
        }

        int differ = 0;
        for (int i = 0; i < 26; i++)
        {
            if (count[i] != 0)
            {
                ++differ;
            }
        }

        if (differ == 0)
        {
            res.Add(0);
        }

        for (int i = 0; i < sLen - pLen; i++)
        {
            --count[s[i] - 'a'];
            if (count[s[i] - 'a'] == 0)
            {
                differ--;
            }
            else if (count[s[i] - 'a'] == -1)

            {
                differ++;
            }

            ++count[s[i + pLen] - 'a'];
            if (count[s[i + pLen] - 'a'] == 0)
            {
                differ--;
            }
            else if (count[s[i + pLen] - 'a'] == 1)
            {
                differ++;
            }

            if (differ == 0)
            {
                res.Add(i + 1);
            }
        }

        return res;
    }
}