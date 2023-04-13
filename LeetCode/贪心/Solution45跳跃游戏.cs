namespace LeetCode.贪心;

// 跳跃游戏
public class Solution45跳跃游戏
{
    public int Jump(int[] nums)
    {
        // 动态规划
        // var length = nums.Length;
        // int[] jump = new int[length];
        // Array.Fill(jump, Int32.MaxValue);
        // jump[0] = 0;
        // for (int i = 0; i < length; i++)
        // {
        //     for (int j = 1; j <= nums[i] && i + j < length; j++)
        //     {
        //         jump[i + j] = Math.Min(jump[i] + 1, jump[i + j]);
        //     }
        // }
        //
        // return jump[length - 1];
        
        // 贪心
        var length = nums.Length;
        if (length < 2)
        {
            return 0;
        }
        int position = 0;
        int result = 0;
        while (position+nums[position] < length - 1)
        {
            int temp = 0;
            int index = 0;
            for (int i = 1; i <= nums[position]; i++)
            {
                if (position + i + nums[position + i] > temp)
                {
                    temp = position + i + nums[position + i];
                    index = i;
                }
            }

            result++;
            position = position + index;
        }

        result++;
        return result;
    }
}