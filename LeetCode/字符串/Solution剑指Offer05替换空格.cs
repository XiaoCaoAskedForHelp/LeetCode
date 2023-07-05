using System.Text;

namespace LeetCode.字符串;

public class Solution剑指Offer05替换空格
{
    public string ReplaceSpace(string s)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (' '.Equals(s[i]))
            {
                stringBuilder.Append("%20");
            }
            else
            {
                stringBuilder.Append(s[i]);
            }
        }

        return stringBuilder.ToString();
    }

    // 如果想把这道题目做到极致，就不要只用额外的辅助空间了！
    // 首先扩充数组到每个空格替换成"%20"之后的大小。
    // 然后从后向前替换空格，也就是双指针法
    // i指向新长度的末尾，j指向旧长度的末尾。

    // 很多数组填充类的问题，都可以先预先给数组扩容带填充后的大小，然后在从后向前进行操作。
    // 这么做有两个好处：
    // 1.不用申请新数组。
    // 2.从后向前填充元素，避免了从前向后填充元素时，每次添加元素都要将添加元素之后的所有元素向后移动的问题。
    public string ReplaceSpace1(string s)
    {
        if (s == null || s.Length == 0)
        {
            return s;
        }
        int count = 0;
        int oldLen = s.Length;
        for (int i = 0; i < oldLen; i++)
        {
            if (s[i] == ' ')
            {
                count++;
            }
        }
        
        // 扩充字符串s的大小，也就是每个空格替换成"%20"之后的大小
        s = s.PadRight(oldLen + count * 2);
        var chars = s.ToCharArray();
        int newLen = s.Length;
        for (int i = newLen - 1, j = oldLen - 1; j < i; i--, j--)
        {
            if (s[j] != ' ')
            {
                chars[i] = chars[j];
            }
            else
            {
                chars[i--] = '0';
                chars[i--] = '2';
                chars[i] = '%';
            }
        }

        return new string(chars);
    }
}