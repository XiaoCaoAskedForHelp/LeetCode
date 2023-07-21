namespace LeetCode.栈;

public class Solution71简化路径
{
    public class Solution
    {
        // 空字符串。例如当出现多个连续的 /\texttt{/}/，就会分割出空字符串；
        //一个点 .
        //两个点 ..
        //只包含英文字母、数字或_的目录名。
        public string SimplifyPath(string path)
        {
            string[] names = path.Split('/');
            Stack<string> stack = new Stack<string>();
            foreach (var name in names)
            {
                if ("..".Equals(name))
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (name.Length > 0 && !".".Equals(name))
                {
                    stack.Push(name);
                }
            }

            if (stack.Count == 0)
            {
                return "/";
            }

            string[] res = new string[stack.Count * 2];
            int index = res.Length - 1;
            while (stack.Any())
            {
                res[index--] = stack.Pop();
                res[index--] = "/";
            }

            return String.Join("", res);
        }
    }
}