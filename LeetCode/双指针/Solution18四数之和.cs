namespace LeetCode.双指针;

// 类似题目15 三数之和 ，只是在三数之和的基础上多加一层循环。
public class Solution18四数之和
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (int m = 0; m < nums.Length; m++)
        {
            // 需要考虑负数的情况，负数相加变的更小
            if (nums[m] > target && nums[m] > 0)
            {
                break;
            }

            // 对第一个数字去重
            if (m > 0 && nums[m] == nums[m - 1])
            {
                continue;
            }

            for (int n = m + 1; n < nums.Length; n++)
            {
                // 在这个地方也需要考虑钱两个数相加是否大于目标值的问题
                if (nums[m] + nums[n] > target && nums[m] + nums[n] > 0)
                {
                    break;
                }

                // 对nums[n]第二个数字去重
                if (n > m + 1 && nums[n] == nums[n - 1])
                {
                    continue;
                }

                int left = n + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    var l = nums[left];
                    var r = nums[right];
                    if (nums[m] + nums[n] + l + r > target)
                    {
                        right--;
                    }
                    else if (nums[m] + nums[n] + l + r < target)
                    {
                        left++;
                    }
                    else
                    {
                        result.Add(new List<int>() { nums[m], nums[n], l, r });
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
        }

        return result;
    }
}