namespace LeetCode.太简单;

public class Solution118杨辉三角
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < numRows; i++)
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
                    list.Add(res[i-1][j-1] + res[i-1][j]);
                }
            }
            res.Add(list);
        }

        return res;
    }
}