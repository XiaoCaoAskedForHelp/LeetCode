namespace LeetCode.枚举;

public class Solution2409统计共同度过的日子数
{
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        var arriveA = Array.ConvertAll<string, int>(arriveAlice.Split('-'), s => Extension.StringToInt32(s));
        var leaveA = Array.ConvertAll<string, int>(leaveAlice.Split('-'), s => Extension.StringToInt32(s));
        var arriveB = Array.ConvertAll<string, int>(arriveBob.Split('-'), s => Extension.StringToInt32(s));
        var leaveB = Array.ConvertAll<string, int>(leaveBob.Split('-'), s => Extension.StringToInt32(s));

        int[] start;
        if (arriveA[0] > arriveB[0] || (arriveA[0] == arriveB[0] && arriveA[1] > arriveB[1]))
        {
            start = arriveA;
        }
        else
        {
            start = arriveB;
        }

        int[] end;
        if (leaveA[0] < leaveB[0] || (leaveA[0] == leaveB[0] && leaveA[1] < leaveB[1]))
        {
            end = leaveA;
        }
        else
        {
            end = leaveB;
        }

        int sum = 0;
        int ini = start[0];
        int[] months = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        while (end[0] > start[0] + 1)
        {
            sum += months[start[0]];
            start[0]++;
        }

        if (end[0] == start[0])
        {
            sum += end[1] - start[1] + 1;
        }

        if (end[0] == start[0] + 1)
        {
            sum += (months[ini - 1] - start[1] + 1 + end[1]);
        }

        return sum < 0 ? 0 : sum;
    }

    /// <summary>
    /// 扩展类
    /// </summary>
    public static class Extension
    {
        public static int StringToInt32(string str)
        {
            int num = -1;
            if (int.TryParse(str, out num))
            {
                return num;
            }
            else
            {
                return -1;
            }
        }
    }
    
    //我们可以设计一个函数 calculateDayOfYear\textit{calculateDayOfYear}calculateDayOfYear 来计算输入中的每个日子在一年中是第几天。
    //计算输入中的每个日子在一年中是第几天时，可以利用前缀和数组来降低每次计算的复杂度。
    //知道每个日子是一年中的第几天后，可以先通过比较算出两人到达日子的最大值，离开日子的最小值，然后利用减法计算重合的日子。
    public int CountDaysTogether2(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
        int[] datesOfMonths = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        int[] prefixSum = new int[13];
        for (int i = 0; i < 12; i++) {
            prefixSum[i + 1] = prefixSum[i] + datesOfMonths[i];
        }

        int arriveAliceDay = CalculateDayOfYear(arriveAlice, prefixSum);
        int leaveAliceDay = CalculateDayOfYear(leaveAlice, prefixSum);
        int arriveBobDay = CalculateDayOfYear(arriveBob, prefixSum);
        int leaveBobDay = CalculateDayOfYear(leaveBob, prefixSum);
        return Math.Max(0, Math.Min(leaveAliceDay, leaveBobDay) - Math.Max(arriveAliceDay, arriveBobDay) + 1);
    }

    public int CalculateDayOfYear(string day, int[] prefixSum) {
        int month = int.Parse(day.Substring(0, 2));
        int date = int.Parse(day.Substring(3));
        return prefixSum[month - 1] + date;
    }
}