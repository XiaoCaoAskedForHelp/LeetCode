namespace LeetCode;

/// <summary>
/// 1238.循环码排序
/// </summary>
public class Solution10
{
    public IList<int> CircularPermutation(int n, int start)
    {
        IList<int> result = new List<int>();
        // 公式法
        for (int i = 0; i < 1 << n; i++)
        {
            result.Add((i >> 1) ^ i ^ start);
        }

        return result;
    }
}