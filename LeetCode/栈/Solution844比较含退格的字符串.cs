using System.Text;

namespace LeetCode.栈;

public class Solution844比较含退格的字符串
{
    //如果它是退格符，那么我们将栈顶弹出；
    //如果它是普通字符，那么我们将其压入栈中。
    public bool BackspaceCompare(string s, string t)
    {
        return Convert(s).Equals(Convert(t));
    }

    public string Convert(string str)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];
            if (ch != '#')
            {
                builder.Append(ch);
            }
            else
            {
                if (builder.Length > 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
            }
        }

        return builder.ToString();
    }

    //双指针
    public bool BackspaceCompare2(string s, string t)
    {
        int i = s.Length - 1, j = t.Length - 1;
        int skipS = 0, skipT = 0;
        while (i >= 0 || j >= 0)
        {
            while (i >= 0)
            {
                if (s[i] == '#')
                {
                    skipS++;
                    i--;
                }else if (skipS > 0)
                {
                    skipS--;
                    i--;
                }
                else
                {
                    break;
                }
            }

            while (j >= 0)
            {
                if (t[j] == '#')
                {
                    skipT++;
                    j--;
                }
                else if (skipT > 0)
                {
                    skipT--;
                    j--;
                }
                else
                {
                    break;
                }
            }

            if (i >= 0 && j >= 0)
            {
                if (s[i] != t[j])
                {
                    return false;
                }
            }
            else
            {
                if (i >= 0 || j >= 0)
                {
                    return false;
                }
            }

            i--;
            j--;
        }

        return true;
    }
}