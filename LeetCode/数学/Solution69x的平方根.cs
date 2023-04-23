namespace LeetCode;

public class Solution69x的平方根
{
    public int MySqrt(int x) {
        for (long i = 0; i <= x/2 + 2; i++)
        {
            if (i * i > x)
            {
                return (int)(i - 1);
            }
        }

        return 0;
    }
    
    //写成幂的形式,再使用自然对数 e 进行换底
    public int mySqrt2(int x) {
        if (x == 0) {
            return 0;
        }
        int ans = (int) Math.Exp(0.5 * Math.Log(x));
        return (long) (ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
    }
    
    //二分查找
    public int mySqrt3(int x)
    {
        int l = 0, r = x/2 + 1, ans = -1;
        while (l <= r)
        {
            int mid = (l + r) / 2;
            if ((long)mid * mid <= x)
            {
                ans = mid;
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return ans;
    }
}