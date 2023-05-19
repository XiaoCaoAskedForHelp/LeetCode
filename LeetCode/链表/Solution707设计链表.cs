using RazorEngine.Compilation.ImpromptuInterface.Optimization;

namespace LeetCode.链表;

public class Solution707设计链表
{
}

public class MyLinkedList
{
    //size 存储链表元素个数
    int size;

    //虚拟头结点
    ListNode head;

    //初始化链表
    public MyLinkedList()
    {
        size = 0;
        head = new ListNode(0);
    }

    //获取第index个节点的数值，注意index是从0开始的，第0个节点就是头结点
    public int Get(int index)
    {
        if (index < 0 || index >= size)
        {
            return -1;
        }

        ListNode cur = head;
        for (int i = 0; i <= index; i++)
        {
            cur = cur.next;
        }

        return cur.val;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(size, val);
    }

    // 在第 index 个节点之前插入一个新节点，例如index为0，那么新插入的节点为链表的新头节点。
    // 如果 index 等于链表的长度，则说明是新插入的节点为链表的尾结点
    // 如果 index 大于链表的长度，则返回空
    public void AddAtIndex(int index, int val)
    {
        if (index > size)
        {
            return;
        }

        if (index < 0)
        {
            index = 0;
        }

        size++;
        ListNode pred = head;
        //找到要插入节点的前驱
        for (int i = 0; i < index; i++)
        {
            pred = pred.next;
        }

        ListNode node = new ListNode(val);
        node.next = pred.next;
        pred.next = node;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            return;
        }

        size--;
        if (index == 0)
        {
            head = head.next;
            return;
        }

        ListNode pred = head;
        for (int i = 0; i < index; i++)
        {
            pred = pred.next;
        }

        pred.next = pred.next.next;
    }
}

class ListNode1
{
    public int val;
    public ListNode1 next;
    public ListNode1 prev;

    public ListNode1(int val)
    {
        this.val = val;
    }
}

public class MyLinkedList1
{
    private int size;
    private ListNode1 head;
    private ListNode1 tail;

    public MyLinkedList1()
    {
        size = 0;
        head = new ListNode1(0);
        tail = new ListNode1(0);
        //这一步非常关键，否则在加入头结点的操作中会出现null.next的错误！！！
        head.next = tail;
        tail.prev = head;
    }

    public int Get(int index)
    {
        if (index < 0 || index >= size)
        {
            return -1;
        }

        ListNode1 cur = head;
        //判断是哪一边遍历时间更短
        if (index <= size / 2)
        {
            for (int i = 0; i <= index; i++)
            {
                cur = cur.next;
            }
        }
        else
        {
            cur = tail;
            for (int i = 0; i < size - index; i++)
            {
                cur = cur.prev;
            }
        }

        return cur.val;
    }

    public void AddAtHead(int val)
    {
        AddAtIndex(0, val);
    }

    public void AddAtTail(int val)
    {
        AddAtIndex(size, val);
    }

    public void AddAtIndex(int index, int val)
    {
        if (index > size)
        {
            return;
        }

        index = Math.Max(0, index);
        
        ListNode1 pre = head;
        ListNode1 tai = tail;
        ListNode1 node = new ListNode1(val);
        if (index <= size / 2)
        {
            for (int i = 0; i < index; i++)
            {
                pre = pre.next;
            }

            tai = pre.next;
        }
        else
        {
            for (int i = 0; i < size - index; i++)
            {
                tai = tai.prev;
            }

            pre = tai.prev;
        }

        size++;
        pre.next = node;
        tai.prev = node;
        node.prev = pre;
        node.next = tai;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            return;
        }
        
        ListNode1 pre = head;
        ListNode1 tai = tail;
        if (index <= size / 2)
        {
            for (int i = 0; i < index; i++)
            {
                pre = pre.next;
            }

            tai = pre.next.next;
        }
        else
        {
            for (int i = 0; i < size - index - 1; i++)
            {
                tai = tai.prev;
            }

            pre = tai.prev.prev;
        }

        size--;
        tai.prev = pre;
        pre.next = tai;
    }
}