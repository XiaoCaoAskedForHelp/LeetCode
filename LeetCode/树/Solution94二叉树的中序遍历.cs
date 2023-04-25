using System.Reflection.Metadata;

namespace LeetCode.树;

public class Solution94二叉树的中序遍历
{
    // 递归
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> res = new List<int>();
        inorder(root, res);
        return res;
    }

    public void inorder(TreeNode root, List<int> res)
    {
        if (root == null)
        {
            return;
        }

        inorder(root.left, res);
        res.Add(root.val);
        inorder(root.right, res);
    }

    //迭代
    public IList<int> InorderTraversal2(TreeNode root)
    {
        List<int> res = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while (root != null || stack.Any())
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            res.Add(root.val);
            root = root.right;
        }

        return res;
    }
    
    //Morris 遍历算法是另一种遍历二叉树的方法，它能将非递归的中序遍历空间复杂度降为 O(1)
    public IList<int> InorderTraversal3(TreeNode root)
    {
        List<int> res = new List<int>();
        TreeNode predecessor = null;

        while (root != null) {
            if (root.left != null) {
                // predecessor 节点就是当前 root 节点向左走一步，然后一直向右走至无法走为止
                predecessor = root.left;
                while (predecessor.right != null && predecessor.right != root) {
                    predecessor = predecessor.right;
                }
                
                // 让 predecessor 的右指针指向 root，继续遍历左子树
                if (predecessor.right == null) {
                    predecessor.right = root;
                    root = root.left;
                }
                // 说明左子树已经访问完了，我们需要断开链接
                else {
                    res.Add(root.val);
                    predecessor.right = null;
                    root = root.right;
                }
            }
            // 如果没有左孩子，则直接访问右孩子
            else {
                res.Add(root.val);
                root = root.right;
            }
        }
        return res;
    }
}