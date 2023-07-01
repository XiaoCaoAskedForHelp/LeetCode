namespace LeetCode.哈希表;

/// <summary>
/// 1. 两数之和
/// </summary>
public class Solution1两数之和
{
    public int[] TwoSum(int[] nums, int target)
    {
        //暴力枚举
        // int n = nums.Length;
        // for (int i = 0; i < n; i++)
        // {
        //     for (int j = i + 1; j < n; j++)
        //     {
        //         if (nums[i] + nums[j] == target)
        //         {
        //             return new int[] { i, j };
        //         }
        //     }
        // }
        //
        // return new int[0];

        //哈希表 将寻找target-nums[i]这个循环降为o(1)
        
        // 哈希表不需要开始就创建，一般互补的东西在可以在第一次加入哈希表，在第二次就可以查找出来。
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(target - nums[i]))
            {
                return new int[] { dictionary[target - nums[i]],i };
            }
            dictionary.TryAdd(nums[i],i);
        }

        return new int[0];
    }
}