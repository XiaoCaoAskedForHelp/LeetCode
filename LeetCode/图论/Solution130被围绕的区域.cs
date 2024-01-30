namespace LeetCode.图论;

public class Solution130被围绕的区域
{
    public void Solve(char[][] board)
    {
        int m = board.Length, n = board[0].Length;
        for (int i = 0; i < m; i++)
        {
            Dfs(board, i, 0);
            Dfs(board, i, n - 1);
        }

        for (int i = 0; i < n; i++)
        {
            Dfs(board, 0, i);
            Dfs(board, m - 1, i);
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == 'O')
                {
                    board[i][j] = 'X';
                }
                else if (board[i][j] == 'A')
                {
                    board[i][j] = 'O';
                }
            }
        }
    }

    void Dfs(char[][] board, int i, int j)
    {
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length) return;
        if (board[i][j] == 'X' || board[i][j] == 'A') return;
        board[i][j] = 'A';
        Dfs(board, i + 1, j);
        Dfs(board, i - 1, j);
        Dfs(board, i, j + 1);
        Dfs(board, i, j - 1);
    }

    private int[,] position = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向

    public void Solve1(char[][] board)
    {
        // rowSize：行的长度，colSize：列的长度
        int rowSize = board.Length, colSize = board[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        // 从左侧边，和右侧边遍历
        for (int row = 0; row < rowSize; row++)
        {
            if (board[row][0] == 'O')
                queue.Enqueue(new int[] { row, 0 });
            if (board[row][colSize - 1] == 'O')
                queue.Enqueue(new int[] { row, colSize - 1 });
        }

        // 从上边和下边遍历，在对左侧边和右侧边遍历时我们已经遍历了矩阵的四个角
        // 所以在遍历上边和下边时可以不用遍历四个角
        for (int col = 1; col < colSize - 1; col++)
        {
            if (board[0][col] == 'O')
                queue.Enqueue(new int[] { 0, col });
            if (board[rowSize - 1][col] == 'O')
                queue.Enqueue(new int[] { rowSize - 1, col });
        }

        // 广度优先遍历，把没有被 'X' 包围的 'O' 修改成特殊值
        while (queue.Count != 0)
        {
            int[] current = queue.Dequeue();
            board[current[0]][current[1]] = 'A';
            for (int i = 0; i < 4; i++)
            {
                int row = current[0] + position[i, 0], col = current[1] + position[i, 1];
                // 如果范围越界、该位置的值不是 'O'，就直接跳过
                if (row < 0 || row >= rowSize || col < 0 || col >= colSize) continue;
                if (board[row][col] != 'O') continue;
                queue.Enqueue(new int[] { row, col });
            }
        }

        // 遍历数组，把 'O' 修改成 'X'，特殊值修改成 'O'
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                if (board[row][col] == 'A') board[row][col] = 'O';
                else if (board[row][col] == 'O') board[row][col] = 'X';
            }
        }
    }


    int[,] dir = new int[4, 2] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

    public void Solve2(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i][0] == 'O') bfs(board, i, 0);
            if (board[i][board[0].Length - 1] == 'O') bfs(board, i, board[0].Length - 1);
        }

        for (int j = 1; j < board[0].Length - 1; j++)
        {
            if (board[0][j] == 'O') bfs(board, 0, j);
            if (board[board.Length - 1][j] == 'O') bfs(board, board.Length - 1, j);
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 'O') board[i][j] = 'X';
                if (board[i][j] == 'A') board[i][j] = 'O';
            }
        }
    }

    private void bfs(char[][] board, int x, int y)
    {
        Queue<int> que = new Queue<int>();
        board[x][y] = 'A';
        que.Enqueue(x);
        que.Enqueue(y);

        while (que.Count != 0)
        {
            int currX = que.Dequeue();
            int currY = que.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nextX = currX + dir[i, 0];
                int nextY = currY + dir[i, 1];

                if (nextX < 0 || nextY < 0 || nextX >= board.Length || nextY >= board[0].Length)
                    continue;
                if (board[nextX][nextY] == 'X' || board[nextX][nextY] == 'A')
                    continue;
                bfs(board, nextX, nextY);
            }
        }
    }
}