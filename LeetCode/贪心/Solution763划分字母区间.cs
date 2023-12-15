namespace LeetCode.贪心;

public class Solution763划分字母区间
{
    public IList<int> PartitionLabels(string s)
    {
        IList<int> res = new List<int>();
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.TryAdd(s[i], i))
            {
                dict[s[i]] = i;
            }
        }
        
        int max_idx = 0;
        while (max_idx < s.Length)
        {
            int cnt = 0;
            for (int i = max_idx; i <= max_idx; i++)
            {
                max_idx = Math.Max(dict[s[i]], max_idx);
                cnt++;
            }
            res.Add(cnt);
            max_idx++;
        }

        return res;
    }

    public IList<int> PartitionLabels1(string s)
    {
        List<int> list = new List<int>();
        int[] edge = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            edge[s[i] - 'a'] = i;   // 统计每个出现的最远边界
        }

        int idx = 0;
        int last = -1;
        for (int i = 0; i < s.Length; i++)
        {
            idx = Math.Max(idx, edge[s[i] - 'a']);   // 找出重叠的最远边界
            if (i == idx)
            {
                list.Add(i - last);
                last = i;
            }
        }

        return list;
    }

}