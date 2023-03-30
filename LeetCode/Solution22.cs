namespace LeetCode;

/// <summary>
/// 1653. 使字符串平衡的最少删除次数
/// </summary>
public class Solution22
{
    public int MinimumDeletions(string s)
    {
        // 枚举n-1种情况，其实就是划线
        int leftb = 0, righta = 0;
        foreach (char c in s)
        {
            if (c == 'a')
            {
                righta++;
            }
        }

        int res = righta;
        foreach (var c in s)
        {
            if (c == 'a')
            {
                righta--;
            }
            else
            {
                leftb++;
            }

            res = Math.Min(res, leftb + righta);
        }

        return res;
    }
}