namespace LeetCode.栈;

public class Solution20有效的括号
{
    public bool IsValid(string s)
    {
        int n = s.Length;
        if (n % 2 == 1)
        {
            return false;
        }

        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> dictionary = new Dictionary<char, char>();
        dictionary.Add('(', ')');
        dictionary.Add('[', ']');
        dictionary.Add('{', '}');
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Any() && dictionary.TryGetValue(stack.Peek(), out char value) && s[i] == value)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        return stack.Count == 0;
    }

    public bool IsValid1(string s)
    {
        if (s.Length % 2 != 0)
        {
            return false;
        }

        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
                stack.Push(')');
            else if (s[i] == '[')
                stack.Push(']');
            else if (s[i] == '{')
                stack.Push('}');
            // 遍历字符串匹配的过程中，栈已经为空了，没有匹配的字符了，说明右括号没有找到对应的左括号 return false
            // 遍历字符串匹配的过程中，发现栈里没有我们要匹配的字符。所以return false
            else if (stack.Any() && stack.Peek() == s[i])
                stack.Pop();
            else
                return false;
        }

        return !stack.Any();
    }
}