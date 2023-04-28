namespace LeetCode.数学;

public class Solution168Excel表列名称
{
    public string ConvertToTitle(int columnNumber)
    {
        IList<char> builder = new List<char>();
        while (columnNumber > 0)
        {
            //和正常 0~25 的 26 进制相比，本质上就是每一位多加了 1。假设 A == 0，B == 1，那么 AB = 26 * 0 + 1 * 1，
            //而现在 AB = 26 * (0 + 1) + 1 * (1 + 1)，所以只要在处理每一位的时候减 1，就可以按照正常的 26 进制来处理
            int mod = (columnNumber - 1) % 26;
            builder.Insert(0, (char)(mod + 'A'));
            columnNumber = (columnNumber - mod) / 26;
        }

        return string.Concat(builder);
    }
}