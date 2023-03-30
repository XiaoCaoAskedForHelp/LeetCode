﻿using System.ComponentModel.Design;

namespace LeetCode;

public class Solution15
{
    public int MovesToMakeZigzag(int[] nums)
    {
        return Math.Min(Help(nums,0), Help(nums,1));
    }

    private int Help(int[] nums, int pos)
    {
        int res = 0;
        for (int i = pos; i < nums.Length; i += 2) {
            int a = 0;
            if (i - 1 >= 0) {
                a = Math.Max(a, nums[i] - nums[i - 1] + 1);
            }
            if (i + 1 < nums.Length) {
                a = Math.Max(a, nums[i] - nums[i + 1] + 1);
            }
            res += a;
        }
        return res;
    }
}