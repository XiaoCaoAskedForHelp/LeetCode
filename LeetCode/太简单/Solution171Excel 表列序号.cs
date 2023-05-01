namespace LeetCode.太简单;

public class Solution171Excel_表列序号
{
    public int TitleToNumber(string columnTitle)
    {
        int res = 0;
        for (int i = 0; i < columnTitle.Length; i++)
        {
            res += (columnTitle[i] - 'A' + 1) * (int)Math.Pow(26, columnTitle.Length - 1 - i);
        }

        return res;
    }
    
    public int TitleToNumber1(string columnTitle) {
        int number = 0;
        int multiple = 1;
        for (int i = columnTitle.Length - 1; i >= 0; i--) {
            int k = columnTitle[i] - 'A' + 1;
            number += k * multiple;
            multiple *= 26;
        }
        return number;
    }
}