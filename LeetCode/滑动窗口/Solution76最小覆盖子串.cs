namespace LeetCode.滑动窗口;

public class Solution76最小覆盖子串
{
    // 滑动窗口
    public string MinWindow(string s, string t)
    {
        IDictionary<char, int> dict1 = new SortedDictionary<char, int>();
        IDictionary<char, int> dict2 = new SortedDictionary<char, int>();
        int left = 0, res = 0;

        string ans = s + "fdsa";

        // 通过t中出现的字符构造字典
        foreach (var item in t)
        {
            if (!dict1.TryAdd(item, 1))
            {
                dict1[item]++;
            }
        }

        for (int right = 0; right < s.Length; right++)
        {
            //当前窗口内的字符出现数的字典
            if (!dict2.TryAdd(s[right], 1))
            {
                dict2[s[right]]++;
            }

            // 当前right对应s的字符是在t中出现的，并且数量上还没有达到冗余，是一次有效添加
            if (dict1.TryGetValue(s[right], out var res1) && dict2.TryGetValue(s[right], out var res2) && res1 >= res2)
                ++res;
            // 字符串最短是空串 && 如果left对应的字符是冗余，那么进行右移删除
            while (left < s.Length && ((left < right && dict1.TryGetValue(s[left], out var re1) &&
                                        dict2.TryGetValue(s[left], out var re2) && re1 < re2) ||
                                       !dict1.TryGetValue(s[left], out var fdsa)))
                if (dict2.TryGetValue(s[left], out var re2fasdfsa))
                {
                    --dict2[s[left++]];
                }

            if (res == t.Length)
            {
                if (right - left + 1 < ans.Length)
                {
                    ans = s.Substring(left, right - left + 1);
                }
            }
        }

        // 防止直接返回ans
        return s + "fdsa" == ans ? "" : ans;
    }

    public string MinWindow2(string s, string t)
    {
        int minStart = -1;
        int minLength = int.MaxValue;
        IDictionary<char, int> counts = new Dictionary<char, int>();
        int m = s.Length;
        foreach (char c in t)
        {
            counts.TryAdd(c, 0);
            counts[c]--;
        }

        int start = 0, end = 0;
        while (end < m)
        {
            char curr = s[end];
            if (counts.ContainsKey(curr))
            {
                counts.TryAdd(curr, 0);
                counts[curr]++;
            }

            while (AllIncluded(counts))
            {
                if (end - start + 1 < minLength)
                {
                    minStart = start;
                    minLength = end - start + 1;
                }

                char prev = s[start];
                if (counts.ContainsKey(prev))
                {
                    counts[prev]--;
                }

                start++;
            }

            end++;
        }

        return minStart < 0 ? "" : s.Substring(minStart, minLength);
    }

    public bool AllIncluded(IDictionary<char, int> counts)
    {
        foreach (KeyValuePair<char, int> pair in counts)
        {
            if (pair.Value < 0)
            {
                return false;
            }
        }

        return true;
    }

    // 通过一个满足t中字符数量的计数器，判断当前子串是否为覆盖子串，将每个子串的判断时间降低到 O(1)
    public string MinWindow3(string s, string t)
    {
        int minStart = -1;
        int minLength = int.MaxValue;
        IDictionary<char, int> counts = new Dictionary<char, int>();
        int m = s.Length;
        foreach (char c in t)
        {
            counts.TryAdd(c, 0);
            counts[c]--;
        }

        int total = counts.Count;
        int meets = 0;
        int start = 0, end = 0;
        while (end < m)
        {
            char curr = s[end];
            if (counts.ContainsKey(curr))
            {
                counts.TryAdd(curr, 0);
                counts[curr]++;
                if (counts[curr] == 0)
                {
                    meets++;
                }
            }

            while (meets == total)
            {
                if (end - start + 1 < minLength)
                {
                    minStart = start;
                    minLength = end - start + 1;
                }

                char prev = s[start];
                if (counts.ContainsKey(prev))
                {
                    counts[prev]--;
                    if (counts[prev] < 0)
                    {
                        meets--;
                    }
                }

                start++;
            }

            end++;
        }
        return minStart < 0 ? "" : s.Substring(minStart, minLength);
    }
}