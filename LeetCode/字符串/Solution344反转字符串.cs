namespace LeetCode.字符串;

public class Solution344反转字符串
{
    // 相当于双指针的解法，通过下标从开始位置和最后位置依次交换
    public void ReverseString(char[] s)
    {
        // Array.Reverse(s);
        for (int i = 0; i < s.Length / 2; i++)
        {
            Swap(s, i, s.Length - 1 - i);
        }

        // for (int i = 0, j = s.Length - 1; i < s.Length/2; i++, j--) {
        //     Swap(...);
        // }
    }

    // 方法一 普通
    private void Swap(char[] chars, int i, int sLength)
    {
        // 方法一 普通
        // char temp = chars[i];
        // chars[i] = chars[sLength];
        // chars[sLength] = temp;
        
        // 方法二 元组
        (chars[i], chars[sLength]) = (chars[sLength], chars[i]);
    }
    
    // 或者直接一开始就是元组
    public void ReverseString1(char[] s)
    {
        var (l, r) = (0, s.Length - 1);
        while (l<r)
        {
            (s[l], s[r]) = (s[r], s[l]);
            l++;
            r--;
        }
    }
}