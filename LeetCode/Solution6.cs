namespace LeetCode;

public class Solution6
{
    public string BestHand(int[] ranks, char[] suits)
    {
        // bool flag = true;
        // for (var i = 1; i < suits.Length; i++)
        // {
        //     if (suits[i] != suits[i - 1])
        //     {
        //         flag = false;
        //         break;
        //     }
        // }
        //
        // if (flag)
        // {
        //     return "Flush";
        // }
        //
        // Dictionary<int, int> dict = new Dictionary<int, int>();
        // foreach (var rank in ranks)
        // {
        //     if (dict.ContainsKey(rank))
        //     {
        //         dict[rank]++;
        //     }
        //     else
        //     {
        //         dict.Add(rank,1);
        //     }
        // }
        //
        // int max = 0;
        // for (int i = 1; i <= 13; i++)
        // {
        //     if (dict.ContainsKey(i))
        //     {
        //         if (dict[i] > max)
        //         {
        //             max = dict[i];
        //         }
        //     }
        // }
        //
        // return max >= 3 ? "Three of a Kind" : (max == 2 ? "Pair" : "High Card");

        ISet<char> suitSet = new HashSet<char>();
        foreach (var suit in suits)
        {
            suitSet.Add(suit);
        }

        if (suitSet.Count == 1)
        {
            return "Flush";
        }

        IDictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var rank in ranks)
        {
            dict.TryAdd(rank, 0);
            dict[rank]++;
        }

        if (dict.Count == 5)
        {
            return "High Card";
        }

        foreach (var item in dict)
        {
            if (item.Value > 2)
            {
                return "Three of a Kind";
            }
        }

        return "Pair";
    }
}