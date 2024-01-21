namespace LeetCode.图论;

public class Solution797所有可能的路径
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        IList<IList<int>> res = new List<IList<int>>();
        List<int> path = new List<int>();
        path.Add(0);
        Dfs(graph, 0, path, res);
        return res;
    }

    void Dfs(int[][] graph, int index, List<int> path, IList<IList<int>> res)
    {
        if (index == graph.Length - 1)
        {
            res.Add(new List<int>(path));
            return;
        }

        foreach (var i in graph[index])
        {
            path.Add(i);
            // 先递归，再回溯，回溯就是删除最后一个元素，然后使用一个新的元素
            Dfs(graph, i, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }

    IList<IList<int>> ans;		// 用来存放满足条件的路径
    List<int> cnt;		// 用来保存 dfs 过程中的节点值
    public IList<IList<int>> AllPathsSourceTarget1(int[][] graph)
    {
        ans = new List<IList<int>>();
        cnt = new List<int>();
        cnt.Add(0);
        Dfs1(graph, 0);  // 注意，0 号节点要加入 cnt 数组中
        return ans;
    }
    
    void Dfs1(int[][] graph, int index)
    {
        if (index == graph.Length - 1)
        {
            ans.Add(new List<int>(cnt));
            return;
        }

        for (int i = 0; i < graph[index].Length; i++)
        {
            cnt.Add(graph[index][i]);
            Dfs1(graph, graph[index][i]);
            cnt.RemoveAt(cnt.Count - 1);
        }
    }
}