namespace LeetCode.滑动窗口;

public class Solution904水果成篮
{
    // 滑动窗口
    public int TotalFruit(int[] fruits)
    {
        int first = 0;
        int ans = 0;
        ISet<int> set = new HashSet<int>();
        for (int i = 0; i < fruits.Length; i++)
        {
            set.Add(fruits[i]);
            if (set.Count > 2)
            {
                first = i - 1;
                while (first - 1 >= 0 && fruits[--first] == fruits[i - 1]) ;
                first++;
                set.Clear();
                set.Add(fruits[i]);
                set.Add(fruits[i - 1]);
            }

            ans = Math.Max(ans, i - first + 1);
        }

        return ans;
    }
    
    
    // 滑动窗口官方版
    public int TotalFruit1(int[] fruits)
    {
        int n = fruits.Length;
        IDictionary<int, int> cnt = new Dictionary<int, int>();
        int left = 0, ans = 0;
        for (int right = 0; right < n; right++)
        {
            cnt.TryAdd(fruits[right], 0);
            ++cnt[fruits[right]];
            while (cnt.Count > 2)
            {
                --cnt[fruits[left]];
                if (cnt[fruits[left]] == 0)
                {
                    cnt.Remove(fruits[left]);
                }

                ++left;
            }

            ans = Math.Max(ans, right - left + 1);
        }

        return ans;
    }
}