namespace LeetCode.哈希表;

public class Solution205同构字符串
{
    public bool IsIsomorphic(string s, string t)
    {
        Dictionary<char, char> dictionary = new Dictionary<char, char>();
        Dictionary<char, char> dictionary2 = new Dictionary<char, char>();
        if (s.Length != t.Length)
        {
            return false;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if ((dictionary.ContainsKey(s[i]) && dictionary[s[i]] != t[i]) ||
                (dictionary2.ContainsKey(t[i]) && dictionary2[t[i]] != s[i]))
            {
                return false;
            }
            else
            {
                dictionary.TryAdd(s[i], t[i]);
                dictionary2.TryAdd(t[i], s[i]);
            }
        }

        return true;
    }
}