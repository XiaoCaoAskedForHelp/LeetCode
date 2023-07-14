namespace LeetCode.栈;

public class MyQueue
{
    //在push数据的时候，只要数据放进输入栈就好，
    //但在pop的时候，输出栈如果为空，就把进栈数据全部导入进来，再从出栈弹出数据
    //如果输出栈不为空，则直接从出栈弹出数据就可以了。
    private Stack<int> inStack;
    private Stack<int> outStack;
    
    public MyQueue()
    {
        inStack = new Stack<int>();
        outStack = new Stack<int>();
    }
    
    public void Push(int x) {
        inStack.Push(x);
    }
    
    public int Pop() {
        PopIfEmpty();
        return outStack.Pop();
    }
    
    public int Peek() {
        PopIfEmpty();
        return outStack.Peek();
    }
    
    public bool Empty()
    {
        return inStack.Count == 0 && outStack.Count == 0;
    }

    private void PopIfEmpty()
    {
        if (outStack.Count == 0 )
        {
            while (inStack.Count != 0)
            {
                outStack.Push(inStack.Pop());
            }
        }
    }
}