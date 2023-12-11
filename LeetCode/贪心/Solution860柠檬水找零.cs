namespace LeetCode.贪心;

public class Solution860柠檬水找零
{
    // 模拟进出账，比较的特殊的20元，如果有十元就先用十元找零
    public bool LemonadeChange(int[] bills)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(5, 0);
        dict.Add(10, 0);
        dict.Add(20, 0);
        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 5)
            {
                dict[5]++;
            }
            else if (bills[i] == 10)
            {
                if (dict[5] > 0)
                {
                    dict[5]--;
                    dict[10]++;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (dict[10] > 0 && dict[5] > 0)
                {
                    dict[5]--;
                    dict[10]--;
                    dict[20]++;
                }
                else if (dict[5] >= 3)
                {
                    dict[5] -= 3;
                    dict[20]++;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool LemonadeChange1(int[] bills)
    {
        int five = 0;
        int ten = 0;
        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 5)
            {
                five++;
            }
            else if (bills[i] == 10)
            {
                five--;
                ten++;
            }
            else if (bills[i] == 20)
            {
                if (ten > 0)
                {
                    ten--;
                    five--;
                }
                else
                {
                    five -= 3;
                }
            }
            // 减完一起判断这样代码更简洁
            if (five < 0 || ten < 0) return false;
        }

        return true;
    }
}