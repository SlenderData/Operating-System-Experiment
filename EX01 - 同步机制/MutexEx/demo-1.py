import threading
import time
import random

# 创建一个锁对象
lock = threading.Lock()

def producer():
    while True:
        lock.acquire() # 请求锁
        try:
            print("----------------------\nProducer is working!")
            time.sleep(0.5) # 模拟工作
            print("Producer is finished!\n----------------------")
        finally:
            lock.release() # 释放锁
        time.sleep(random.uniform(0.2, 0.4))

def customer():
    while True:
        lock.acquire() # 请求锁
        try:
            print("----------------------\nCustomer is working!")
            time.sleep(0.5) # 模拟工作
            print("Customer is finished!\n----------------------")
        finally:
            lock.release() # 释放锁
        time.sleep(random.uniform(0.2, 0.4))

# 创建并启动线程
producer_thread = threading.Thread(target=producer)
customer_thread = threading.Thread(target=customer)

producer_thread.start()
customer_thread.start()

# 等待线程结束
producer_thread.join()
customer_thread.join()
