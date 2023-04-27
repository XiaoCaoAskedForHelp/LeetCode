namespace LeetCode.数组;

public class Solution119杨辉三角
{
    public IList<int> GetRow(int rowIndex)
    {
        IList<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i <= rowIndex; i++)
        {
            IList<int> list = new List<int>();
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    list.Add(1);
                }
                else
                {
                    list.Add(res[i - 1][j - 1] + res[i - 1][j]);
                }
            }

            res.Add(list);
        }

        return res[rowIndex];
    }

    // 优化滚动数组
    public IList<int> GetRow1(int rowIndex)
    {
        IList<int> pre = new List<int>();
        for (int i = 0; i <= rowIndex; i++)
        {
            IList<int> cur = new List<int>();
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    cur.Add(1);
                }
                else
                {
                    cur.Add(pre[j - 1] + pre[j]);
                }
            }

            pre = cur;
        }

        return pre;
    }

    // 优化只用一个数组
    public IList<int> GetRow2(int rowIndex)
    {
        IList<int> res = new List<int>();
        res.Add(1);
        for (int i = 1; i <= rowIndex; i++)
        {
            res.Add(0);
            for (int j = i; j > 0; j--)
            {
                res[j] = (res[j - 1] + res[j]);
            }
        }

        return res;
    }


    // 线性递推
    public IList<int> GetRow3(int rowIndex)
    {
        IList<int> res = new List<int>();
        res.Add(1);
        for (int i = 1; i <= rowIndex; i++)
        {
            res.Add((int)((long)res[i - 1] * (rowIndex - i + 1) / i));
        }

        return res;
    }
}