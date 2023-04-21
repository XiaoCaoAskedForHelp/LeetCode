namespace LeetCode.太简单;

public class Solution2413最小偶倍数
{
    public int SmallestEvenMultiple(int n) {
        if (n % 2 == 0)
        {
            return n;
        }
        else
        {
            return 2 * n;
        }
    }
    
    // 当 nnn 为奇数时，答案为 2n，当 nnn 为偶数时，答案为 n。
    public int SmallestEvenMultiple2(int n) {
        return (n % 2 + 1) * n;
    }
    
    // n 为奇数时，n 左移一位，否则不变。
    public int SmallestEvenMultiple3(int n)
    {
        return n << (n & 1);
    }
}