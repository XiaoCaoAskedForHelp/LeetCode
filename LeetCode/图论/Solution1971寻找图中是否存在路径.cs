namespace LeetCode.图论;

public class Solution1971寻找图中是否存在路径
{
    private int[] father;

    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        father = new int[n];
        Init(n);
        for (int i = 0; i < edges.Length; i++)
        {
            Join(edges[i][0], edges[i][1]);
        }

        return IsSame(source, destination);
    }

    // 并查集初始化
    void Init(int n)
    {
        for (int i = 0; i < n; i++)
        {
            father[i] = i;
        }
    }

    // 将v->u 这条边加入并查集
    void Join(int u, int v)
    {
        u = Find(u);
        v = Find(v);
        if (u == v) return;
        father[v] = u;
    }

    // 并查集寻根的过程
    int Find(int x)
    {
        if (father[x] != x)
        {
            father[x] = Find(father[x]); // 路径压缩,将x的父亲指向根结点
        }

        return father[x];
    }

    bool IsSame(int u, int v)
    {
        return Find(u) == Find(v);
    }
}