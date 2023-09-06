namespace LeetCode.动态规划;

public class Solution96不同的二叉搜索树
{
    public int NumTrees(int n)
    {
        //一个n个节点二叉搜索树比n-1个节点的二叉搜索树就差一个节点，我们只需要将n-1个节点放在头结点的两边就可以
        // 所以总数量=dp[i] += dp[j - 1] * dp[i - j]; 将所有左节点从0到n-1数量的情况相加，就是总数
        int[] dp = new int[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                dp[i] += (dp[j] * dp[i - j - 1]);
            }
        }

        return dp[n];
    }
}