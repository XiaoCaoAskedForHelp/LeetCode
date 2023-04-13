namespace LeetCode.哈希表;

public class Solution2341数组能形成多少数对
{
    public int[] NumberOfPairs(int[] nums)
    {
        // 哈希表
        // Dictionary<int, int> pair = new Dictionary<int, int>();
        // for (var i = 0; i < nums.Length; i++)
        // {
        //     if (pair.ContainsKey(nums[i]))
        //     {
        //         pair[nums[i]]++;
        //     }
        //     else
        //     {
        //         pair.Add(nums[i], 1);
        //     }
        // }
        //
        // int pnum = 0;
        // int lnum = 0;
        // foreach (var item in pair)
        // {
        //     pnum += (item.Value / 2);
        //     lnum += (item.Value % 2);
        // }
        //
        // return new [] { pnum, lnum };

        IDictionary<int, bool> pair = new Dictionary<int, bool>();
        int res = 0;
        foreach (var num in nums)
        {
            if (pair.ContainsKey(num))
            {
                pair[num] = !pair[num];
            }
            else
            {
                pair.Add(num,true);
            }

            if (!pair[num])
            {
                res++;
            }
        }

        return new[] { res, nums.Length - 2 * res };
    }
}