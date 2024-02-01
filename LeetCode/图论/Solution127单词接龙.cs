namespace LeetCode.图论;

public class Solution127单词接龙
{
    // 从beginWord开始，每次变换一个字母，直到endWord，路径不止一条，求出最短路径的长度，使用广度优先搜索
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = new HashSet<string>(wordList);  //转换为hashset 加快速度
        if (!wordSet.Contains(endWord) || wordSet.Count == 0) return 0;
        Queue<string> queue = new Queue<string>();//bfs 队列
        queue.Enqueue(beginWord);
        Dictionary<string,int> dictionary = new Dictionary<string, int>();//记录单词对应路径长度
        dictionary.Add(beginWord, 1);

        while (queue.Count != 0)
        {
            string word = queue.Dequeue();
            int path = dictionary[word];
            for (int i = 0; i < word.Length; i++)//遍历单词的每个字符
            {
                for (char j = 'a'; j <= 'z'; j++)
                {
                    char[] chars = word.ToCharArray();
                    chars[i] = j;
                    string newWord = new string(chars); // 得到新的单词
                    if (wordSet.Contains(newWord)) // 如果单词表中包含这个单词
                    {
                        if (newWord == endWord) return path + 1; // 如果这个单词就是endWord，返回路径长度
                        if (!dictionary.ContainsKey(newWord)) // 如果这个单词没有被访问过,防止出现循环
                        {
                            queue.Enqueue(newWord);
                            dictionary.Add(newWord, path + 1); // 记录这个单词的路径长度
                        }
                    }
                }
            }
        }

        return 0;
    }

    // 双向BFS
    public int LadderLength1(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord)) return 0;      // 如果 endWord 不在 wordList 中，那么无法成功转换，返回 0
        
        // ansLeft 记录从 beginWord 开始 BFS 时能组成的单词数目
        // ansRight 记录从 endWord 开始 BFS 时能组成的单词数目
        int ansLeft = 0, ansRight = 0;
        
        // queueLeft 表示从 beginWord 开始 BFS 时使用的队列
        // queueRight 表示从 endWord 开始 BFS 时使用的队列
        Queue<String> queueLeft = new Queue<string>(), queueRight = new Queue<string>();
        queueLeft.Enqueue(beginWord);
        queueRight.Enqueue(endWord);
        
        // 从 beginWord 开始 BFS 时把遍历到的节点存入 hashSetLeft 中
        // 从 endWord 开始 BFS 时把遍历到的节点存入 hashSetRight 中
        HashSet<String> hashSetLeft = new HashSet<string>(), hashSetRight = new HashSet<string>();
        hashSetLeft.Add(beginWord);
        hashSetRight.Add(endWord);
        
        // 只要有一个队列为空，就说明找不到转换序列，返回 0
        while (queueLeft.Count != 0 && queueRight.Count != 0)
        {
            ++ansLeft;
            int size = queueLeft.Count;
            for (int i = 0; i < size; i++)
            {
                string currentWord = queueLeft.Dequeue();
                // 只要hashSetRight中包含currentWord，就说明找到了转换序列，返回 ansLeft + ansRight
                if (hashSetRight.Contains(currentWord)) return ansLeft + ansRight;
                foreach (var chooseWord in wordList)
                {
                    if (hashSetLeft.Contains(chooseWord) || !CanConvert(currentWord, chooseWord)) continue;
                    hashSetLeft.Add(chooseWord);
                    queueLeft.Enqueue(chooseWord);
                }
            }
            ++ansRight;
            size = queueRight.Count;
            for (int i = 0; i < size; i++)
            {
                string currentWord = queueRight.Dequeue();
                // 只要hashSetLeft中包含currentWord，就说明找到了转换序列，返回 ansLeft + ansRight
                if (hashSetLeft.Contains(currentWord)) return ansLeft + ansRight;
                foreach (var chooseWord in wordList)
                {
                    if (hashSetRight.Contains(chooseWord) || !CanConvert(currentWord, chooseWord)) continue;
                    hashSetRight.Add(chooseWord);
                    queueRight.Enqueue(chooseWord);
                }
            }
        }

        return 0;
    }
    
    bool CanConvert(string s1, string s2)
    {
        int diff = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                diff++;
                if (diff > 1) return false;
            }
        }

        return true;
    }

}