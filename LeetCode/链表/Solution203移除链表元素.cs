namespace LeetCode.链表;

public class Solution203移除链表元素
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        // 递归
        // 链表的定义具有递归的性质，因此链表题目常可以用递归的方法求解。
        public ListNode RemoveElements(ListNode head, int val)
        {

            if (head == null)
            {
                return head;
            }

            head.next = RemoveElements(head.next, val);
            return head.val == val ? head.next : head;
        }
        
        // 迭代遍历
        public ListNode RemoveElements1(ListNode head, int val)
        {
            ListNode node = new ListNode(0);
            node.next = head;
            ListNode temp = node;
            while (temp.next != null)
            {
                if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }

            return node.next;
        }
    }
}