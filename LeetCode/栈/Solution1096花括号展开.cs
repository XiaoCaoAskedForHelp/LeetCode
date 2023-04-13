namespace LeetCode.栈;

/// <summary>
/// 1096. 花括号展开 II
/// </summary>
public class Solution1096花括号展开
{
    public IList<string> BraceExpansionII(string expression)
    {
        Stack<char> op = new Stack<char>();
        Stack<HashSet<string>> stk = new Stack<HashSet<string>>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '{')
            {
                //// 首先判断是否需要添加乘号，再将 { 添加到运算符栈中
                if (i > 0 && (expression[i - 1] == '}' || char.IsLetter(expression[i - 1])))
                {
                    op.Push('*');
                }

                op.Push('{');
            }
            else if (expression[i] == '}')
            {
                //不断地弹出栈顶运算符，直到栈顶为 {
                while (op.Count > 0 && op.Peek() != '{')
                {
                    Calculate(op, stk);
                }

                op.Pop();
            }
            else if (expression[i] == ',')
            {
                // 不断地弹出栈顶运算符，直到栈为空或者栈顶不为乘号
                while (op.Count != 0 && op.Peek() == '*')
                {
                    Calculate(op, stk);
                }

                op.Push('+');
            }
            else
            {
                if (i > 0 && (expression[i - 1] == '}' || char.IsLetter(expression[i - 1])))
                {
                    // 首先判断是否需要添加乘号，再将新构造的集合添加到集合栈中
                    op.Push('*');
                }

                var hashSet = new HashSet<string>();
                hashSet.Add(expression[i].ToString());
                stk.Push(hashSet);
            }
        }

        while (op.Count != 0)
        {
            Calculate(op, stk);
        }

        List<string> res = stk.Peek().ToList();
        res.Sort((x, y) => x.CompareTo(y));
        return res;
    }

    private void Calculate(Stack<char> op, Stack<HashSet<string>> stk)
    {
        HashSet<string> next = stk.Pop();
        HashSet<string> prev = stk.Pop();
        
        if (op.Peek() == '+')
        {
            prev.UnionWith(next);
            stk.Push(prev);
        }
        else
        {
            HashSet<string> res = new HashSet<string>();
            var data = (from x in prev
                from y in next
                select x+y);
            foreach (var item in data)
            {
                res.Add(item);
            }
            stk.Push(res);
        }
        op.Pop();
    }
}