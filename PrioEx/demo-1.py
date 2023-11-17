import threading
import time

def counter(name, count_to, priority):
    for i in range(count_to):
        if i % 100 == 0:
            print(name, end='', flush=True)
            time.sleep(0.01 * (5 - priority))  # 模拟优先级差异

# 创建线程
threads = []
for i in range(1, 11):
    priority = 5 if i <= 7 or i == 9 else 3 if i == 8 else 1
    if i == 10:
        i = 'A'
    thread = threading.Thread(target=counter, args=(str(i), 5000, priority))
    threads.append(thread)

# 启动线程
for thread in threads:
    thread.start()

# 等待所有线程完成
for thread in threads:
    thread.join()
