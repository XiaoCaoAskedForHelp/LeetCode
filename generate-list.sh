#!/bin/bash

# get directories and corresponding paths
# find ./LeetCode -maxdepth 1 -type d：在 ./LeetCode 目录下使用 find 命令查找所有文件夹，使用 -maxdepth 1 选项可以限制它只检查一级子目录。
# grep -v "^.$"：使用 grep 工具从输出中过滤掉当前目录.或bin或obj|.idea的目录。
# sed 命令的作用是将匹配 '^./LeetCode' 的子字符串（即以 ./LeetCode 开头的子字符串）替换为空字符串。具体来说，'|^./LeetCode|' 使用 | 替换了 s 操作符两侧的 /，而这是为了避免与 s 中使用的 / 冲突。
# 因此，命令的整体作用是将 ./LeetCode 替换为空串，输出结果为 "二进制"。
directories=$(find ./LeetCode -maxdepth 1 -type d | grep -vE "^./LeetCode$|bin|obj|.idea" | sed 's|^./LeetCode/||')
basePath="https://github.com/XiaoCaoAskedForHelp/LeetCode/tree/main/LeetCode/"
fileBasePath="https://github.com/XiaoCaoAskedForHelp/LeetCode/blob/main/LeetCode/"

# generate table of contents with directories and paths
toc=""
for i in $directories; do
  echo $i
  dirPath=${basePath}${i}
  toc="$toc\n- [\`$i\`]($dirPath)"
  dir="./LeetCode/${i}"
  echo $dir
  files=$(find ${dir} -maxdepth 1 -type f | sed "s|^${dir}/||")
  for j in $files; do
    echo $j
    filePath=${fileBasePath}${i}/${j}
    toc="$toc\n  - [\`$j\`]($filePath)"
  done
done

# update README with table of contents
echo -e "# My LeetCode List\n$toc" > README.md