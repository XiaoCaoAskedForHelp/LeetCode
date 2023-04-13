namespace LeetCode.哈希表;

public class Solution2404出现最频繁的偶数元素
{
    public int MostFrequentEven(int[] nums)
    {
        // 暴力遍历
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (num % 2 == 0)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
        }

        KeyValuePair<int, int> res = new KeyValuePair<int, int>(-1, -1);
        foreach (var item in dict)
        {
            if (item.Value > res.Value || (item.Key < res.Key && item.Value >= res.Value))
            {
                res = item;
            }
        }

        return res.Key;
    }
}