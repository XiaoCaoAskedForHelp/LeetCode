using System.Collections;

namespace LeetCode.图论;

//只要从周边找到陆地然后 通过 dfs或者bfs 将周边靠陆地且相邻的陆地都变成海洋，然后再去重新遍历地图的时候，统计此时还剩下的陆地就可以了
public class Solution1020飞地的数量
{
    int[,] directions = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };
    private int count = 0; // 统计符合题目要求的飞地数量

    public int NumEnclaves(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        // 从左侧边界和右侧边界开始搜索
        for (int i = 0; i < m; i++)
        {
            if (grid[i][0] == 1) Dfs(grid, i, 0);
            if (grid[i][n - 1] == 1) Dfs(grid, i, n - 1);
        }

        // 从上侧边界和下侧边界开始搜索
        for (int i = 0; i < n; i++)
        {
            if (grid[0][i] == 1) Dfs(grid, 0, i);
            if (grid[m - 1][i] == 1) Dfs(grid, m - 1, i);
        }

        count = 0; // 重新计数,前面的都是为了将边界上的陆地变成海洋
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    Dfs(grid, i, j);
                }
            }
        }

        return count;
    }

    void Dfs(int[][] grid, int i, int j)
    {
        if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) return;
        if (grid[i][j] == 0) return;
        grid[i][j] = 0; // 将陆地变成海洋,相当于visited数组
        count++;
        for (int k = 0; k < 4; k++)
        {
            int newX = i + directions[k, 0];
            int newY = j + directions[k, 1];
            Dfs(grid, newX, newY);
        }
    }

    public int NumEnclaves1(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        // 从左侧边界和右侧边界开始搜索
        for (int i = 0; i < m; i++)
        {
            if (grid[i][0] == 1) Bfs(grid, i, 0);
            if (grid[i][n - 1] == 1) Bfs(grid, i, n - 1);
        }

        // 从上边和下边向中间遍历
        for (int i = 0; i < n; i++)
        {
            if (grid[0][i] == 1) Bfs(grid, 0, i);
            if (grid[m - 1][i] == 1) Bfs(grid, m - 1, i);
        }

        count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    Bfs(grid, i, j);
                }
            }
        }

        return count;
    }

    void Bfs(int[][] grid, int i, int j)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(i);
        queue.Enqueue(j);
        grid[i][j] = 0;
        count++;
        while (queue.Count != 0)
        {
            int x = queue.Dequeue();
            int y = queue.Dequeue();
            for (int k = 0; k < 4; k++)
            {
                int newX = x + directions[k, 0];
                int newY = y + directions[k, 1];
                if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
                if (grid[newX][newY] == 1)
                {
                    grid[newX][newY] = 0;
                    queue.Enqueue(newX);
                    queue.Enqueue(newY);
                    count++;
                }
            }
        }
    }
}