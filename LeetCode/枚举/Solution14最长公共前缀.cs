using System.Text;

namespace LeetCode.枚举;

public class Solution14最长公共前缀
{
    public string LongestCommonPrefix(string[] strs)
    {
        int size = strs.Length;
        int len = Int32.MaxValue;
        foreach (var str in strs)
        {
            if (str.Length < len)
            {
                len = str.Length;
            }
        }

        StringBuilder res = new StringBuilder();
        for (int i = 0; i < len; i++)
        {
            char s = strs[0][i];
            bool flag = true;
            for (int j = 1; j < size; j++)
            {
                if (s != strs[j][i])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                res.Append(strs[0][i]);
            }
            else
            {
                break;
            }
        }

        return res.ToString();
    }
    
    
    public string LongestCommonPrefix2(string[] strs)
    {
        if (strs == null || strs.Length == 0) {
            return "";
        }
        int length = strs[0].Length;
        int count = strs.Length;
        for (int i = 0; i < length; i++) {
            char c = strs[0][i];
            for (int j = 1; j < count; j++) {
                if (i == strs[j].Length || strs[j][i] != c) {
                    return strs[0].Substring(0, i);
                }
            }
        }
        return strs[0];
    }
}