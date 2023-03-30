namespace LeetCode;

/// <summary>
/// 2379. 得到 K 个黑块的最少涂色次数
/// </summary>
public class Solution25
{
    public int MinimumRecolors(string blocks, int k)
    {
        int len = blocks.Length;
        int res = k, temp = 0;
        for (int i = 0; i < k; i++)
        {
            if (blocks[i] == 'W')
            {
                temp++;
            }
        }

        res = Math.Min(temp, res);
        for (int i = k; i < len; i++)
        {
            temp = temp + (blocks[i] == 'W' ? 1 : 0) - (blocks[i - k] == 'W' ? 1 : 0);
            res = Math.Min(temp, res);
        }

        return res;
    }
}