namespace LeetCode.哈希表;

public class Solution383赎金信
{
    //在本题的情况下，使用map的空间消耗要比数组大一些的，因为map要维护红黑树或者哈希表，而且还要做哈希函数，是费时的！数据量大的话就能体现出来差别了。 所以数组更加简单直接有效！
    // 数组哈希
    public bool CanConstruct(string ransomNote, string magazine) {
        int[] record = new int[26];
        if (ransomNote.Length > magazine.Length)
        {
            return false;
        }
        for (int i = 0; i < magazine.Length; i++)
        {
            record[magazine[i] - 'a']++;
        }

        foreach (var c in ransomNote)
        {
            record[c - 'a']--;
            if (record[c - 'a'] < 0)
            {
                return false;
            }
        }

        return true;
    }
}