namespace LeetCode;

public class Solution1
{
    public bool IsGoodArray(int[] nums)
    {
        //裴蜀定理：正整数集合{xi}的最大公约数为g，那么ai*xi相加是g的倍数
        if (nums.Length == 1 && nums[0] == 1)
        {
            return true;
        }
        int result = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            var gcd = GCD(result, nums[i]);
            if (gcd == 1)
            {
                return true;
            }
            else
            {
                result = gcd;
            }
        }

        return false;
    }

    public int GCD(int num1, int num2) {
        while (num2 != 0) {
            int temp = num1;
            num1 = num2;
            num2 = temp % num2;
        }
        return num1;
    }
}