namespace LeetCode.栈;

public class Solution150逆波兰表达式求值
{
    // 逆波兰表达式相当于是二叉树中的后序遍历，后缀表达式
    // 后缀表达式对计算机来说是非常友好的，不需要回退比较
    // 若碰到算术操作符，则出栈两个数字，计算后放回栈中
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();
        foreach (var s in tokens)
        {
            if (int.TryParse(s, out int num))
            {
                stack.Push(num);
            }
            else
            {
                int num1 = stack.Pop();
                int num2 = stack.Pop();
                switch (s)
                {
                    case "+":
                        stack.Push(num1 + num2);
                        break;
                    case "-":
                        stack.Push(num2 - num1);
                        break;
                    case "*":
                        stack.Push(num2 * num1);
                        break;
                    case "/":
                        stack.Push(num2 / num1);
                        break;
                    default:
                        break;
                }
            }
        }

        return stack.Pop();
    }
}