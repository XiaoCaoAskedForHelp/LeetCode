namespace LeetCode.贪心;

public class Solution135分发糖果
{
    // 保证第i个小孩的糖果数量既大于左边的也大于右边的
    // 那就用两次循环保证，从1
    // 前往后遍历，保证i比i前面大，糖果就多，前后往前遍历，保证i比i后面的大，糖果就多，
    
    // 一次是从左到右遍历，只比较右边孩子评分比左边大的情况。
    // 一次是从右到左遍历，只比较左边孩子评分比右边大的情况。
    // 这样从局部最优推出了全局最优，即：相邻的孩子中，评分高的孩子获得更多的糖果。
    public int Candy(int[] ratings)
    {
        int[] cnt = new int[ratings.Length];
        for (int i = 0; i < ratings.Length; i++)
        {
            cnt[i] = 1;
        }

        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                cnt[i] = Math.Max(cnt[i - 1] + 1, cnt[i]);
            }
        }

        for (int i = ratings.Length - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                cnt[i] = Math.Max(cnt[i + 1] + 1, cnt[i]);
            }
        }

        return cnt.Sum();
    }
}