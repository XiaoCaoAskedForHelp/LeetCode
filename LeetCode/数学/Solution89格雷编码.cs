namespace LeetCode.数学;

/// <summary>
/// 89.格雷编码
/// </summary>
public class Solution89格雷编码
{
    public IList<int> GrayCode(int n)
    {
        // 归纳法
        // (n+1)位格雷码中的前2n个码字等于n位格雷码的码字，按顺序书写，加前缀0
        // (n+1)位格雷码中的后2n个码字等于n位格雷码的码字，按逆序书写，加前缀1
        // n+1位格雷码的集合 = n位格雷码集合(顺序)加前缀0 + n位格雷码集合(逆序)加前缀1
        // IList<int> result = new List<int>();
        // result.Add(0);
        // for (int i = 1; i <= n; i++)
        // {
        //     for (int j = result.Count - 1; j >= 0; j--)
        //     {
        //         result.Add(result[j] | (1 << (i - 1)));
        //     }
        // }
        //
        // return result;

        //https://baike.baidu.com/item/%E6%A0%BC%E9%9B%B7%E7%A0%81
        //从对应的n位二进制码字中直接得到n位格雷码码字
        IList<int> result = new List<int>();
        for (int i = 0; i < 1 << n; i++)
        {
            result.Add((i >> 1) ^ i);
        }

        return result;
    }
}