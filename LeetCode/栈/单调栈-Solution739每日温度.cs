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

    public int[] DailyTemperatures1(int[] temperatures)
    {
        // 递增栈（从栈头到栈尾）
        Stack<int> st = new();
        int[] res = new int[temperatures.Length];
        st.Push(0);
        for (int i = 1; i < temperatures.Length; i++)
        {
            if (temperatures[i] <= temperatures[st.Peek()])
            {
                st.Push(i); //当前遍历的元素T[i]小于等于栈顶元素T[st.top()]的情况
            }
            else
            {
                // 当前遍历的元素T[i]大于栈顶元素T[st.top()]的情况
                while (st.Any() && temperatures[i] > temperatures[st.Peek()])
                {
                    res[st.Peek()] = i - st.Peek();
                    st.Pop();
                }

                st.Push(i);
            }
        }

        return res;
    }


    // 代码优化
    public int[] DailyTemperatures2(int[] temperatures)
    {
        // 递增栈（从栈头到栈尾）
        Stack<int> st = new();
        int[] res = new int[temperatures.Length];
        for (int i = 0; i < temperatures.Length; i++)
        {
            // 当前遍历的元素T[i]大于栈顶元素T[st.top()]的情况
            while (st.Any() && temperatures[i] > temperatures[st.Peek()])  //注意栈不能为空
            {
                res[st.Peek()] = i - st.Peek();
                st.Pop();
            }

            st.Push(i);  // 最终都是将比栈顶小的元素push进去，所以可以合并
        }

        return res;
    }
}