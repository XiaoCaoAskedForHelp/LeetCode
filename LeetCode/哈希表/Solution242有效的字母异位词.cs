namespace LeetCode.哈希表;

public class Solution242有效的字母异位词
{
    // 哈希表
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        IDictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            dict.TryAdd(s[i], 0);
            dict[s[i]]++;
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (!dict.TryGetValue(t[i], out var fdf) || --dict[t[i]] < 0)
            {
                return false;
            }
        }

        return true;
    }

    // 哈希表
    // 因为题目字符串是小写字母，只有二十六个英文字母，所以我们完全可以使用数组作为哈希表。
    public bool IsAnagram1(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] table = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            table[s[i] - 'a']++;
        }

        for (int i = 0; i < t.Length; i++)
        {
            table[t[i] - 'a']--;
            if (table[t[i] - 'a'] < 0)
            {
                return false;
            }
        }

        return true;
    }
}