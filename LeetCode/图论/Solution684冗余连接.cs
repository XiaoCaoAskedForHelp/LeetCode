namespace LeetCode.图论;

public class Solution684冗余连接
{
    private int[] father;

    // 去掉某一条边后，这条边两端的节点都是连通的，那么这条边就是冗余的
    public int[] FindRedundantConnection(int[][] edges)
    {
        father = new int[edges.Length + 1];
        for (int i = edges.Length - 1; i >= 0; i--)
        {
            Init();
            for (int j = 0; j < edges.Length; j++)
            {
                if (i != j)
                {
                    Join(edges[j][0], edges[j][1]);
                }
            }

            if (IsSame(edges[i][0], edges[i][1]))
            {
                return edges[i];
            }
        }

        return new int[0];
    }

    void Init()
    {
        for (int i = 0; i < father.Length; i++)
        {
            father[i] = i;
        }
    }

    void Join(int u, int v)
    {
        father[Find(v)] = Find(u);
    }

    int Find(int x)
    {
        if (father[x] != x)
        {
            father[x] = Find(father[x]);
        }

        return father[x];
    }

    bool IsSame(int u, int v)
    {
        return Find(u) == Find(v);
    }

    // 从前向后遍历每一条边（因为优先让前面的边连上），
    // 边的两个节点如果不在同一个集合，就加入集合（即：同一个根节点），如果在同一个集合，就是冗余边
    public int[] FindRedundantConnection1(int[][] edges)
    {
        father = new int[edges.Length + 1];
        Init();
        for (int i = 0; i < edges.Length; i++)
        {
            if (IsSame(edges[i][0], edges[i][1]))
            {
                return edges[i];
            }

            Join(edges[i][0], edges[i][1]);
        }

        return null;
    }
}