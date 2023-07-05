using System.Text;

namespace LeetCode.字符串;

public class Solution151反转字符串中的单词
{
    // 分隔 去除空格， 然后拼接
    public string ReverseWords(string s)
    {
        s = s.Trim();
        var strs = s.Split(" ");
        strs = strs.Where(s => !string.IsNullOrEmpty(s)).ToArray();
        Array.Reverse(strs);
        return string.Join(" ", strs);
    }

    // -------------------------------------------------------------------------

    public string ReverseWords1(string s)
    {
        StringBuilder sb = RemoveSpace(s);
        ReverseString(sb, 0, sb.Length - 1);
        ReverseEachWord(sb);
        return sb.ToString();
    }

    // 不使用split，不要使用辅助空间，空间复杂度要求为O(1)。
    // 不使用辅助空间，就只能在原字符串上下手
    // 1.去除多余空格，2.将整个字符串反转，3.将每个单词反转
    private StringBuilder RemoveSpace(string s)
    {
        int start = 0;
        int end = s.Length - 1;
        while (s[start] == ' ') start++;
        while (s[end] == ' ') end--;
        StringBuilder sb = new StringBuilder();
        while (start <= end)
        {
            if (s[start] != ' ' || sb[sb.Length - 1] != ' ')
            {
                sb.Append(s[start]);
            }

            start++;
        }

        return sb;
    }

    //使用快慢指针去除首尾和中间多余空格
    private char[] RemoveSpace(char[] chars)
    {
        int slow = 0;
        for (int fast = 0; fast < chars.Length; fast++)
        {
            // 先用fast移除所有空格
            if (chars[fast] != ' ')
            {
                // 除第一个单词之外，其他所以单词在添加进行之前都需要先加一个空格
                if (slow != 0)
                {
                    chars[slow++] = ' ';
                }

                // 将整个单词加入
                while (fast < chars.Length && chars[fast] != ' ')
                {
                    chars[slow++] = chars[fast++];
                }
            }
        }

        char[] newChars = new char[slow];
        Array.Copy(chars, 0, newChars, 0, slow);
        return newChars;
    }

    // 双指针翻转字符串
    private void ReverseString(StringBuilder sb, int start, int end)
    {
        while (start < end)
        {
            (sb[start], sb[end]) = (sb[end], sb[start]);
            start++;
            end--;
        }
    }

    private void ReverseEachWord(StringBuilder sb)
    {
        int start = 0;
        int end = 1;
        int n = sb.Length;
        while (start < n)
        {
            while (end < n && sb[end] != ' ')
            {
                end++;
            }

            ReverseString(sb, start, end - 1);

            start = end + 1;
            end = start + 1;
        }
    }


    //----------------------------------

    // 创建新字符数组填充
    public string ReverseWords2(string s)
    {
        var charArray = s.ToCharArray();

        char[] newArr = new char[charArray.Length];
        int index = 0;
        for (int i = charArray.Length - 1; i >= 0; i--)
        {
            // 从后往前找出每个单词的第一个和最后一个字母的位置，然后填入新的字符数组中
            while (i >= 0 && charArray[i] == ' ') i--;
            int right = i;
            while (i >= 0 && charArray[i] != ' ') i--;
            for (int j = i + 1; j <= right; j++)
            {
                newArr[index++] = charArray[j];
                if (j == right)
                {
                    newArr[index++] = ' ';
                }
            }
        }

        return new string(newArr, 0, index - 1);
    }
}