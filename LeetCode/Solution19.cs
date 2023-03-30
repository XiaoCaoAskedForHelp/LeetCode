using System.ComponentModel;

namespace LeetCode;

/// <summary>
/// 1487. 保证文件名唯一
/// </summary>
public class Solution19
{
    public string[] GetFolderNames(string[] names)
    {
        var len = names.Length;
        string[] finalNames = new string[len];
        IDictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i < len; i++)
        {
            var name = names[i];
            //如果 name 不在哈希表中，我们直接创建该文件夹，并且记录对应文件夹的下一后缀序号为 1。
            if (!dict.ContainsKey(name))
            {
                dict.Add(name, 1);
                finalNames[i] = name;
            }
            else
            {
                // 哈希表表示 name 的下一后缀序号为 k
                int k = dict[name];
                while (dict.ContainsKey(AddSuffix(name, k)))
                {
                    k++;
                }

                finalNames[i] = AddSuffix(name, k);
                dict[name] = k + 1;
                dict.Add(AddSuffix(name, k), 1);
            }
        }

        return finalNames;
    }

    public string AddSuffix(string name, int k)
    {
        return name + $"({k})";
    }
}