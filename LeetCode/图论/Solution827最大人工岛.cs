namespace LeetCode.图论;

public class Solution827最大人工岛
{
    int[,] directions = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };
    int area = 0;
    int index = 2;
    Dictionary<int, int> dict = new Dictionary<int, int>();

    public int LargestIsland(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    area = 1;
                    grid[i][j] = index;
                    Dfs(grid, i, j);
                    dict.Add(index++, area);
                }
            }
        }

        int res = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    res = Math.Max(res, GetArea(grid, i, j));
                }
            }
        }

        return res == 0 ? m * n : res;
    }

    void Dfs(int[][] grid, int x, int y)
    {
        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
            if (grid[newX][newY] == 1)
            {
                area++;
                grid[newX][newY] = index;
                Dfs(grid, newX, newY);
            }
        }
    }

    int GetArea(int[][] grid, int x, int y)
    {
        int res = 1;

        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
            if (grid[newX][newY] != 0)
            {
                set.Add(grid[newX][newY]);
            }
        }

        res += set.Sum(i => dict[i]);

        return res;
    }

    int[,] dir = new int[4, 2] { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

    // 第一步：一次遍历地图，得出各个岛屿的面积，并做编号记录。可以使用map记录，key为岛屿编号，value为岛屿面积
    // 第二步：在遍历地图，遍历0的方格（因为要将0变成1），并统计该1（由0变成的1）周边岛屿面积，将其相邻面积相加在一起，遍历所有 0 之后，就可以得出 选一个0变成1 之后的最大面积。
    public int LargestIsland1(int[][] grid)
    {
        int ans = 0, size = grid.Length, mark = 2;
        Dictionary<int, int> getSize = new Dictionary<int, int>();
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (grid[row][col] == 1)
                {
                    int aresSize = 1 + Dfs1(grid, row, col, mark);
                    getSize.Add(mark++, aresSize);
                }
            }
        }

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                // 当前位置如果不是 0 那么直接跳过，因为我们只能把 0 变成 1
                if (grid[row][col] != 0) continue;
                HashSet<int> set = new HashSet<int>(); // 防止同一区域被重复计算
                // 计算从当前位置变成 1 之后，能够连成的岛屿的面积总和
                int curSize = 1;
                for (int i = 0; i < 4; i++)
                {
                    int curRow = row + dir[i, 0];
                    int curCol = col + dir[i, 1];
                    if (curRow < 0 || curRow >= size || curCol < 0 || curCol >= size) continue;
                    if (grid[curRow][curCol] != 0)
                    {
                        int curMark = grid[curRow][curCol];
                        // 如果标记存在 hashSet 中说明该标记被记录过一次，如果不存在 getSize 中说明该标记是无效标记(此时 curMark = 0)
                        if (!set.Contains(curMark))
                        {
                            set.Add(curMark);
                            curSize += getSize[curMark];
                        }
                    }
                }

                ans = Math.Max(ans, curSize);
            }
        }

        return ans == 0 ? size * size : ans;
    }
    
    int Dfs1(int[][] grid, int x, int y, int mark)
    {
        int res = 0;
        grid[x][y] = mark;
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dir[i, 0];
            int newY = y + dir[i, 1];
            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
            if (grid[newX][newY] == 1)
            {
                res += 1 + Dfs1(grid, newX, newY, mark);
            }
        }

        return res;
    }
}