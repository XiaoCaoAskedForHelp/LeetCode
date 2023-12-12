namespace LeetCode.贪心;

// 输入：people = [[7,0],[4,4],[7,1],[5,0],[6,1],[5,2]]
// 输出：[[5,0],[7,0],[5,2],[6,1],[4,4],[7,1]]
public class Solution406根据身高重建队列
{
    public int[][] ReconstructQueue(int[][] people)
    {
        Array.Sort(people, (a, b) => a[1] - b[1]);
        List<int[]> list = new List<int[]>();
        list.Add(people[0]);
        for (int i = 1; i < people.Length; i++)
        {
            int cnt = people[i][1];
            int index = 0;
            // 首先cnt表示现在要插入的这个数字前面需要有多少个比他大的数字，通过下面的循环就能找到最小的能插入的index
            while (cnt > 0)
            {
                if (people[i][0] <= list[index][0])
                {
                    cnt--;
                }

                index++;
            }

            // 这个循环是保证插入的这个人不影响后面人的排序，即找到这个人能插入的最大index，如果他的身高比后面的人高，那么他就可以往后排，并且他的cnt也不会变
            while (cnt == 0 && index < list.Count && people[i][0] > list[index][0])
            {
                index++;
            }

            // 插入列表
            list.Insert(index, people[i]);
        }

        return list.ToArray();
    }

    // 按照先按身高有高到低排序,然后在按k有小到大排序之后，优先按身高高的people的k来插入，后序插入节点也不会影响前面已经插入的节点，最终按照k的规则完成了队列
    public int[][] ReconstructQueue1(int[][] people)
    {
        people = people.OrderByDescending(p => p[0]).ThenBy(p => p[1]).ToArray();
        List<int[]> list = new List<int[]>();
        for (int i = 0; i < people.Length; i++)
        {
            int position = people[i][1];
            list.Insert(position,people[i]);
        }

        return list.ToArray();
    }
}