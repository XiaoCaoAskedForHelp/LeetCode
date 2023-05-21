namespace LeetCode.链表;

public class Solution206反转链表
{
    // 双指针法
    public ListNode ReverseList(ListNode head)
    {
        // if (head == null || head.next == null)
        // {
        //     return head;
        // }
        //
        // ListNode cur = head, next = head.next;
        // cur.next = null;
        // while (next.next != null)
        // {
        //     ListNode tmp = next.next;
        //     next.next = cur;
        //     cur = next;
        //     next = tmp;
        // }
        //
        // next.next = cur;
        //
        // return next;

        ListNode temp;
        ListNode cur = head;
        ListNode pre = null;
        while (cur != null)
        {
            temp = cur.next;
            cur.next = pre;
            pre = cur;
            cur = temp;
        }

        return pre;
    }

    //递归  从前往后翻转指针指向
    public ListNode ReverseList1(ListNode head)
    {
        return Reverse(null, head);
    }

    ListNode Reverse(ListNode pre, ListNode cur)
    {
        if (cur == null)
        {
            return pre;
        }

        ListNode temp = cur.next;
        cur.next = pre;
        // 可以和双指针法的代码进行对比，如下递归的写法，其实就是做了这两步
        // pre = cur;
        // cur = temp;
        return Reverse(cur, temp);
    }
    
    //递归 从后往前翻转指针指向
    public ListNode ReverseList2(ListNode head)
    {
        // 边缘条件判断
        if (head == null || head.next == null)
        {
            return head;
        }

        // 递归调用，翻转第二个节点开始往后的链表
        ListNode last = ReverseList2(head.next);
        // 翻转头结点与第二个结点的指向
        head.next.next = head;
        // 此时的 head 节点为尾节点，next 需要指向 NULL,否则递归将覆盖
        head.next = null;
        return last;
    }
}