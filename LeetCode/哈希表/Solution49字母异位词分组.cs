using System.Text;

namespace LeetCode.哈希表;

public class Solution49字母异位词分组
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            var charArray = str.ToCharArray();
            Array.Sort(charArray);
            var key = new string(charArray);
            dictionary.TryGetValue(key, out var list);
            if (list == null)
            {
                list = new List<string>();
            }

            list.Add(str);
            dictionary[key] = list;
        }

        return new List<IList<string>>(dictionary.Values);
    }

    public IList<IList<string>> GroupAnagrams1(string[] strs)
    {
        IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            int[] counts = new int[26];
            for (int i = 0; i < str.Length; i++)
            {
                counts[str[i] - 'a']++;
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                if (counts[i] != 0)
                {
                    builder.Append('a' + i);
                    builder.Append(counts[i]);
                }
            }

            dictionary.TryGetValue(builder.ToString(), out var res);
            if (res == null)
            {
                res = new List<string>();
            }

            res.Add(str);
            dictionary[builder.ToString()] =  res;
        }

        return new List<IList<string>>(dictionary.Values);
    }
}