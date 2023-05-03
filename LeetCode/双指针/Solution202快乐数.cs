namespace LeetCode.双指针;

public class Solution202快乐数
{
    private int getNext(int n)
    {
        int total = 0;
        while (n > 0)
        {
            int d = n % 10;
            n /= 10;
            total += d * d;
        }

        return total;
    }

    // 集合检验循环
    public bool IsHappy(int n)
    {
        HashSet<int> set = new HashSet<int>();
        while (n != 1 && !set.Contains(n))
        {
            set.Add(n);
            n = getNext(n);
        }

        return n == 1;
    }
    
    // 快慢指针
    public bool IsHappy1(int n)
    {
        int slow = n;
        int fast = getNext(n);
        while (fast != 1 && slow != fast)
        {
            slow = getNext(slow);
            fast = getNext(getNext(fast));
        }

        return fast == 1;
    }
    
    // 数学
    //只有一个循环：4→16→37→58→89→145→42→20→4
    public bool IsHappy2(int n)
    {
        HashSet<int> cycleMembers =
            new HashSet<int>(new int[8] {4, 16, 37, 58, 89, 145, 42, 20});
        while (n != 1 && !cycleMembers.Contains(n))
        {
            n = getNext(n);
        }

        return n == 1;
    }
}