namespace LeetCode.双指针;

public class Solution15三数之和
{
    // 哈希解法  通过两层循环确定a和b的值，然后在通过哈希法确定第三个数字0-(a+b)
    // 三元组 不能重复，所以需要考虑去重。去重是很浪费时间的
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            // 如果第一个数就大于0，不可能成立.
            if (nums[i] > 0)
            {
                break;
            }

            // 元素a去重，不能和之前数字一样
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            ISet<int> set = new HashSet<int>();
            for (int j = i + 1; j < nums.Length; j++)
            {
                // 这样写对于  1 1 2 2 3 4 5 的情况，如果 i = 0，j = 1，那么这种情况不会被统计。
                // 如需将112这种情况统计进入，那些需要将j位置和两个位置进行笔记，只有和钱两个位置的数字都相同时，才不会被计入。
                // if (j > i + 1 && nums[j] == nums[j - 1])
                // {
                //     continue;
                // }

                // 对b进行去重
                if (j > i + 2 && nums[j] == nums[j - 1] && nums[j - 1] == nums[j - 2])
                {
                    continue;
                }

                int c = 0 - (nums[i] + nums[j]);

                // 通过下面的方法对c进行去重，b和c是在a确定的前提下是相当于互补的，
                // 所以可以将b加入set集合中，相当于就是把这一种情况纳入考虑范围
                // 当循环b的值变为c时，即可以在nums数组中找到，既保证了c在nums中，又有去重的功效。
                if (set.Contains(c))
                {
                    // 最后的结果中b和c的位置是互换的
                    result.Add(new List<int>() { nums[i], nums[j], c });
                    set.Remove(c); // 三元组元素c去重
                }
                else
                {
                    set.Add(nums[j]);
                }
            }
        }

        return result;
    }

    // 排序 + 双指针
    public IList<IList<int>> ThreeSum1(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] > 0)
            {
                break;
            }
            
            // 对a去重
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                var l = nums[left];
                var r = nums[right];
                if (nums[i] + l + r > 0)
                {
                    right--;
                }
                else if (nums[i] + l + r < 0)
                {
                    left++;
                }
                else
                {
                    result.Add(new List<int>() { nums[i], l, r });
                    // 对b和c进行去重，在找到第一个符合条件的结果后，就能将b和c重复的都去掉了。
                    while (left < right && nums[left] == l)
                    {
                        left++;
                    }

                    while (left < right && r == nums[right])
                    {
                        right--;
                    }
                }
            }
        }

        return result;
    }
}