namespace LeetCode;

/// <summary>
/// 1247. 交换字符使得字符串相同
/// </summary>
public class Solution13
{
    public int MinimumSwap(string s1, string s2)
    {
        int length = s1.Length;
        int[] str = new int[2];
        for (int i = 0; i < length; i++)
        {
            if (s1[i] == s2[i])
            {
                continue;
            }

            if (s1[i] == 'x' && s2[i] == 'y')
            {
                str[0]++;
            }

            if (s1[i] == 'y' && s2[i] == 'x')
            {
                str[1]++;
            }
        }

        int result = str[0] / 2;
        str[0] = str[0] % 2;
        result += str[1] / 2;
        str[1] = str[1] % 2;
        if (str[0] != str[1])
        {
            return -1;
        }

        return result += str[0];
    }
}