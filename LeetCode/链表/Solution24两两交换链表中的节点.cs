namespace LeetCode.链表;

public class Solution24两两交换链表中的节点
{
    // 虚拟头节点迭代
    public ListNode SwapPairs(ListNode head)
    {
        ListNode dumphead = new ListNode(-1);
        dumphead.next = head;
        ListNode cur = dumphead;
        ListNode temp; // 临时节点，保存两个节点后面的节点
        ListNode firstnode; // 临时节点，保存两个节点之中的第一个节点
        ListNode secondnode; // 临时节点，保存两个节点之中的第二个节点
        while (cur.next != null && cur.next.next != null)
        {
            temp = cur.next.next.next;
            firstnode = cur.next;
            secondnode = cur.next.next;
            cur.next = secondnode;
            secondnode.next = firstnode;
            firstnode.next = temp;
            cur = firstnode; // cur移动准备下一轮交换
        }

        return dumphead.next;
    }
    
    // 递归
    public ListNode SwapPairs1(ListNode head)
    {
        // 退出递归条件
        if (head == null || head.next == null)
        {
            return head;
        }
        // 获取当前节点的下一个节点
        ListNode next = head.next;
        // 进行递归
        ListNode newNode = SwapPairs(next.next);
        next.next = head;
        head.next = newNode;
        return next;
    }
}