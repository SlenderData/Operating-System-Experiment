import threading
import time
import random

# 创建一个锁对象
lock = threading.Lock()

def producer(id):
    while True:
        lock.acquire() # 请求锁
        try:
            print(f"----------------------\nProducer {id} is working!")
            time.sleep(0.5) # 模拟工作
            print(f"Producer {id} is finished!\n----------------------")
        finally:
            lock.release() # 释放锁
        time.sleep(random.uniform(0.2, 0.4))

def customer(id):
    while True:
        lock.acquire() # 请求锁
        try:
            print(f"----------------------\nCustomer {id} is working!")
            time.sleep(0.5) # 模拟工作
            print(f"Customer {id} is finished!\n----------------------")
        finally:
            lock.release() # 释放锁
        time.sleep(random.uniform(0.2, 0.4))

# 创建并启动线程
threads = []
for i in range(2):
    threads.append(threading.Thread(target=producer, args=(i+1,)))
    threads.append(threading.Thread(target=customer, args=(i+1,)))

for thread in threads:
    thread.start()

# 等待所有线程结束
for thread in threads:
    thread.join()
