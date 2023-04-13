namespace LeetCode;

/// <summary>
/// 1255. 得分最高的单词集合
/// </summary>
public class Solution1255得分最高的单词集合
{
    public int MaxScoreWords(string[] words, char[] letters, int[] score)
    {
        // 由于单词数目不超过14，所以可以使用状态压缩来枚举所有的单词子集
        // 使用整数s阿里表示单词子集
        // 使用count来保存字母表letter中各种字母的数目，使用wordCount来保存子集s中的所有单词的各种字母的数目
        int[] count = new int[26];
        foreach (var letter in letters)
        {
            count[letter - 'a']++;
        }

        int len = words.Length;
        int result = 0;
        for (int s = 1; s < (1 << len); s++)
        {
            int[] wordCount = new int[26];
            for (int i = 0; i < len; i++)
            {
                if ((s & (1 << i)) == 0)
                {
                    continue;
                }

                foreach (var c in words[i])
                {
                    wordCount[c - 'a']++;
                }
            }

            bool ok = true; // 判断子集s是否合法
            int sum = 0;// 保存子集的得分
            for (int i = 0; i < 26; i++)
            {
                sum += wordCount[i] * score[i];
                ok = ok && (wordCount[i] <= count[i]);
            }

            if (ok)
            {
                result = Math.Max(result, sum);
            }
        }

        return result;
    }
}