namespace LeetCode;

/// <summary>
/// 2357. 使数组中所有元素都等于零
/// </summary>
public class Solution2357使数组中所有元素都等于零
{
    public int MinimumOperations(int[] nums)
    {
        SortedSet<int> sortedSet = new SortedSet<int>();
        foreach (var num in nums)
        {
            sortedSet.Add(num);
        }

        sortedSet.Remove(0);
        return sortedSet.Count;
        
        ISet<int> set = new HashSet<int>();
        foreach (int num in nums) {
            if (num > 0) {
                set.Add(num);
            }
        }
        return set.Count;
    }
}