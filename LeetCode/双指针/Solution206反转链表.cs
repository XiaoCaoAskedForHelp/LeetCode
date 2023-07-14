using LeetCode.链表;

namespace LeetCode.双指针;

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

    // 迭代方法： 增加虚拟头节点，使用头插法实现链表的翻转
    public ListNode ReverseList3(ListNode head)
    {
        ListNode dumyHead = new ListNode(-1);
        dumyHead.next = null;
        ListNode cur = head;
        while (cur != null)
        {
            ListNode temp = cur.next;
            // 将原链表的中的元素，插入头节点和下一个节点之间
            cur.next = dumyHead.next;
            dumyHead.next = cur;
            cur = temp;
        }

        return dumyHead.next;
    }

    //使用栈解决反转链表的问题
    public ListNode ReverseList4(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode cur = head;
        while (cur != null)
        {
            stack.Push(cur);
            cur = cur.next;
        }

        // 创建一个虚拟头节点
        ListNode phead = new ListNode(0);
        cur = phead;
        while (stack.Any())
        {
            ListNode node = stack.Pop();
            cur.next = node;
            cur = cur.next;
        }

        // 最后一个元素的next要复制为空
        cur.next = null;
        return phead.next;
    }
}