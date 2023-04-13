namespace LeetCode.枚举;

// 982. 按位与为零的三元组
public class Soulution982按位与为零的三元组
{
    public int CountTriplets(int[] nums)
    {
        // 枚举将三重循环，变为两重 + 一重
        int[] cnt = new int[1 << 16];
        foreach (var x in nums)
        {
            foreach (var y in nums)
            {
                cnt[x & y]++;
            }
        }

        int ans = 0;
        foreach (var z in nums)
        {
            int y = z ^ 0xffff;
            for (int sub = y; sub != 0; sub = (sub - 1) & y)
            {
                ans += cnt[sub];
            }

            ans += cnt[0];
        }

        return ans;
    }
}