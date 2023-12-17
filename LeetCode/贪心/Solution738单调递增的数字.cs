namespace LeetCode.贪心;

public class Solution738单调递增的数字
{
    // 超过时间限制
    public int MonotoneIncreasingDigits(int n)
    {
        while (n > 0)
        {
            string str = n.ToString();
            bool flag = true;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] > str[i])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                return n;
            }

            n--;
        }

        return 0;
    }

    // 98，一旦出现strNum[i - 1] > strNum[i]的情况（非单调递增），首先想让strNum[i - 1]--，然后strNum[i]给为9，这样这个整数就是89，即小于98的最大的单调递增整数。
    
    // 数字：332，从前向后遍历的话，那么就把变成了329，此时2又小于了第一位的3了，真正的结果应该是299。
    //
    // 那么从后向前遍历，就可以重复利用上次比较得出的结果了，从后向前遍历332的数值变化为：332 -> 329 -> 299
    public int MonotoneIncreasingDigits1(int n)
    {
        char[] strNum = n.ToString().ToCharArray();
        // flag用来标记赋值9从哪里开始
        int flag = strNum.Length;
        for (int i = strNum.Length - 1; i > 0; i--)
        {
            if (strNum[i - 1] > strNum[i])
            {
                flag = i;
                strNum[i - 1]--;
            }
        }

        for (int i = flag; i < strNum.Length; i++)
        {
            strNum[i] = '9';
        }

        return int.Parse(new string(strNum));
    }
}