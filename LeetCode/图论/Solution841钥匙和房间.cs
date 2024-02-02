namespace LeetCode.图论;

public class Solution841钥匙和房间
{
    // 广度优先搜索
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        Queue<int> queue = new Queue<int>();
        HashSet<int> set = new HashSet<int>();
        queue.Enqueue(0);
        set.Add(0);
        while (queue.Count != 0)
        {
            int x = queue.Dequeue();
            foreach (var y in rooms[x])
            {
                // 如果房间y没有被访问过，就加入队列,并且标记为已访问
                if (!set.Contains(y))
                {
                    set.Add(y);
                    queue.Enqueue(y);
                }
            }
        }
        return set.Count == rooms.Count;
    }

    // 深度优先搜索
    public bool CanVisitAllRooms1(IList<IList<int>> rooms)
    {
        bool[] visited = new bool[rooms.Count];
        Dfs(rooms, 0, visited); 
        // 检查是否所有的房间都被访问过
        for (int i = 0; i < rooms.Count; i++)
        {
            if (!visited[i]) return false;
        }

        return true;
    }

    // 处理当前访问的结点
    private void Dfs(IList<IList<int>> rooms, int i, bool[] visited)
    {
        // 这个判断是为了防止重复访问，节省时间，可以不加
        if (visited[i]) {
            return;
        }
        visited[i] = true;
        foreach (var room in rooms[i])
        {
            if (!visited[room])
            {
                Dfs(rooms, room, visited);
            }
        }
    }
    
    // 深度优先搜索
    public bool CanVisitAllRooms2(IList<IList<int>> rooms)
    {
        bool[] visited = new bool[rooms.Count];
        visited[0] = true;
        Dfs1(rooms, 0, visited); 
        // 检查是否所有的房间都被访问过
        for (int i = 0; i < rooms.Count; i++)
        {
            if (!visited[i]) return false;
        }

        return true;
    }

    // 处理当前访问的结点
    private void Dfs1(IList<IList<int>> rooms, int i, bool[] visited)
    {
        foreach (var room in rooms[i])
        {
            if (!visited[room])
            {
                visited[room] = true;
                Dfs1(rooms, room, visited);
            }
        }
    }
}