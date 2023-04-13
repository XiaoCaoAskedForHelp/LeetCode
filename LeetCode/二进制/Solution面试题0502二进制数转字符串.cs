using System.Text;

namespace LeetCode;

/// <summary>
/// 面试题 05.02. 二进制数转字符串
/// </summary>
public class Solution面试题0502二进制数转字符串
{
    public string PrintBin(double num)
    {
        // var result = new StringBuilder("0.");
        // for (int i = 1; i <= 32; i++)
        // {
        //     if (num == 0)
        //     {
        //         break;
        //     }
        //     if (1.0 / (1 << i) <= num)
        //     {
        //         num -= (1.0 / (1 << i));
        //         result.Append("1");
        //         continue;
        //     }
        //
        //     result.Append("0");
        // }
        //
        // if (num != 0)
        // {
        //     return "ERROR";
        // }
        //
        // return result.ToString();
        
        //实数的十进制表示转换成二进制表示的方法是：每次将实数乘以 2，将此时的整数部分添加到二进制表示的末尾，然后将整数部分置为 0
        StringBuilder sb = new StringBuilder("0.");
        while (sb.Length <= 32 && num != 0) {
            num *= 2;
            int digit = (int) num;
            sb.Append(digit);
            num -= digit;
        }
        return sb.Length <= 32 ? sb.ToString() : "ERROR";
    }
}