namespace LeetCode.二进制;

public class Solution2409统计共同度过的日子数
{
    //我们可以设计一个函数 calculateDayOfYear\textit{calculateDayOfYear}calculateDayOfYear 来计算输入中的每个日子在一年中是第几天。
    //计算输入中的每个日子在一年中是第几天时，可以利用前缀和数组来降低每次计算的复杂度。
    //知道每个日子是一年中的第几天后，可以先通过比较算出两人到达日子的最大值，离开日子的最小值，然后利用减法计算重合的日子。
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
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