namespace LeetCode.链表;

public class Solution142_环形链表II
{
    // 哈希集合
    public ListNode DetectCycle(ListNode head)
    {
        ListNode pos = head;
        ISet<ListNode> set = new HashSet<ListNode>();
        while (pos != null)
        {
            if (set.Add(pos))
            {
                pos = pos.next;
            }
            else
            {
                return pos;
            }
        }

        return null;
    }

    // 快慢指针，通过快慢指针相遇判断是否有环，
    public ListNode DetectCycle1(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (fast == slow)
            {
                ListNode index1 = fast;
                ListNode index2 = head;
                while (index1 != index2)
                {
                    index1 = index1.next;
                    index2 = index2.next;
                }

                return index2;
            }
        }

        return null;
    }
}