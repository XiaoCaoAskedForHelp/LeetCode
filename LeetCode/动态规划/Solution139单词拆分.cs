using System.Text;

namespace LeetCode.动态规划;

public class Solution139单词拆分
{
    // 超出时间限制
    public bool WordBreak(string s, IList<string> wordDict)
    {
        IList<string> list = new List<string>(wordDict);
        for (int i = 0; i < wordDict.Count; i++)
        {
            if (s == wordDict[i])
            {
                return true;
            }
        }

        while (true)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string str = list[i];
                for (int j = 0; j < wordDict.Count; j++)
                {
                    list.Remove(str);
                    string newStr = str + wordDict[j];
                    if (newStr == s)
                    {
                        return true;
                    }
                    else if (newStr.Length < s.Length)
                    {
                        list.Add(str + wordDict[j]);
                    }
                }
            }

            if (list.Count == 0)
            {
                return false;
            }
        }
    }

    // dp[i] : 字符串长度为i的话，dp[i]为true，表示可以拆分为一个或多个在字典中出现的单词。
    public bool WordBreak1(string s, IList<string> wordDict)
    {
        bool[] valid = new bool[s.Length + 1];
        valid[0] = true;

        for (int i = 1; i <= s.Length; i++)
        {
            // 查看从j到i的字符串是否出现在词典中,，并且需要从0到j的字符串已经被验证过才行
            for (int j = 0; j < i && !valid[i]; j++)
            {
                //substring(起始位置，截取的个数)
                if (wordDict.Contains(s.Substring(j, i - j)) && valid[j])
                {
                    valid[i] = true;
                }
            }
        }

        return valid[s.Length];
    }

    // 截取原字符串中一段，用词典去遍历看是否存在
    public bool WordBreak2(string s, IList<string> wordDict)
    {
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;

        for (int i = 1; i <= s.Length; i++)
        {
            foreach (string word in wordDict)
            {
                int len = word.Length;
                if (i >= len && dp[i - len] && word.Equals(s.Substring(i - len, len)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }

    private int[] memo;
    private IList<string> set;
    public bool WordBreak3(string s, IList<string> wordDict)
    {
        memo = new int[s.Length];
        set = wordDict;
        return backtracking(s, 0);
    }

    public bool backtracking(string s, int startIndex)
    {
        if (startIndex == s.Length)
        {
            return true;
        }

        if (memo[startIndex] == -1)
        {
            return false;
        }

        for (int i = startIndex; i < s.Length; i++)
        {
            string sub = s.Substring(startIndex, i - startIndex + 1);
            if (!set.Contains(sub))
            {
                continue;
            }

            bool res = backtracking(s, i + 1);
            if (res) return true;
        }
        // 这里是关键，找遍了startIndex~s.length()也没能完全匹配，标记从startIndex开始不能找到
        memo[startIndex] = -1;
        return false;
    }
}