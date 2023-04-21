namespace LeetCode.太简单;

public class Solution58最后一个单词的长度
{
    public int LengthOfLastWord(string s)
    {
        return s.Trim().Split(" ").Last().Length;
    }
}