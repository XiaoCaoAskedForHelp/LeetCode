namespace LeetCode.队列;

public class Solution239滑动窗口最大值
{
    private MyDequeue myDequeue = new MyDequeue();

    private List<int> res = new List<int>();

    // 维持一个单调队列，保证队列里单调递减或递增的原则,而本体需要维持一个递减的队列
    // pop(value)：如果窗口移除的元素value等于单调队列的出口元素，那么队列弹出元素，否则不用任何操作
    // push(value)：如果push的元素value大于入口元素的数值，那么就将队列入口的元素弹出，直到push元素的数值小于等于队列入口元素的数值为止
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        for (int i = 0; i < k; i++)
        {
            myDequeue.Enqueue(nums[i]);
        }

        res.Add(myDequeue.Max());
        for (int i = k; i < nums.Length; i++)
        {
            myDequeue.Dequeue(nums[i - k]);
            myDequeue.Enqueue(nums[i]);
            res.Add(myDequeue.Max());
        }

        return res.ToArray();
    }
}

class MyDequeue
{
    // 队尾需要进行插入和删除的操作，所以不能使用提供的Queue类。
    private LinkedList<int> linkList = new LinkedList<int>();

    public void Enqueue(int n)
    {
        while (linkList.Count > 0 && linkList.Last.Value < n)
        {
            // 单调队列的最后一个数小于新加进来的那个数时，说明它不是最大值，需要去除。
            linkList.RemoveLast();
        }

        linkList.AddLast(n);
    }

    public void Dequeue(int n)
    {
        // 如果串口移除的那个元素和出口元素相等，因为出口元素是最大值，所以就是需要删除的元素
        if (linkList.First.Value == n)
        {
            linkList.RemoveFirst();
        }
    }

    public int Max()
    {
        return linkList.First.Value;
    }
}