def sstf(requests, start):
    # 初始化变量
    size = len(requests)  # 请求的数量
    sequence = []  # 请求处理顺序
    distance = 0  # 总移动距离
    current_position = start  # 当前磁头位置
    movements = []  # 移动记录
    last_direction = None  # 上一次移动的方向

    # 当所有请求都被处理时停止
    while len(sequence) < size:
        # 找到最近的请求
        closest_request = min(requests, key=lambda x: abs(x - current_position))
        # 确定移动方向
        direction = "up" if closest_request > current_position else "down"
        # 累计移动距离
        distance += abs(current_position - closest_request)
        # 记录移动
        if last_direction is not None and direction != last_direction:
            movements.append(f"From {current_position} turn around to {closest_request} and trip is {distance}")
        else:
            movements.append(f"From {current_position} move to {closest_request} and trip is {distance}")
        # 更新位置和方向
        current_position = closest_request
        sequence.append(closest_request)
        requests.remove(closest_request)
        last_direction = direction

    return sequence, distance, movements


def scan(requests, start, direction=None):
    # 确定初始扫描方向
    if direction is None:
        nearest_up = min((req for req in requests if req > start), default=float('inf'))
        nearest_down = max((req for req in requests if req < start), default=float('-inf'))
        direction = 'up' if abs(nearest_up - start) < abs(nearest_down - start) else 'down'

    requests.sort()
    sequence = []
    distance = 0
    current_position = start
    movements = []

    if direction == 'up':
        # 处理向上的请求
        up_requests = [r for r in requests if r >= current_position]
        for r in up_requests:
            distance += abs(current_position - r)
            movements.append(f"From {current_position} move to {r} and trip is {distance}")
            current_position = r
            sequence.append(r)
        # 改变方向
        if up_requests:
            next_request_down = max((req for req in requests if req < start), default=current_position)
            if next_request_down != current_position:
                distance += abs(current_position - next_request_down)
                movements.append(f"From {current_position} turn around to {next_request_down} and trip is {distance}")
                current_position = next_request_down
                sequence.append(next_request_down)
        for r in reversed(requests):
            if r < start and r not in sequence:
                distance += abs(current_position - r)
                movements.append(f"From {current_position} move to {r} and trip is {distance}")
                current_position = r
                sequence.append(r)
    else:
        # 处理向下的请求
        down_requests = [r for r in requests if r <= current_position]
        for r in reversed(down_requests):
            distance += abs(current_position - r)
            movements.append(f"From {current_position} move to {r} and trip is {distance}")
            current_position = r
            sequence.append(r)
        # 改变方向
        if down_requests:
            next_request_up = min((req for req in requests if req > start), default=current_position)
            if next_request_up != current_position:
                distance += abs(current_position - next_request_up)
                movements.append(f"From {current_position} turn around to {next_request_up} and trip is {distance}")
                current_position = next_request_up
                sequence.append(next_request_up)
        for r in requests:
            if r > start and r not in sequence:
                distance += abs(current_position - r)
                movements.append(f"From {current_position} move to {r} and trip is {distance}")
                current_position = r
                sequence.append(r)

    return sequence, distance, movements


def main():
    # 用户输入选择算法
    algorithm_choice = input("请选择要模拟的算法 (1.SSTF, 2.SCAN): ").strip()

    # 输入磁头起始位置
    start_input = input("输入磁头起始位置 (默认 15): ").strip()
    start = int(start_input) if start_input else 15

    # 输入磁盘请求序列
    requests_input = input("输入磁盘请求序列 (使用半角逗号分隔, 默认 [2,34,5,8,3,24,12,18]): ").strip()
    requests = [int(r) for r in requests_input.split(',')] if requests_input else [2, 34, 5, 8, 3, 24, 12, 18]

    # 根据用户选择运行相应算法
    if algorithm_choice == '1':
        sequence, distance, movements = sstf(requests.copy(), start)
    elif algorithm_choice == '2':
        direction_input = input("输入起始扫描方向 (1.up, 2.down, 默认为最近的被请求磁道的方向): ").strip()
        direction = None
        if direction_input == '1':
            direction = 'up'
        elif direction_input == '2':
            direction = 'down'
        sequence, distance, movements = scan(requests.copy(), start, direction)
    else:
        print("无效的选择。")
        return

    # 打印算法执行结果
    print("Start...")
    for movement in movements:
        print(movement)
    print("------Finish")


if __name__ == "__main__":
    main()
