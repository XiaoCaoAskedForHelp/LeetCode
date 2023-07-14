using LeetCode.链表;

namespace LeetCode.双指针;

public class Solution面试题0207链表相交
{
    // 哈希集合
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ISet<ListNode> set = new HashSet<ListNode>();
        ListNode temp = headA;
        while (temp != null)
        {
            set.Add(temp);
            temp = temp.next;
        }

        temp = headB;
        while (temp != null)
        {
            if (!set.Add(temp))
            {
                return temp;
            }

            temp = temp.next;
        }

        return null;
    }

    // 双指针  包含数学思想
    // headA链表长度a， headB链表长度b，假设node为第一个公共结点，那么到node前两链表分别为a-c和b-c个结点
    // 本算法遍历headA，在遍历headB，走到node为a+(b-c)，遍历headB，在遍历headA，走到node为b+(a-c)
    // 当然也可能只需要遍历先遍历的链表，如链表长度相等，在某个结点相交
    // 循环结束条件：找到公共结点或者遍历到最后的null值
    public ListNode GetIntersectionNode1(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null)
        {
            return null;
        }

        ListNode pA = headA, pB = headB;
        while (pA != pB)
        {
            pA = pA == null ? headB : pA.next;
            pB = pB == null ? headA : pB.next;
        }

        return pA;
    }

    // 双指针， 从第一个公共结点到尾部长度相等，所以我们可以将尾部对其进行遍历。
    public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
    {
        ListNode curA = headA;
        ListNode curB = headB;
        int lenA = 0, lenB = 0;
        while (curA != null)
        {
            lenA++;
            curA = curA.next;
        }

        while (curB != null)
        {
            lenB++;
            curB = curB.next;
        }

        curA = headA;
        curB = headB;
        // 让curA为最长链表的头，lenA为其长度
        if (lenB > lenA)
        {
            //1. swap (lenA, lenB);
            int tmpLen = lenA;
            lenA = lenB;
            lenB = tmpLen;
            //2. swap (curA, curB);
            ListNode tmpNode = curA;
            curA = curB;
            curB = tmpNode;
        }

        // 求长度差
        int gap = lenA - lenB;
        // 让curA和curB在同一起点上（末尾位置对齐）
        while (gap-- > 0)
        {
            curA = curA.next;
        }

        // 遍历curA 和 curB，遇到相同则直接返回
        while (curA != null)
        {
            if (curA == curB)
            {
                return curA;
            }

            curA = curA.next;
            curB = curB.next;
        }

        return null;
    }
}