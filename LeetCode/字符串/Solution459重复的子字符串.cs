namespace LeetCode.字符串;

public class Solution459重复的子字符串
{
    // 暴力，从第一个字母开始枚举，到字符串的一半
    // 原串的长度是子串的长度的倍数，子串是前缀
    public bool RepeatedSubstringPattern(string s)
    {
        int n = s.Length;
        for (int i = 1; i * 2 <= n; i++)
        {
            if (n % i == 0)
            {
                bool match = true;
                for (int j = i; j < n; j++)
                {
                    // 每次比较只需要和前一次重复的字符串比较。
                    if (s[j] != s[j - i])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    return true;
                }
            }
        }

        return false;
    }

    // 只要两个s拼接在一起，里面还出现一个s的话，就说明是由重复子串组成
    public bool RepeatedSubstringPattern1(string s)
    {
        // 这里的indexof可以使用KMP替代
        return (s + s).IndexOf(s, 1) != s.Length;
    }

    public bool RepeatedSubstringPattern2(string s)
    {
        if (s.Equals(""))
        {
            return false;
        }

        // next 数组中每个位置的值是最长相同前后缀的长度，也是该跳转的目标位置
        // 当重复时，除去第一个子串，其他子串的next值就是重复的个数
        // a b c a b c a b c
        // 0 1 1 1 2 3 4 5 6

        int len = s.Length;
        // 原串加个空格，使下标j从0开始，i从2开始
        s = " " + s;
        char[] chars = s.ToCharArray();
        int[] next = new int[len + 1];

        for (int i = 2, j = 0; i <= len; i++)
        {
            while (j > 0 && chars[i] != chars[j + 1]) j = next[j];
            if (chars[i] == chars[j + 1]) j++;
            next[i] = j;
        }

        if (next[len] > 0 && len % (len - next[len]) == 0)
        {
            return true;
        }

        return false;
    }
}