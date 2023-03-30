namespace LeetCode;

/// <summary>
/// 2363. 合并相似的物品
/// </summary>
public class Solution16
{
    public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
    {
        // 哈希表
        SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();
        foreach (var item in items1)
        {
            dictionary.TryAdd(item[0], 0);
            dictionary[item[0]] += item[1];
        }

        foreach (var item in items2)
        {
            dictionary.TryAdd(item[0], 0);
            dictionary[item[0]] += item[1];
        }

        IList<IList<int>> res = new List<IList<int>>();
        foreach (KeyValuePair<int, int> kv in dictionary) {
            int k = kv.Key, v = kv.Value;
            res.Add(new List<int>{k, v});
        }
        return res;
    }
}