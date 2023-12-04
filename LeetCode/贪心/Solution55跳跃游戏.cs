namespace LeetCode.贪心;

public class Solution55跳跃游戏
{
    public bool CanJump(int[] nums)
    {
        bool[] arrive = new bool[nums.Length];
        arrive[0] = true;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = 1; j <= nums[i]; j++)
            {
                if (i + j < nums.Length && arrive[i])
                {
                    arrive[i + j] = true;
                }
            }
        }

        if (arrive[nums.Length - 1])
        {
            return true;
        }

        return false;
    }

    public bool CanJump1(int[] nums)
    {
        bool[] arrive = new bool[nums.Length];
        arrive[0] = true;
        int index = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (arrive[i])
            {
                int idx = index;
                index = Math.Max(i + nums[i], index);
                if (index >= nums.Length - 1)
                {
                    return true;
                }

                for (int j = idx; j <= index; j++)
                {
                    if (arrive[i])
                    {
                        arrive[j] = true;
                    }
                }
            }
        }
        
        if (arrive[nums.Length - 1])
        {
            return true;
        }

        return false;
    }
    
    
    //其实跳几步无所谓，关键在于可跳的覆盖范围！
    public bool CanJump2(int[] nums)
    {
        int cover = 0;
        if (nums.Length == 1) return true;
        for (int i = 0; i <= cover; i++)
        {
            cover = Math.Max(i + nums[i], cover);
            if (cover >= nums.Length - 1) return true;
        }

        return false;
    }
}