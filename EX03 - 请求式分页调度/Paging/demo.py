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
