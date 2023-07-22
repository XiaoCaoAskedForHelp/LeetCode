namespace LeetCode.栈;

public class 单调栈_Solution739每日温度
{
    // 暴力
    public int[] DailyTemperatures(int[] temperatures)
    {
        int len = temperatures.Length;
        int[] res = new int[len];
        int[] next = new int[101]; // 记录每个温度第一次出现的下标
        Array.Fill(next, Int32.MaxValue);
        for (int i = len - 1; i >= 0; i--)
        {
            // 对于每个元素 temperatures[i]，在数组 next 中找到从 temperatures[i] + 1 到 100 中每个温度第一次出现的下标，
            // 将其中的最小下标记为 warmerIndex，则 warmerIndex 为下一次温度比当天高的下标。
            int index = Int32.MaxValue;
            for (int j = temperatures[i] + 1; j <= 100; j++)
            {
                if (next[j] < index)
                {
                    index = next[j];
                }
            }

            if (index < Int32.MaxValue)
            {
                res[i] = index - i;
            }

            // 每次更新next数字，这样即使temperature重复，index也是最小的
            next[temperatures[i]] = i;
        }

        return res;
    }
}