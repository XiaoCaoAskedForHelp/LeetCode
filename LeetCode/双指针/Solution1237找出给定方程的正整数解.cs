namespace LeetCode.双指针;

public class Solution1237找出给定方程的正整数解
{
    // public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
    // {
        // 暴力
        // IList<IList<int>> res = new List<IList<int>>();
        // for (int x = 1; x <= 1000; x++)
        // {
        //     for (int y = 1; y <= 1000; y++)
        //     {
        //         if (customfunction.f(x, y) == z)
        //         {
        //             res.Add(new List<int>() { x, y });
        //         }
        //     }
        // }
        //
        // return res;


        // 因为单调，所以二分查找
        // IList<IList<int>> res = new List<IList<int>>();
        // for (int x = 1; x <= 1000; x++)
        // {
        //     int left = 1, right = 1000;
        //     while (left <= right)
        //     {
        //         int mid = (left + right) / 2;
        //         if (customfunction.f(x, mid) == z)
        //         {
        //             res.Add(new List<int>() { x, mid });
        //             break;
        //         }
        //
        //         if (customfunction.f(x, mid) > z)
        //         {
        //             right = mid - 1;
        //         }
        //
        //         if (customfunction.f(x, mid) < z)
        //         {
        //             left = mid + 1;
        //         }
        //     }
        // }
        //
        // return res;


        //单调性，x1>x2,则有y1<y2，双指针，y不需要从头枚举
    //     IList<IList<int>> res = new List<IList<int>>();
    //     for (int x = 1, y = 1000; x <= 1000 && y >= 1; x++)
    //     {
    //         while (y >= 1 && customfunction.f(x, y) > z)
    //         {
    //             y--;
    //         }
    //
    //         if (y >= 1 && customfunction.f(x, y) == z)
    //         {
    //             res.Add(new List<int>() { x, y });
    //         }
    //     }
    //
    //     return res;
    // }
}