namespace LeetCode.图论;

public class Solution130被围绕的区域
{
    public void Solve(char[][] board) {
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
    
    
}