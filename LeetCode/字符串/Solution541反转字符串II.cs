namespace LeetCode.字符串;

public class Solution541反转字符串II
{
    // 双指针，每次都是只想要反转字符串的第一个字符和最后一个要翻转的字符，然后在统一加2k。
    public string ReverseStr(string s, int k)
    {
        int left = 0, right = k - 1;
        char[] str = s.ToCharArray();
        while (right < s.Length || left + k < s.Length)
        {
            int l = left, r = right;
            for (int i = 0; i < k / 2; i++)
            {
                Swap(str, l, r);
                l++;
                r--;
            }

            left += 2 * k;
            right += 2 * k;
        }

        if (left < s.Length)
        {
            int l = left, r = s.Length - 1;
            int len = r - l;
            for (int i = 0; i <= len / 2; i++)
            {
                Swap(str, l, r);
                l++;
                r--;
            }
        }

        return new string(str);
    }

    private void Swap(char[] chars, int i, int sLength)
    {
        (chars[i], chars[sLength]) = (chars[sLength], chars[i]);
    }
    
    // 模拟，直接按照题意进行模拟
    public string ReverseStr1(string s, int k) {
        int n = s.Length;
        char[] arr = s.ToCharArray();
        for (int i = 0; i < n; i += 2 * k) {
            // 这一步简化操作，将i直接作为左指针，其实需要注意的就是翻转字符串的右端点，要么就是左端点+k，要么就是字符串的最后一个字符。
            Reverse(arr, i, Math.Min(i + k, n) - 1);
        }
        return new string(arr);
    }
    
    public void Reverse(char[] arr, int left, int right) {
        while (left < right) {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }
    }
}