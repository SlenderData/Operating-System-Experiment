import threading
import time

# 定义一个计数器函数
def counter(name):
    start_time = time.time()
    x = 1
    for i in range(90000):
        y = x + 1
        x = y + x
    elapsed_time = (time.time() - start_time) * 1000  # 毫秒
    print(f"{name} took {elapsed_time} ms")

# 创建并启动线程
threads = []
for i in range(1, 11):
    thread = threading.Thread(target=counter, args=(f"Counter{i}",))
    thread.start()
    threads.append(thread)

# 等待所有线程完成
for thread in threads:
    thread.join()