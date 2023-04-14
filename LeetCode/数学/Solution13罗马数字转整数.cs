namespace LeetCode.数学;

public class Solution13罗马数字转整数
{
    public int RomanToInt(string s)
    {
        int res = 0;
        int len = s.Length;
        for (int i = 0; i < len; i++)
        {
            if (s[i] == 'V')
            {
                res += 5;
                continue;
            }
            if (s[i] == 'L')
            {
                res += 50;
                continue;
            }
            if (s[i] == 'D')
            {
                res += 500;
                continue;
            }
            if (s[i] == 'M')
            {
                res += 1000;
                continue;
            }
            if (s[i] == 'I')
            {
                if (i + 1 < len && s[i + 1] == 'V')
                {
                    res += 4;
                    i++;
                    continue;
                }

                if (i + 1 < len && s[i + 1] == 'X')
                {
                    res += 9;
                    i++;
                    continue;
                }

                res += 1;
                continue;
            }

            if (s[i] == 'X')
            {
                if (i + 1 < len && s[i + 1] == 'L')
                {
                    res += 40;
                    i++;
                    continue;
                }

                if (i + 1 < len && s[i + 1] == 'C')
                {
                    res += 90;
                    i++;
                    continue;
                }

                res += 10;
                continue;
            }

            if (s[i] == 'C')
            {
                if (i + 1 < len && s[i + 1] == 'D' )
                {
                    res += 400;
                    i++;
                    continue;
                }

                if (i + 1 < len && s[i + 1] == 'M')
                {
                    res += 900;
                    i++;
                    continue;
                }

                res += 100;
                continue;
            }
        }

        return res;
    }

    Dictionary<char, int> symbolValues = new Dictionary<char, int> {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };
    
    public int RomanToInt2(string s)
    {
        int ans = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            int value = symbolValues[s[i]];
            if (i < n - 1 && value < symbolValues[s[i + 1]]) {
                ans -= value;
            } else {
                ans += value;
            }
        }

        return ans;
    }
}