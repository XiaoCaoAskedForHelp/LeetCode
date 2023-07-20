using System.Collections;

namespace LeetCode.队列;

public class Solution347前_K_个高频元素
{
    // 1.要统计元素出现频率
    // 2.对频率排序
    // 3.找出前K个高频元素
    //首先统计元素出现的频率，这一类的问题可以使用map来进行统计。
    //然后是对频率进行排序，这里我们可以使用一种 容器适配器就是优先级队列。
    // 优先级队列实际上就是堆，这边我们要统计前k个元素，小顶堆每次弹出最小的元素，所以剩下的就是k个最大的元素
    public int[] TopKFrequent(int[] nums, int k)
    {
        // 哈希表,统计次数
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]++;
            }
            else
            {
                dict.Add(nums[i], 1);
            }
        }

        // 优先队列，从小到大排序
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        foreach (var item in dict)
        {
            pq.Enqueue(item.Key, item.Value);
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }

        // 数组倒装，让最高的在最前面
        int[] res = new int[k];
        for (int i = k - 1; i >= 0; i--)
        {
            res[i] = pq.Dequeue();
        }

        return res;
    }
}