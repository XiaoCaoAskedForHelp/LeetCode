namespace LeetCode.动态规划;

public class Solution509斐波那契数
{
    public int Fib(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int[] res = new int[n + 1];

        res[0] = 0;
        res[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            res[i] = res[i - 1] + res[i - 2];
        }

        return res[n];
    }

    // 优化空间，需要使用的数字只是前两个数字和结果。
    public int Fib1(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int[] res = new int[2];
        res[0] = 0;
        res[1] = 1;
        // for (int i = 2; i <= n; i++)
        // {
        //     res[i % 2] = res[(i - 1) % 2] + res[(i - 2) % 2];
        // }
        //
        // return res[n % 2];

        for (int i = 2; i <= n; i++)
        {
            int sum = res[0] + res[1];
            res[0] = res[1];
            res[1] = sum;
        }

        return res[1];
    }
    
    // 递归解法
    public int Fib2(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        return Fib2(n - 1) + Fib2(n - 2);
    }
}