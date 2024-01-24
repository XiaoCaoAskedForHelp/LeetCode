namespace LeetCode.图论;

public class Solution695岛屿的最大面积
{
    int[,] directions = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };
    private int count;

    public int MaxAreaOfIsland(int[][] grid)
    {
        int result = 0;
        bool[,] visited = new Boolean[grid.Length, grid[0].Length];
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (!visited[i, j] && grid[i][j] == 1)
                {
                    count = 1;
                    visited[i, j] = true;
                    Dfs(grid, visited, i, j);
                    result = Math.Max(count, result);
                }
            }
        }

        return result;
    }

    void Dfs(int[][] grid, bool[,] visited, int i, int j)
    {
        // directions.Length是8，是所有元素的大小
        for (int k = 0; k < 4; k++)
        {
            int x = i + directions[k, 0];
            int y = j + directions[k, 1];
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length) continue;
            if (!visited[x, y] && grid[x][y] == 1)
            {
                visited[x, y] = true;
                count++;
                Dfs(grid, visited, x, y);
            }
        }
    }

    public int MaxAreaOfIsland1(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        int result = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (!visited[i, j] && grid[i][j] == 1)
                {
                    count = 0; // 因为dfs处理当前节点，所以遇到陆地计数为0，进dfs之后在开始从1计数
                    Dfs1(grid, visited, i, j); // 将与其链接的陆地都标记上 true
                    result = Math.Max(result, count);
                }
            }
        }

        return result;
    }

    void Dfs1(int[][] grid, bool[,] visited, int x, int y)
    {
        if (visited[x, y] || grid[x][y] == 0) return;
        visited[x, y] = true;
        count++;
        for (int i = 0; i < 4; i++)
        {
            int nextx = x + directions[i, 0];
            int nexty = y + directions[i, 1];
            if (nextx < 0 || nextx >= grid.Length || nexty < 0 || nexty >= grid[0].Length) continue; // 越界了，直接跳过
            Dfs1(grid, visited, nextx, nexty);
        }
    }

    public int MaxAreaOfIsland2(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        bool[,] visited = new bool[n, m];
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (!visited[i, j] && grid[i][j] == 1)
                {
                    count = 0;
                    Bfs(grid, visited, i, j); // 将与其链接的陆地都标记上 true
                    result = Math.Max(result, count);
                }
            }
        }

        return result;
    }

    void Bfs(int[][] grid, bool[,] visited, int x, int y)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(x);
        queue.Enqueue(y);
        visited[x, y] = true;
        count++;
        while (queue.Count != 0)
        {
            int xx = queue.Dequeue();
            int yy = queue.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nextx = xx + directions[i, 0];
                int nexty = yy + directions[i, 1];
                if (nextx < 0 || nextx >= grid.Length || nexty < 0 || nexty >= grid[0].Length) continue; // 越界
                if (!visited[nextx, nexty] && grid[nextx][nexty] == 1)
                {
                    // 节点没有被访问过且是陆地
                    visited[nextx, nexty] = true;
                    count++;
                    queue.Enqueue(nextx);
                    queue.Enqueue(nexty);
                }
            }
        }
    }
}