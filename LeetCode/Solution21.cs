namespace LeetCode;

/// <summary>
/// 1599. 经营摩天轮的最大利润
/// </summary>
public class Solution21
{
    public int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost)
    {
        int len = customers.Length;
        int people = 0, qian = 0, operation = 0, minOperations = 0, maxProfit = 0;
        for (int i = 0; i < len; i++)
        {
            int num = people + customers[i];
            if (num <= 4)
            {
                qian += (num * boardingCost - runningCost);
                if (qian > maxProfit)
                {
                    minOperations = i + 1;
                    maxProfit = qian;
                }
            }
            else
            {
                people = (num - 4);
                qian += (4 * boardingCost - runningCost);
                if (qian > maxProfit)
                {
                    minOperations = i + 1;
                    maxProfit = qian;
                }
            }
        }

        minOperations += (people / 4);
        maxProfit += ((people / 4) * (4 * boardingCost - runningCost));
        qian += ((people / 4) * (4 * boardingCost - runningCost));
        people %= 4;
        if (people > 0)
        {
            qian += (people * boardingCost - runningCost);
            if (qian > maxProfit)
            {
                minOperations++;
                maxProfit = qian;
            }
        }

        if (maxProfit <= 0)
        {
            return -1;
        }

        return minOperations;
    }
}