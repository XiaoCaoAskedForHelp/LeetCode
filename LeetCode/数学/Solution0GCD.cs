namespace LeetCode.数学;

public class Solution0GCD
{
    // 辗转相处法
    public int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }

        return a;
    }

    public int Gcd1(int a, int b)
    {
        if (b == 0) return a;
        return Gcd(b, a % b);
    }

    // 扩展欧几里得算法
    // 辗转相除法 （a,b） = sa + tb  可额外求出一组整数解s,t，这就是求解不定方程的过程
    public Tuple<int, int, int> ExtendedGcd(int a, int b)
    {
        int x0 = 1, x1 = 0, y0 = 0, y1 = 1;
        while (b != 0)
        {
            int q = a / b; //求出辗转相除后商
            int r = a - b * q; // 求出辗转相除后余数

            int x2 = x0 - q * x1;
            int y2 = y0 - q * y1;

            a = b;
            b = r;

            x0 = x1;
            y0 = y1;

            x1 = x2;
            y1 = y2;
        }

        return new Tuple<int, int, int>(a, x0, y0);
    }

    // 通过辗转相除法的一步步相除，最后在一步步反代就能得代一组解
    public void ExtendedGcd1(int a, int b, out int gcd, out int x0, out int y0)
    {
        if (b == 0)
        {
            gcd = a; // 递归代最后一次求出最大公约数
            x0 = 1;
            y0 = 0;
        }
        else
        {
            ExtendedGcd1(b, a % b, out gcd, out x0, out y0);
            int temp = x0;
            x0 = y0;
            y0 = temp - (a / b) * y0;
            // Console.WriteLine("s 值: " + x0);
            // Console.WriteLine("t 值: " + y0);
        }
    }

    // 任意二元一次方程的通解
    public void GeneralSolution(int a, int b, int c)
    {
        int gcd, s, t;


        int tempa = Math.Abs(a);
        int tempb = Math.Abs(b);

        new Solution0GCD().ExtendedGcd1(tempa, tempb, out gcd, out s, out t);

        string f1 = s > 0 && a < 0 ? "-" : "";
        string f2 = t > 0 && b < 0 ? "-" : "";

        Console.WriteLine(
            $"此二元一次方程组的通解为x= {f1}{s} * {c / gcd} - ({b / gcd} * t),y= {f2}{t} * {c / gcd} + ({a / gcd} * t)");
    }

    // 由古希腊厄拉多塞提出的算法（又称埃氏筛法），可以筛选出给定整数N以内的质数。
    // 给定一个数 n，从 2 开始依次将 √n以内的素数的倍数标记为合数
    // 标记完成后，剩余未被标记的数为素数（从 2 开始）
    public void countPrimes(int n)
    {
        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        // 从 2 开始，逐个标记非质数
        for (int i = 2; i * i <= n; i++)
        {
            if (isPrime[i] == true)
            {
                // 从 2 开始，逐个标记非质数
                // 避免重复标记：如果从小于 p 的倍数开始标记，会导致重复的标记操作。例如，如果从 2 的倍数开始，然后从 3 的倍数开始，那么 6 的倍数将被标记两次。
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        // 打印所有质数
        Console.WriteLine("质数列表：");
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}