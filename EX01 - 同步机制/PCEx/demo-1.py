import threading
import queue
import random
import time

# 定义两个缓冲区
buffer1 = queue.Queue(maxsize=10)
buffer2 = queue.Queue(maxsize=5)

# 定义全局指针
ppointer = 0
pcpointer1 = 0
pcpointer2 = 0
cpointer = 0

# 为了线程安全，定义锁
ppointer_lock = threading.Lock()
pcpointer1_lock = threading.Lock()
pcpointer2_lock = threading.Lock()
cpointer_lock = threading.Lock()

def producer(name, buffer, maxsize):
    global ppointer
    while True:
        item = random.randint(1, 100)
        with ppointer_lock:
            buffer.put((item, ppointer))
            print(f"{name} produced {item} at position {ppointer}")
            ppointer = (ppointer + 1) % maxsize
        time.sleep(random.uniform(0.2, 0.4))

def pc(maxsize1, maxsize2):
    global pcpointer1, pcpointer2
    while True:
        with pcpointer1_lock:
            item, pcpointer1 = buffer1.get()
        with pcpointer2_lock:
            buffer2.put((item, pcpointer2))
            print(f"PC processed item {item} from position {pcpointer1} of buffer1 to position {pcpointer2} of buffer2")
            pcpointer2 = (pcpointer2 + 1) % maxsize2
        time.sleep(random.uniform(0.1, 0.2))

def customer(name, buffer, maxsize):
    global cpointer
    while True:
        item, cpointer = buffer.get()
        with cpointer_lock:
            print(f"{name} consumed {item} from position {cpointer}")
            cpointer = (cpointer + 1) % maxsize
        time.sleep(random.uniform(0.2, 0.4))

# 创建并启动线程
producer_threads = [threading.Thread(target=producer, args=(f"Producer{i}", buffer1, 10)) for i in range(1, 4)]
pc_thread = threading.Thread(target=pc, args=(10, 5))
customer_threads = [threading.Thread(target=customer, args=(f"Customer{i}", buffer2, 5)) for i in range(1, 3)]

for t in producer_threads + [pc_thread] + customer_threads:
    t.start()

for t in producer_threads + [pc_thread] + customer_threads:
    t.join()