using LeetCode.树;

namespace LeetCode.动态规划;

public class Solution337打家劫舍III
{
    // 后序遍历(左右根)，因为通过递归函数的返回值来做下一步计算
    // 超时
    public int Rob(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;
        // 偷父亲节点,那么子节点不能偷
        int res1 = root.val;
        if (root.left != null)
        {
            res1 += Rob(root.left.left) + Rob(root.left.right);
        }

        if (root.right != null)
        {
            res1 += Rob(root.right.left) + Rob(root.right.right);
        }

        // 不偷父亲节点，可以偷子节点
        int res2 = Rob(root.left) + Rob(root.right);
        return Math.Max(res1, res2);
    }

    // 我们计算了root的四个孙子（左右孩子的孩子）为头结点的子树的情况，又计算了root的左右孩子为头结点的子树的情况，计算左右孩子的时候其实又把孙子计算了一遍。
    // 记忆化递归,记住每个节点递归的最大值
    private Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();

    public int Rob1(TreeNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return root.val;
        if (memo.TryGetValue(root, out int val)) return val;
        // 偷父亲节点,那么子节点不能偷
        int res1 = root.val;
        if (root.left != null)
        {
            res1 += Rob(root.left.left) + Rob(root.left.right);
        }

        if (root.right != null)
        {
            res1 += Rob(root.right.left) + Rob(root.right.right);
        }

        // 不偷父亲节点，可以偷子节点
        int res2 = Rob(root.left) + Rob(root.right);
        memo.Add(root, Math.Max(res1, res2));
        return Math.Max(res1, res2);
    }

    // 动态规划
    // 动态规划其实就是使用状态转移容器来记录状态的变化，这里可以使用一个长度为2的数组，记录当前节点偷与不偷所得到的的最大金钱。
    // dp数组（dp table）以及下标的含义：下标为0记录不偷该节点所得到的的最大金钱，下标为1记录偷该节点所得到的的最大金钱
    // 优点这样就不用去找孙子节点了，因为孙子节点能偷的最大金额也记录在父亲节点中。
    // 首先明确的是使用后序遍历。 因为要通过递归函数的返回值来做下一步计算。
    // 通过递归左节点，得到左节点偷与不偷的金钱。
    // 通过递归右节点，得到右节点偷与不偷的金钱。
    public int Rob2(TreeNode root)
    {
        int[] result = RobTree(root);
        return Math.Max(result[0], result[1]);
    }

    // 树形DP就是在树上进行递归公式的推导
    int[] RobTree(TreeNode root)
    {
        if (root == null) return new int[] { 0, 0 };
        // 后续遍历，先递归
        int[] left = RobTree(root.left);
        int[] right = RobTree(root.right);
        
        // 偷cur，那子节点不能偷
        int res1 = root.val + left[0] + right[0];
        // 偷cur,那么子节点偷或者不偷都可以
        int res2 = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
        return new[] { res2, res1 };
    }
}