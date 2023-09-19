// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Threading.Channels;
using LeetCode;
using LeetCode.动态规划;
using LeetCode.双指针;
using LeetCode.哈希表;
using LeetCode.太简单;
using LeetCode.字符串;
using LeetCode.数学;
using LeetCode.数组;
using LeetCode.枚举;
using LeetCode.栈;
using LeetCode.树;
using LeetCode.模拟;
using LeetCode.滑动窗口;
using LeetCode.链表;
using LeetCode.队列;
using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;

Console.WriteLine("Hello, World!");

//new Solution2().NumberOfPairs(new[] { 1,3,2,1,3,2,2 });

// int[][] num = new int[3][] { new[] { 1, 1, 1 }, new[] { 1, 0, 1 }, new[] { 1, 1, 1 } };
// int[][] num1 = new int[1][] { new[] { 1, 1, 0, 0 } };
// new Solution3().Largest1BorderedSquare(num1);

// int[] ranks = new []{4,4,2,4,4};
// char[] suits = new char[]{'d','a','a','b','c'};
// new Solution6().BestHand(ranks,suits);

// new Solution7().MinTaps(5,new []{3,4,1,1,0,0});

//new Solution8().Jump(new []{2,3,1,1,4});


//new Solution15().MovesToMakeZigzag(new int[]{7,4,8,9,7,7,5});

// string str = "@查年级() union @查1班() union @查2班() where date = #{date}";
// var matchCollection = Regex.Matches(str,@"@([\u4e00-\u9fa5_a-zA-Z0-9]+)\((.*?)\)");
// Console.ReadLine();

//new Solution18().PrintBin(0.625);

//new Solution21().MinOperationsMaxProfit(new[] { 10,10,6,4,7 }, 3, 8);
//new Solution22().MinimumDeletions("babaaaabbbbbaaababbbbbbaaabbaababbabbbbaabbbbaabbabbabaabbbababaa");

//new Solution23().BraceExpansionII("{a,b}{c,{d,e}}");

// var ints = new int[3][];
// ints[0] = new[] { 1, 3, 1 };
// ints[1] = new[] { 1, 5, 1 };
// ints[2] = new[] { 4, 2, 1 };
// new Solution24().MaxValue(ints);

//new Solution25().MinimumRecolors("WBWBBBW",2);

// int[] a = new[] { 1,1,1,1 };
// int[] b = new[] { 1,1,1,50 };
// new Solution27().MinNumberOfHours(1,1,a,b);

// Dictionary<string, string> dictionary = new Dictionary<string, string>();
// dictionary.Add("dfsa","fdsa");
// dictionary.Add("fdsa","fdsafd");
// Console.WriteLine(JsonConvert.SerializeObject(dictionary));
// Console.ReadLine();

// new Solution2404出现最频繁的偶数元素().MostFrequentEven(new[] { 0, 1, 2, 2, 4, 4, 1 });


// new Solution2409统计共同度过的日子数().CountDaysTogether("04-20", "06-18", "04-12", "12-19");


// new Solution20有效的括号().IsValid("()[]{}");

// new Solution66加一().PlusOne(new int[]{9});

// new Solution67二进制求和().AddBinary("11","1");

// var treeNode4 = new TreeNode(4, null, null);
// var treeNode5 = new TreeNode(5, null, null);
// var treeNode2 = new TreeNode(2, treeNode4, treeNode5);
// TreeNode treeNode6 = new TreeNode(6, null, null);
// TreeNode treeNode3 = new TreeNode(3, treeNode6, null);
// var treeNode = new TreeNode(1,treeNode2,treeNode3);
// new Solution94二叉树的中序遍历().InorderTraversal2(treeNode);

// new Solution136只出现一次的数字().SingleNumber(new int[]{4,1,2,1,2});

// new Solution118杨辉三角().Generate(5);
// new Solution119杨辉三角().GetRow(5);

// new Solution168Excel表列名称().ConvertToTitle(701);

// new Solution171Excel_表列序号().TitleToNumber("A");

// new Solution205同构字符串().IsIsomorphic("badc", "baba");

// new Solution283移动零().MoveZeroes(new int[] { 0, 1, 0, 3, 12 });

// new Solution844比较含退格的字符串().BackspaceCompare2("bxj##tw","bxo#j##tw");


// new Solution977_有序数组的平方().SortedSquares(new int[] { -7,-3,2,3,11 });

// new Solution904水果成篮().TotalFruit(new[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 });

// new Solution76最小覆盖子串().MinWindow2("ADOBECODEBANC","ABC");

// new Solution59螺旋矩阵II().GenerateMatrix2(3);

// int[][] df = new Solution59螺旋矩阵II().GenerateMatrix2(3);
// int[][] df = new int[1][];
// df[0] = new int[] { 6, 9, 7 };
// new Solution54螺旋矩阵().SpiralOrder(df);

// new Solution剑指Offer29顺时针打印矩阵().SpiralOrder(new int[][]{});

// var myLinkedList = new MyLinkedList();
// myLinkedList.AddAtHead(1);
// myLinkedList.AddAtTail(3);
// myLinkedList.AddAtIndex(1,2);
// myLinkedList.Get(1);
// myLinkedList.DeleteAtIndex(1);

// ListNode head = new ListNode(1);
// ListNode node = head;
// for (int i = 2; i <= 5; i++)
// {
//     head.next = new ListNode(i);
//     head = head.next;
// }
// // new Solution206反转链表().ReverseList2(node);
//
// new Solution24两两交换链表中的节点().SwapPairs(node);

// new Solution49字母异位词分组().GroupAnagrams1(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

// new Solution438找到字符串中所有字母异位词().FindAnagrams1("bpaa", "aa");

// var df = new int[] { 2, 2, 2, 2, 2 };
// new Solution18四数之和().FourSum(df, 8);

// new Solution541反转字符串II().ReverseStr("abcdefg", 8);

// new Solution剑指Offer05替换空格().ReplaceSpace1("We are happy.");

// new Solution151反转字符串中的单词().ReverseWords2("  hello world  ");

// new Solution28找出字符串中第一个匹配项的下标().StrStr1("sadbutsad","ababac");

// new Solution239滑动窗口最大值().MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);

// new Solution62不同路径().UniquePaths2(3,7);


// int[] weight = { 1, 3, 4 };
// int[] value = { 15, 20, 20 };
// int bagSize = 4;
// // new Solution0_1背包().Package0_12(weight, value, bagSize);
//
// new Solution0_1背包2().testWeightBagProblem(weight,value,bagSize);

// Console.WriteLine(new Solution0GCD().Gcd1(45,18));

// Console.WriteLine(new Solution0GCD().ExtendedGcd(111, 321));
//
// int a = 111;
// int b = 321;
// int gcd, s, t;
//
// new Solution0GCD().ExtendedGcd1(a, b, out gcd, out s, out t);
//
// Console.WriteLine("最大公约数 (GCD): " + gcd);
// Console.WriteLine("s 值: " + s);
// Console.WriteLine("t 值: " + t);
//
// new Solution0GCD().GeneralSolution(7, 4, 100);

new Solution0GCD().countPrimes(100);

