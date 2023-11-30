using System.Runtime.InteropServices;

namespace LeetCode.贪心;

// 这里的局部最优就是大饼干喂给胃口大的，充分利用饼干尺寸喂饱一个，全局最优就是喂饱尽可能多的小孩。
public class Solution455分发饼干
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        int index = s.Length - 1;
        int cnt = 0;
        for (int i = g.Length - 1; i >= 0; i--)
        {
            // 如果最大的饼干可以满足胃口，那么就贪心成功
            if (index >= 0 && s[index] >= g[i])
            {
                index--;
                cnt++;
            }
        }

        return cnt;
    }

    public int FindContentChildren1(int[] g, int[] s)
    {
        // 也可以换一个思路，小饼干先喂饱小胃口
        Array.Sort(g);
        Array.Sort(s);
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (index < g.Length && g[index] <= s[i])
            {
                index++;
            }
        }

        return index;
    }
}