using System.Text;

namespace LeetCode.字符串;

public class Solution剑指Offer58II左旋转字符串
{
    // 使用substr 和 反转 时间复杂度是一样的 ，都是O(n)，但是使用substr申请了额外空间，所以空间复杂度是O(n)，而反转方法的空间复杂度是O(1)

    // 整体思路通过翻转，
    // 无论是通过整个翻转一次，在局部翻转两次还是局部翻转两次在整体翻转一次都是可以的。
    public string ReverseLeftWords(string s, int n)
    {
        int len = s.Length;
        var charArray = s.ToCharArray();
        ReverseString(charArray, 0, n - 1);
        ReverseString(charArray, n, len - 1);
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string ReverseLeftWords1(string s, int n)
    {
        int len = s.Length;
        var charArray = s.ToCharArray();
        ReverseString(charArray, 0, len - 1);
        ReverseString(charArray, 0, len - n - 1);
        ReverseString(charArray, len - n, len - 1);
        return new string(charArray);
    }


    private void ReverseString(char[] sb, int start, int end)
    {
        while (start < end)
        {
            (sb[start], sb[end]) = (sb[end], sb[start]);
            start++;
            end--;
        }
    }
}