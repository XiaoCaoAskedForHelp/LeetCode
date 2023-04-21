namespace LeetCode.数学;

public class Solution66加一
{
    public int[] PlusOne(int[] digits)
    {
        int index = digits.Length - 1;
        if (digits.All(s => s.Equals(9)))
        {
            var ints = new int[index + 2];
            ints[0]++;
            return ints;
        }
        digits[index]++;
        while (digits[index] == 10)
        {
            digits[index] = 0;
            digits[--index]++;
        }
        return digits;
    }
    
    public int[] PlusOne1(int[] digits) {
        int n = digits.Length;
        for (int i = n - 1; i >= 0; --i) {
            if (digits[i] != 9) {
                ++digits[i];
                for (int j = i + 1; j < n; ++j) {
                    digits[j] = 0;
                }
                return digits;
            }
        }

        // digits 中所有的元素均为 9
        int[] ans = new int[n + 1];
        ans[0] = 1;
        return ans;
    }
}