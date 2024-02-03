namespace LeetCode.图论;

public class Solution463岛屿的周长
{
    int res = 0;
    int[,] directions = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

    public int IslandPerimeter(int[][] grid)
    {
        int row = grid.Length, col = grid[0].Length;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 2;
                    Dfs(grid, i, j);
                }
            }
        }

        return res;
    }

    void Dfs(int[][] grid, int x, int y)
    {
        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] == 0)
            {
                res++;
            }
            else if (grid[newX][newY] == 1)
            {
                grid[newX][newY] = 2;
                Dfs(grid, newX, newY);
            }
        }
    }

    // 遍历每一个空格，遇到岛屿，计算其上下左右的情况，遇到水域或者出界的情况，就可以计算边了。
    public int IslandPerimeter1(int[][] grid)
    {
        int result = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        int x = i + directions[k, 0];
                        int y = j + directions[k, 1];

                        if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] == 0)
                        {
                            result++;
                        }
                    }
                }
            }
        }

        return result;
    }

    // 计算出总的岛屿数量，因为有一对相邻两个陆地，边的总数就减2，那么在计算出相邻岛屿的数量就可以了。
    public int IslandPerimeter2(int[][] grid)
    {
        int sum = 0; // 总的岛屿数量
        int cover = 0; // 相邻岛屿的数量 
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    sum++;
                    // 统计上边相邻陆地
                    if (i - 1 >= 0 && grid[i - 1][j] == 1) cover++;
                    // 统计左边相邻陆地
                    if (j - 1 >= 0 && grid[i][j - 1] == 1) cover++;
                    // 为什么没统计下边和右边？ 因为避免重复计算
                }
            }
        }

        return sum * 4 - cover * 2;
    }
}