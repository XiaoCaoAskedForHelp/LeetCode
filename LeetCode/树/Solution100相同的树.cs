namespace LeetCode.树;

//Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution100相同的树
{
    // 深度优先搜索
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }
        else if (p == null || q == null)
        {
            return false;
        }
        else if (p.val != q.val)
        {
            return false;
        }
        else
        {
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }

    public bool IsSameTree2(TreeNode p, TreeNode q)
    {
        // 广度优先搜索
        if (p == null && q == null)
        {
            return true;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        // 存入p q 根节点
        queue.Enqueue(p);
        queue.Enqueue(q);
        while (queue.Any())
        {
            // 一次弹出两个结点比较
            TreeNode node1 = queue.Dequeue();
            TreeNode node2 = queue.Dequeue();
            
            // 两者都为空 继续比较下一组
            if(node1==null && node2==null)
                continue;
            
            // 判断是否相同。结构相同 值相同
            if(node1 == null || node2 == null || node1.val != node2.val)
                return false;
            
            // 每次两边孩子结点都入队
            // p 左 q左
            queue.Enqueue(node1.left);
            queue.Enqueue(node2.left);

            // p 右 q右
            queue.Enqueue(node1.right);
            queue.Enqueue(node2.right);
        }

        return true;
    }
}