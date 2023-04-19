namespace LeetCode;

public class Solution20有效的括号
{
    public bool IsValid(string s)
    {
        int n = s.Length;
        if (n % 2 == 1) {
            return false;
        }
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> dictionary = new Dictionary<char, char>();
        dictionary.Add('(',')');
        dictionary.Add('[',']');
        dictionary.Add('{','}');
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Any() && dictionary.TryGetValue(stack.Peek(),out char value) && s[i] == value)
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
}