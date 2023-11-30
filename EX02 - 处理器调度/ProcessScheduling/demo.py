import random
import time

class PCB:
    def __init__(self, name, run_duration, priority):
        self.name = name  # 进程名称
        self.run_duration = run_duration  # 运行时间
        self.priority = priority  # 优先级
        self.status = "就绪"  # 初始状态设置为“就绪”

    def display(self):
        # 打印进程的状态信息
        print(f"Process {self.name} is {self.status} and prio is {self.priority}, RunDuration is {self.run_duration}")


class ReadyList:
    def __init__(self):
        self.plist = []  # 准备队列

    def push(self, pcb):
        # 将进程添加到队列中
        self.plist.append(pcb)

    def pop(self):
        # 从队列中取出一个进程
        return self.plist.pop(0) if self.plist else None

    def sort_by_priority(self):
        # 按优先级对队列进行排序
        self.plist.sort(key=lambda pcb: pcb.priority)

    def is_empty(self):
        # 检查队列是否为空
        return len(self.plist) == 0

    def display(self):
        # 打印队列中所有进程的状态
        for pcb in self.plist:
            pcb.display()


def FIFO_scheduling(ready_list):
    # 先进先出调度算法
    while not ready_list.is_empty():
        current_pcb = ready_list.pop()
        while current_pcb.run_duration > 0:
            print("================================")
            current_pcb.status = "运行"
            current_pcb.run_duration -= 1
            current_pcb.display()
            ready_list.display()
            print("********************************")
            time.sleep(1)
        current_pcb.status = "完成"
        current_pcb.display()


def FIFO_time_slice(ready_list, time_slice):
    # 带时间片的先进先出调度算法
    while not ready_list.is_empty():
        current_pcb = ready_list.pop()
        for _ in range(time_slice):
            if current_pcb.run_duration == 0:
                break
            print("================================")
            current_pcb.status = "运行"
            current_pcb.run_duration -= 1
            current_pcb.display()
            ready_list.display()
            print("********************************")
            time.sleep(1)
        if current_pcb.run_duration > 0:
            current_pcb.status = "就绪"
            ready_list.push(current_pcb)
        else:
            current_pcb.status = "完成"
            current_pcb.display()


def priority_scheduling(ready_list):
    # 优先级调度算法
    while not ready_list.is_empty():
        ready_list.sort_by_priority()
        current_pcb = ready_list.pop()
        while current_pcb.run_duration > 0:
            print("================================")
            current_pcb.status = "运行"
            current_pcb.run_duration -= 1
            current_pcb.display()
            ready_list.display()
            print("********************************")
            time.sleep(1)
        current_pcb.status = "完成"
        current_pcb.display()


def priority_time_slice(ready_list, time_slice):
    # 带时间片的优先级调度算法
    while not ready_list.is_empty():
        ready_list.sort_by_priority()
        current_pcb = ready_list.pop()
        for _ in range(time_slice):
            if current_pcb.run_duration == 0:
                break
            print("================================")
            current_pcb.status = "运行"
            current_pcb.run_duration -= 1
            current_pcb.display()
            ready_list.display()
            print("********************************")
            time.sleep(1)
        if current_pcb.run_duration > 0:
            current_pcb.status = "就绪"
            ready_list.push(current_pcb)
        else:
            current_pcb.status = "完成"
            current_pcb.display()


def main():
    algorithms = {
        "1": FIFO_scheduling,
        "2": lambda rl: FIFO_time_slice(rl, 1),
        "3": priority_scheduling,
        "4": lambda rl: priority_time_slice(rl, 1)
    }

    print("选择处理器调度算法")
    print("1: 先进先出")
    print("2: 先进先出+时间片轮转")
    print("3: 优先级")
    print("4: 优先级+时间片轮转")
    choice = input("请输入你的选择: ")
    ready_list = ReadyList()

    # 生成5个随机PCB
    for i in range(1, 6):
        pcb = PCB(f"PCB{i}", random.randint(3, 6), random.randint(1, 3))  # 运行时间3-6，优先级1-3
        ready_list.push(pcb)

    print("开始模拟:")
    ready_list.display()
    print("********************************")

    # 运行调度算法
    if choice in algorithms:
        algorithms[choice](ready_list)
    else:
        print("无效的选择！")


if __name__ == "__main__":
    main()
