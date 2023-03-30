using System.Formats.Asn1;

namespace LeetCode;

/// <summary>
/// 1590. 使数组和能被 P 整除
/// </summary>
public class Solution26
{
    public int MinSubarray(int[] nums, int p)
    {
        //使数组能被p整除，也就是sum%p==0，所以我们关注每个数对p的余数
        //由于(a+b)%p==a%p+b%p，遍历一遍，可以求出余数作为目标target
        //我们要求的就是片段和%p==target的最短子数组。 可以使用前缀和+哈希表实现。
        int target = 0;
        foreach (var num in nums)
        {
            target = (target + num) % p;
        }

        if (target == 0)//整除，直接返回
        {
            return 0;
        }

        Dictionary<int, int> dict = new Dictionary<int, int>();
        int sum = 0, res = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            if (!dict.ContainsKey(sum))
            {
                dict.Add(sum,i);
            }
            else
            {
                dict[sum] = i;
            }
            sum = (sum + nums[i]) % p;
            // 如果前缀和的余数和target差值能在dict种找到，那么我们就找到了那一片段
            if (dict.ContainsKey((sum - target + p) % p))
            {
                res = Math.Min(res, i - dict[(sum - target + p) % p] + 1);
            }
        }

        return res == nums.Length ? -1 : res;
    }
    
    public int MinSubarray2(int[] nums, int p) {
        int x = 0;
        foreach (int num in nums) {
            x = (x + num) % p;
        }
        if (x == 0) {
            return 0;
        }
        IDictionary<int, int> index = new Dictionary<int, int>();
        int y = 0, res = nums.Length;
        for (int i = 0; i < nums.Length; i++) {
            // f[i] mod p = y，因此哈希表记录 y 对应的下标为 i
            if (!index.ContainsKey(y)) {
                index.Add(y, i);
            } else {
                index[y] = i;
            }
            y = (y + nums[i]) % p;
            if (index.ContainsKey((y - x + p) % p)) {
                res = Math.Min(res, i - index[(y - x + p) % p] + 1);
            }
        }
        return res == nums.Length ? -1 : res;
    }
}