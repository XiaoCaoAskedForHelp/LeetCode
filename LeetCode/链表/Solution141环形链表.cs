namespace LeetCode.链表;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution141环形链表
{
    public bool HasCycle(ListNode head)
    {
        ISet<ListNode> list = new HashSet<ListNode>();
        while (head != null)
        {
            if (!list.Add(head))
            {
                return true;
            }

            head = head.next;
        }

        return false;
    }

    public bool HasCycle1(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return false;
        }

        ListNode slow = head;
        ListNode fast = head.next;

        while (slow != fast)
        {
            if (fast == null || fast.next == null)
            {
                return false;
            }

            slow = slow.next;
            fast = fast.next.next;
        }

        return true;
    }
}