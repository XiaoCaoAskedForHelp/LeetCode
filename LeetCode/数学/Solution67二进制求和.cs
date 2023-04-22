using System.Text;
using Microsoft.CodeAnalysis;

namespace LeetCode;

public class Solution67二进制求和
{
    public string AddBinary(string a, string b)
    {
        return Convert.ToString((Convert.ToByte(a, 2) + Convert.ToByte(b, 2)),2);
    }
    
    public string AddBinary1(string a, string b)
    {
        StringBuilder ans = new StringBuilder();

        int len = Math.Max(a.Length, b.Length), carry = 0;
        for (int i = 0; i < len; i++)
        {
            carry += i < a.Length ? (a[a.Length - 1 - i] - '0') : 0;
            carry += i < b.Length ? (b[b.Length - 1 - i] - '0') : 0;
            ans.Append((char)(carry % 2 + '0'));
            carry /= 2;
        }

        if (carry > 0)
        {
            ans.Append('1');
        }

        var reverse = Reverse(ans.ToString());
        return reverse;
    }
    
    static string Reverse(string text)
    {
        char[] charArray = text.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}