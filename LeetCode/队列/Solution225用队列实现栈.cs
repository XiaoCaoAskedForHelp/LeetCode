namespace LeetCode.队列;

public class MyStack
{
    // // 用两个队列que1和que2实现队列的功能
    //
    // private Queue<int> queue1;
    // private Queue<int> queue2;
    //
    // public MyStack()
    // {
    //     queue1 = new Queue<int>();
    //     queue2 = new Queue<int>();
    // }
    //
    // public void Push(int x)
    // {
    //     // 将元素插入的时候，是插入到栈的顶端
    //     // 而队列的栈顶是最前面，所以我们需要将元素元素插入到队列的前方，可以通过第二个队列完成
    //     queue2.Enqueue(x);
    //     while (queue1.Any())
    //     {
    //         queue2.Enqueue(queue1.Dequeue());
    //     }
    //
    //     (queue1, queue2) = (queue2, queue1);
    // }
    //
    // public int Pop()
    // {
    //     return queue1.Dequeue();
    // }
    //
    // public int Top()
    // {
    //     return queue1.Peek();
    // }
    //
    // public bool Empty()
    // {
    //     return !queue1.Any();
    // }


    // 用一个队列实现

    private Queue<int> queue1;

    public MyStack()
    {
        queue1 = new Queue<int>();
    }

    public void Push(int x)
    {
        int n = queue1.Count;
        queue1.Enqueue(x);
        // 用一个队列时，将元素插入队列末尾，其实只需要将除队尾那个元素重新插入到队列中，队尾元素自然就变成队头（栈顶）
        while (n-- != 0)
        {
            queue1.Enqueue(queue1.Dequeue());
        }
    }

    public int Pop()
    {
        return queue1.Dequeue();
    }

    public int Top()
    {
        return queue1.Peek();
    }

    public bool Empty()
    {
        return !queue1.Any();
    }
}