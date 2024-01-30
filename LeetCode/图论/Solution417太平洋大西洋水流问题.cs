namespace LeetCode.图论;

public class Solution417太平洋大西洋水流问题
{
    int[,] directions = new int[4, 2] { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };

    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int m = heights.Length, n = heights[0].Length;
        bool[,] canReachP = new bool[m, n];
        for (int i = 0; i < m; i++)
        {
            canReachP[i, 0] = true;
            Dfs(heights, canReachP, i, 0);
        }

        for (int i = 1; i < n; i++)
        {
            canReachP[0, i] = true;
            Dfs(heights, canReachP, 0, i);
        }

        bool[,] canReachA = new bool[m, n];
        for (int i = 0; i < m; i++)
        {
            canReachA[i, n - 1] = true;
            Dfs(heights, canReachA, i, n - 1);
        }

        for (int i = 0; i < n; i++)
        {
            canReachA[m - 1, i] = true;
            Dfs(heights, canReachA, m - 1, i);
        }

        IList<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (canReachA[i, j] && canReachP[i, j])
                {
                    res.Add(new List<int>() { i, j });
                }
            }
        }

        return res;
    }

    void Dfs(int[][] heights, bool[,] canReach, int i, int j)
    {
        for (int k = 0; k < 4; k++)
        {
            int newX = i + directions[k, 0];
            int newY = j + directions[k, 1];
            if (newX < 0 || newX >= heights.Length || newY < 0 || newY >= heights[0].Length) continue;
            if (heights[newX][newY] >= heights[i][j] && canReach[i, j] && !canReach[newX, newY])
            {
                canReach[newX, newY] = true;
                Dfs(heights, canReach, newX, newY);
            }
        }
    }

    int[] dir = { -1, 0, 0, -1, 1, 0, 0, 1 }; // 保存四个方向

    // 从低向高遍历，注意这里visited是引用，即可以改变传入的pacific和atlantic的值
    public IList<IList<int>> PacificAtlantic1(int[][] heights)
    {
        IList<IList<int>> result = new List<IList<int>>();
        int n = heights.Length;
        int m = heights[0].Length; // 这里不用担心空指针，题目要求说了长宽都大于1

        // 记录从太平洋边出发，可以遍历的节点
        bool[,] pacific = new bool[n, m];

        // 记录从大西洋出发，可以遍历的节点
        bool[,] atlantic = new bool[n, m];

        // 从最上最下行的节点出发，向高处遍历
        for (int i = 0; i < n; i++)
        {
            Dfs1(heights, pacific, i, 0); // 遍历最左列，接触太平洋 
            Dfs1(heights, atlantic, i, m - 1); // 遍历最右列，接触大西 
        }

        // 从最左最右列的节点出发，向高处遍历
        for (int j = 0; j < m; j++)
        {
            Dfs1(heights, pacific, 0, j); // 遍历最上行，接触太平洋
            Dfs1(heights, atlantic, n - 1, j); // 遍历最下行，接触大西洋
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // 如果这个节点，从太平洋和大西洋出发都遍历过，就是结果
                if (pacific[i, j] && atlantic[i, j]) result.Add(new List<int>() { i, j });
            }
        }

        return result;
    }

    void Dfs1(int[][] heights, bool[,] visited, int x, int y)
    {
        if (visited[x, y]) return;
        visited[x, y] = true;
        for (int i = 0; i < 4; i++)
        {
            // 向四个方向遍历
            int nextx = x + dir[i * 2];
            int nexty = y + dir[i * 2 + 1];
            // 超过边界
            if (nextx < 0 || nextx >= heights.Length || nexty < 0 || nexty >= heights[0].Length) continue;
            // 高度不合适，注意这里是从低向高判断
            if (heights[x][y] > heights[nextx][nexty]) continue;

            Dfs1(heights, visited, nextx, nexty);
        }
    }

    public IList<IList<int>> PacificAtlantic2(int[][] heights)
    {
        int rowSize = heights.Length, colSize = heights[0].Length;
        IList<IList<int>> ans = new List<IList<int>>();
        bool[,] visited1 = new bool[rowSize, colSize];
        bool[,] visited2 = new bool[rowSize, colSize];
        // 假设太平洋的标记为 1，大西洋为 0
        Queue<int[]> queue1 = new Queue<int[]>();
        Queue<int[]> queue2 = new Queue<int[]>();
        for (int row = 0; row < rowSize; row++)
        {
            visited2[row, colSize - 1] = true;
            visited1[row, 0] = true;
            queue2.Enqueue(new int[] { row, colSize - 1 });
            queue1.Enqueue(new int[] { row, 0 });
        }

        

        for (int col = 0; col < colSize; col++)
        {
            visited2[rowSize - 1, col] = true;
            visited1[0, col] = true;
            queue2.Enqueue(new int[] { rowSize - 1, col });
            queue1.Enqueue(new int[] { 0, col });
        }

        Bfs(heights, queue1, visited1);
        Bfs(heights, queue2, visited2);

        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                // 如果该位置即可以到太平洋又可以到大西洋，就放入答案数组
                if (visited1[row, col] && visited2[row, col])
                    ans.Add(new List<int>() { row, col });
            }
        }

        return ans;
    }

    public void Bfs(int[][] heights, Queue<int[]> queue, bool[,] visited)
    {
        while (queue.Count != 0)
        {
            int[] curPos = queue.Dequeue();
            for (int k = 0; k < 4; k++)
            {
                int row = curPos[0] + directions[k, 0];
                int col = curPos[1] + directions[k, 1];
                // 越界
                if (row < 0 || row >= heights.Length || col < 0 || col >= heights[0].Length) continue;
                // 高度不合适或者已经被访问过了
                if (heights[row][col] < heights[curPos[0]][curPos[1]] || visited[row, col]) continue;
                visited[row, col] = true;
                queue.Enqueue(new int[] { row, col });
            }
        }
    }
}