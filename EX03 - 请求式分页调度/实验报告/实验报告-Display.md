# 实验三&emsp;请求式分页调度



## 实验目的

1. 熟悉请求式分页调度算法，理解缺页中断的机理
2. 能够仿真实现请求式分页调度算法



## 实验设计

&emsp;&emsp;原始参考的案例代码均由 <img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/Language/C%23.svg" alt="C#" style="height:1em"> `C#` 编写，这里本人使用 <img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/Language/Python.svg" alt="Python" style="height:1em"> `Python` 实现，力求达到同样的效果。

&emsp;&emsp;**开发环境**：<img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/OperatingSystem/Windows11.svg" alt="Windows 11" style="height:1em"> `Windows 11 Pro 23H2`

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/Language/Python.svg" alt="Python" style="height:1em"> `Python 3.12`

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/IDE/JetBrains/PyCharm.svg" alt="PyCharm" style="height:1em"> `PyCharm 2023.2.5`

> **实验指导书实验内容**
> 
> 1. 运行实例中的 Paging 项目，了解其程序结构，并理解其中的请求式分页调度是采用了何种页面淘汰算法，并在实验报告中回答。
> 2. 在实例中的 Paging 项目实现按 LRU 页面淘汰算法。

&emsp;&emsp;先回答指导书中的问题，原实例模拟了 FIFO（先进先出）的页面淘汰算法，最早进入内存的页面会被最先淘汰。

&emsp;&emsp;下面是我的 Python 实现：

```python
import datetime
import random

# 页面表类定义
class PageTable:
    def __init__(self, page_no, block_no, hd_addr):
        self.page_no = page_no  # 页面号
        self.block_no = block_no  # 块号
        self.is_in = False  # 页面是否在内存中
        self.is_modified = False  # 页面是否被修改
        self.hd_addr = hd_addr  # 硬盘地址
        self.last_accessed = None  # 最后访问时间

    def read(self):
        self.is_in = True  # 设置页面为在内存中
        self.last_accessed = datetime.datetime.now()  # 更新最后访问时间
        print(f"Page {self.page_no} in {self.block_no} block is read")

    def write(self):
        self.is_in = True  # 设置页面为在内存中
        self.is_modified = True  # 标记页面已修改
        self.last_accessed = datetime.datetime.now()  # 更新最后访问时间
        print(f"Page {self.page_no} in {self.block_no} block is write")

    def display(self):
        # 格式化最后访问时间
        last_accessed_str = self.last_accessed.strftime("%Y/%m/%d %H:%M:%S") if self.last_accessed else "None"
        print(
            f"Page {self.page_no}, isIn {self.is_in}, isModified {self.is_modified}, BlockNo {self.block_no}, HdAddr {self.hd_addr}, LastAccessed {last_accessed_str}")

# 块列表类定义
class BlockList:
    def __init__(self, capacity, scheduling_algo):
        self.plist = []  # 页面列表
        self.capacity = capacity  # 内存容量
        self.scheduling_algo = scheduling_algo  # 页面置换算法

    def push(self, page):
        if page not in self.plist:
            # 检查待添加的页面是否已在内存中。如果不在，则继续。
            if len(self.plist) == self.capacity:
                # 如果内存已满（页面列表的长度等于内存容量），则需要进行页面置换。
                removed_page = None  # 初始化要移除的页面为 None

                if self.scheduling_algo == "FIFO":
                    # 如果采用的是先进先出（FIFO）算法：
                    removed_page = self.plist.pop(0)  # 移除列表中的第一个页面（最早进入内存的页面）

                elif self.scheduling_algo == "LRU":
                    # 如果采用的是最近最少使用（LRU）算法：
                    self.plist.sort(key=lambda p: p.last_accessed)  # 根据每个页面的最后访问时间进行排序
                    removed_page = self.plist.pop(0)  # 移除列表中最少使用的页面（即排序后的第一个页面）

                # 将被移除的页面的 is_in 设置为 false
                if removed_page:
                    removed_page.is_in = False

            self.plist.append(page)
            print("发生缺页中断")
        page.is_in = True
        self.display_memory()

    def display_memory(self):
        print("在内存的页面为: ", end="")
        for p in self.plist:
            print(f"PageNo: {p.page_no} | ", end="")
        print()

# 模拟分页的函数
def simulate_paging():
    # 初始化分页系统
    print("选择要模拟的页面置换算法")
    print("1: FIFO 先进先出")
    print("2: LRU  最近最少使用")
    choice = input("请输入你的选择: ")
    algorithms = {"1": "FIFO", "2": "LRU"}
    if choice not in algorithms:
        print("无效的输入！")
        return
    block_list = BlockList(5, algorithms[choice])
    pages = [PageTable(i + 1, i * 10 + 1, f"Hd{i * 1000}") for i in range(20)]

    # 模拟循环
    while True:
        page_no = random.randint(1, 20)
        page = pages[page_no - 1]
        read_or_write = random.choice(["read", "write"])

        if read_or_write == "read":
            page.read()
        else:
            page.write()

        block_list.push(page)

        for p in pages:
            p.display()

        print("-------------------")
        input("按回车模拟下一步页面操作...")

simulate_paging()

```

&emsp;&emsp;我将本次实验需要模拟的两种页面置换算法实现在了一个 Python 程序中，程序运行后可以根据需要，选择使用对应的算法进行模拟。它包含两个主要类（PageTable 和 BlockList）和一个模拟函数（simulate_paging）。下面是每个部分的详细解释：

### `PageTable` 类

&emsp;&emsp;`PageTable` 类定义了页面的基本属性和方法。每个页面对象包含以下属性：

- `page_no`：页面号。
- `block_no`：该页面所在的内存块号。
- `is_in`：标识页面是否在内存中。
- `is_modified`：标识页面自上次加载后是否被修改。
- `hd_addr`：页面在硬盘上的地址。
- `last_accessed`：页面最后访问时间。

&emsp;&emsp;此外，该类包含以下方法：

- `read()`：模拟读取页面，更新页面状态和最后访问时间。
- `write()`：模拟写入页面，更新页面状态、修改标识和最后访问时间。
- `display()`：打印页面的当前状态。

### `BlockList` 类

&emsp;&emsp;`BlockList` 类模拟物理内存中的块列表，负责管理页面的加载和置换。其主要属性包括：

- `plist`：当前在内存中的页面列表。
- `capacity`：内存的容量（可容纳页面的数量）。
- `scheduling_algo`：使用的页面置换算法。

&emsp;&emsp;主要方法包括：

- `push(page)`：处理新页面请求。如果内存已满，根据置换算法选择并移除一个页面，然后将新页面加入内存。
- `display_memory()`：显示当前内存中的页面列表。

### `simulate_paging` 函数

&emsp;&emsp;这是模拟的核心函数，执行以下步骤：

1. 用户选择页面置换算法（FIFO 或 LRU）。
2. 初始化 `BlockList` 对象和一系列 `PageTable` 对象，代表内存块和一组页面。
3. 进入模拟循环，随机生成页面读取或写入请求。
4. 根据页面请求，调用相应的 `PageTable` 方法（读或写）更新页面状态。
5. 调用 `BlockList` 的 `push` 方法处理页面加载和置换。
6. 循环展示每个页面的状态和整个内存的状态。

### 实验过程

&emsp;&emsp;在实验过程中，程序会持续生成随机的页面读写请求，模拟内存中页面的动态变化。用户可以通过观察每一步的输出，理解不同置换算法下，内存中页面组合是如何随着时间和页面请求而变化的。例如，在 FIFO 算法下，最先进入内存的页面会首先被置换；而在 LRU 算法下，则是最久未被访问的页面首先被置换。

&emsp;&emsp;这个过程有助于理解操作系统中虚拟内存管理的复杂性和页面置换算法的效果及其局限性。



## 实验结果

### FIFO（先进先出）

![Snipaste_2023-12-01_21-23-06](https://raw.githubusercontent.com/SlenderData/img/main/images/2023/12/01/21-25-47-7aee9675f43d2fd08ffaa948ef39ad1f-Snipaste_2023-12-01_21-23-06-ef9484.png)

### LRU（最近最少使用）

![Snipaste_2023-12-01_21-23-45](https://raw.githubusercontent.com/SlenderData/img/main/images/2023/12/01/21-26-06-4d3b6be5d4e2f4a67398526cde3058a7-Snipaste_2023-12-01_21-23-45-55b505.png)



## 实验总结

&emsp;&emsp;通过本实验，可以观察到不同页面置换算法对系统性能的影响。FIFO 算法简单高效，但可能不总是最优的选择，特别是在频繁访问的页面被置换时。LRU 算法更加智能，能够有效地利用历史访问信息来预测未来的页面访问模式，但其实现相对复杂。在实际应用中，需要根据系统的具体情况，选择合适的页面置换算法。
