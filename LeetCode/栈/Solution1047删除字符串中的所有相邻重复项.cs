using System.Text;

namespace LeetCode.栈;

public class Solution1047删除字符串中的所有相邻重复项
{
    // 使用栈来消除重复元素
    public string RemoveDuplicates(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (var i in s)
        {
            if (stack.Any() && i == stack.Peek())
            {
                stack.Pop();
            }
            else
            {
                stack.Push(i);
            }
        }

        StringBuilder st = new StringBuilder();
        while (stack.Any())
        {
            st.Append(stack.Pop());
        }

        var result = new string(st.ToString().Reverse().ToArray());
        return result;
    }

    // 直接那字符串当成栈，省去栈转化为字符串的操作
    public string RemoveDuplicates1(string s)
    {
        StringBuilder res = new StringBuilder();
        foreach (var c in s)
        {
            if (res.Length > 0 && res[res.Length - 1] == c)
            {
                res.Remove(res.Length - 1, 1);
            }
            else
            {
                res.Append(c);
            }
        }

        return res.ToString();
    }
}