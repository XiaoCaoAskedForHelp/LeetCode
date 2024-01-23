using System.ComponentModel.Design;

namespace LeetCode.图论;

public class Solution200岛屿数量
{
    int[,] directions = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

    // 深度优先搜索
    public int NumIslands(char[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new Boolean[m, n];

        int result = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j] && grid[i][j] == '1')
                {
                    visited[i, j] = true;
                    result++;
                    // 将与其链接的陆地都标记上 true
                    Dfs(grid, visited, i, j);
                }
            }
        }

        return result;
    }

    void Dfs(char[][] grid, bool[,] visited, int i, int j)
    {
        for (int k = 0; k < 4; k++)
        {
            int newX = i + directions[k, 0];
            int newY = j + directions[k, 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
            // 这个就是终止条件，如果越界了，就不再继续递归了
            if (!visited[newX, newY] && grid[newX][newY] == '1')
            {
                visited[newX, newY] = true;
                Dfs(grid, visited, newX, newY);
            }
        }
    }

    // 深度优先搜索，包括起点在内的陆地都在dfs进行标记
    public int NumIslands1(char[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new Boolean[m, n];

        int result = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j] && grid[i][j] == '1')
                {
                    result++;
                    // 将与其链接的陆地都标记上 true
                    Dfs1(grid, visited, i, j);
                }
            }
        }

        return result;
    }

    void Dfs1(char[][] grid, bool[,] visited, int i, int j)
    {
        if (visited[i, j] || grid[i][j] == '0') return;
        visited[i, j] = true; // 标记访问过
        for (int k = 0; k < 4; k++)
        {
            int nextx = i + directions[k, 0];
            int nexty = j + directions[k, 1];
            if (nextx >= 0 && nextx < grid.Length && nexty >= 0 && nexty < grid[0].Length)
            {
                Dfs1(grid, visited, nextx, nexty);
            }
        }
    }

    // 广度优先搜索
    public int NumIslands2(char[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new Boolean[m, n];
        int result = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j] && grid[i][j] == '1')
                {
                    result++;
                    Bfs(grid, visited, i, j);
                }
            }
        }

        return result;
    }

    // 这样写会多遍历很多节点
    void Bfs(char[][] grid, bool[,] visited, int i, int j)
    {
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { i, j });
        while (queue.Count != 0)
        {
            int[] cur = queue.Dequeue();
            int x = cur[0], y = cur[1];
            // 越界或者已经访问过或者是水域，就不再继续访问了
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || visited[x, y] ||
                grid[x][y] == '0') continue;
            visited[x, y] = true;
            queue.Enqueue(new int[] { x - 1, y });
            queue.Enqueue(new int[] { x + 1, y });
            queue.Enqueue(new int[] { x, y - 1 });
            queue.Enqueue(new int[] { x, y + 1 });
        }
    }
    
    void Bfs1(char[][] grid, bool[,] visited, int i, int j)
    {
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { i, j });
        visited[i, j] = true;  // 只要加入队列就标记为已访问
        while (queue.Count != 0)
        {
            int[] cur = queue.Dequeue();
            int x = cur[0], y = cur[1];
            for (int k = 0; k < 4; k++)
            {
                int nextx = x + directions[k, 0];
                int nexty = y + directions[k, 1];
                if (nextx >= 0 && nextx < grid.Length && nexty >= 0 && nexty < grid[0].Length &&
                    !visited[nextx, nexty] && grid[nextx][nexty] == '1')
                {
                    queue.Enqueue(new int[] { nextx, nexty });
                    visited[nextx, nexty] = true;  // 只要加入队列就标记为已访问,会减少很多递归。
                }
            }
        }
    }
}