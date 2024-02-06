using System.Threading.Tasks.Dataflow;

namespace LeetCode.图论;

public class Solution685冗余连接II
{
    private int[] father;

    // 树的根节点入度为0，其他节点入度为1，只要能找到一个节点入度为2，就说明有一条冗余的边
    // 没有入度为2的节点，说明有环，那么冗余的边就是最后一条形成环的边
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        int n = edges.Length;
        int[] inDegree = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            inDegree[edges[i][1]]++; // 统计入度
        }

        List<int> list = new List<int>();
        // 找入度为2的节点所对应的边，注意要倒序，因为优先返回最后出现在二维数组中的答案
        for (int i = n - 1; i >= 0; i--)
        {
            if (inDegree[edges[i][1]] == 2)
            {
                list.Add(i); // 记录入度为2的节点
            }
        }

        // 处理入度为2的节点，如果有，一定是两条边中删除一条
        if (list.Count > 0)
        {
            if (IsTree(edges, n, list[0])) return edges[list[0]]; // 删除第一条边
            return edges[list[1]]; // 删除第二条边
        }

        // 没有入度为2的节点，说明有环，那么冗余的边就是最后一条形成环的边
        return GetCircleEdge(edges, n);
    }

    bool IsTree(int[][] edges, int n, int deleteEdge)
    {
        Init(n);
        for (int i = 0; i < n; i++)
        {
            if (i == deleteEdge) continue;
            if (Same(edges[i][0], edges[i][1])) return false; // 构成环，一定不是树
            Join(edges[i][0], edges[i][1]);
        }

        return true;
    }

    void Init(int n)
    {
        father = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            father[i] = i;
        }
    }

    void Join(int u, int v)
    {
        u = Find(u);
        v = Find(v);
        if (u == v) return;
        father[v] = u;
    }

    int Find(int x)
    {
        if (father[x] != x)
        {
            father[x] = Find(father[x]);
        }

        return father[x];
    }

    bool Same(int u, int v)
    {
        return Find(u) == Find(v);
    }
    
    int[] GetCircleEdge(int[][] edges, int n)
    {
        Init(n);
        for (int i = 0; i < n; i++)
        {
            if (Same(edges[i][0], edges[i][1])) return edges[i]; // 构成环，返回
            Join(edges[i][0], edges[i][1]);
        }

        return null;
    }
}