using LeetCode.链表;

namespace LeetCode.双指针;

public class Solution19删除链表的倒数第N个结点
{
    // 计算链表的长度
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head);
        int length = GetLength(head);
        ListNode cur = dummy;
        for (int i = 1; i < length - n + 1; i++)
        {
            cur = cur.next;
        }

        cur.next = cur.next.next;
        return dummy.next;
    }

    private int GetLength(ListNode head)
    {
        int length = 0;
        while (head != null)
        {
            length++;
            head = head.next;
        }

        return length;
    }

    // 栈
    public ListNode RemoveNthFromEnd1(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head);
        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode cur = dummy;
        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.next;
        }

        for (int i = 0; i < n; i++)
        {
            stack.Pop();
        }

        ListNode prev = stack.Pop();
        prev.next = prev.next.next;
        return dummy.next;
    }

    // 快慢指针
    public ListNode RemoveNthFromEnd2(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode slow = dummy, fast = dummy;
        while (n-- != 0 && fast != null)
        {
            fast = fast.next;
        }

        fast = fast.next; // fast再提前走一步，因为需要让slow指向删除节点的上一个节点

        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }

        slow.next = slow.next.next;
        return dummy.next;
    }
}