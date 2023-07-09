namespace LeetCode.字符串;

// KMP 算法 最长公共前后缀
public class Solution28找出字符串中第一个匹配项的下标
{
    // 暴力解法 枚举原串 ss 中的每个字符作为「发起点」，每次从原串的「发起点」和匹配串的「首位」开始尝试匹配：
    public int StrStr(string haystack, string needle)
    {
        int n = haystack.Length, m = needle.Length;
        for (int i = 0; i <= n - m; i++)
        {
            int a = i, b = 0;
            while (b < m && haystack[a] == needle[b])
            {
                a++;
                b++;
            }

            if (b == m) return i;
        }

        return -1;
    }


    // a a b a a j a a b a a j
    // 0 1 0 1 2 0
    // 每次字符串匹配移动，是去找next数组的前一个的数值

    // KMP 利用已匹配部分中相同的「前缀」和「后缀」来加速下一次的匹配。
    // KMP 的原串指针不会进行回溯（没有朴素匹配中回到下一个「发起点」的过程）。
    public int StrStr1(string haystack, string needle)
    {
        if (needle.Length == 0)
        {
            return 0;
        }
        int[] next = new int[needle.Length];
        getNext(next, needle);

        int j = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            while (j > 0 && needle[j] != haystack[i])
            {
                j = next[j - 1];
            }

            if (needle[j] == haystack[i])
            {
                j++;
            }

            if (j == needle.Length)
            {
                return i - needle.Length + 1;
            }
        }
        return -1;
    }

    // 构造next数组，有点动态规划的感觉
    // next[j]的值每次最多增加一
    // next数组值等于 字符串最长公共前后缀
    // 视频讲解：https://www.bilibili.com/video/BV16X4y137qw/?spm_id_from=333.337.search-card.all.click&vd_source=e696436215120369d81a858fb5dbb3d7
    private void getNext(int[] next, String s)
    {
        // i 当前正在匹配的字符位置，也是next数组的索引，
        int j = 0;
        next[0] = 0;
        // 模式串指针是一直往后的，j是前缀指针会回退
        for (int i = 1; i < s.Length; i++)
        {
            // i和j 字符不相同时，需要通过next数组寻找下一个相同的前缀和后缀，再比较
            while (j > 0 && s[i] != s[j])
            {
                j = next[j - 1];
            }
        
            // 相等时，说明之前的前缀加上现在新加的这个字符也是匹配的。
            if (s[j] == s[i])
            {
                j++;
            }
        
            next[i] = j;
        }
    }
}