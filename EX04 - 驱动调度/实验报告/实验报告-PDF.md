<!-- 请使用 Typora + LaTeX-theme 来预览、编辑和导出PDF
Typora: https://typora.io/
LaTeX-theme: https://github.com/Keldos-Li/typora-latex-theme
Fonts: https://github.com/Keldos-Li/typora-latex-theme-fonts -->

<div class="cover" style="page-break-after:always;font-family:方正公文仿宋;width:100%;height:100%;border:none;margin: 0 auto;text-align:center;">
    <div style="width:60%;margin: 0 auto;height:0;padding-bottom:10%;">
        </br></br></br></br></br></br>
        <img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/%E5%AD%A6%E6%A0%A1%E6%A0%87%E8%AF%86/%E6%B1%9F%E8%8B%8F%E5%A4%A7%E5%AD%A6%E4%BA%AC%E6%B1%9F%E5%AD%A6%E9%99%A2/%E6%96%87%E5%AD%97%E7%BB%84%E5%90%88%E6%A8%AA%E6%8E%92.svg" alt="校名" style="width:100%;"/>
    </div>
    </br></br></br></br></br></br></br></br></br></br>
    <div style="width:40%;margin: 0 auto;height:0;padding-bottom:40%;">
        <img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/%E5%AD%A6%E6%A0%A1%E6%A0%87%E8%AF%86/%E6%B1%9F%E8%8B%8F%E5%A4%A7%E5%AD%A6%E4%BA%AC%E6%B1%9F%E5%AD%A6%E9%99%A2/%E6%A0%A1%E5%BE%BD.svg" alt="校徽" style="width:100%;"/>
	</div>
    </br></br></br>
    <span style="font-family:华文黑体Bold;text-align:center;font-size:30pt;margin: 10pt auto;line-height:40pt;">操作系统实验报告</span>
    </br>
    </br>
    </br>
    </br>
    <table style="border:none;text-align:center;width:72%;font-family:仿宋;font-size:14px; margin: 0 auto;">
    <tbody style="font-family:方正公文仿宋;font-size:12pt;">
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">题&emsp;&emsp;目</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">实验四&emsp;驱动调度</td>     </tr>
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">上机时间</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">2023.12.07</td>     </tr>
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">授课教师</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">潘雨青</td>     </tr>
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">姓&emsp;&emsp;名</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">马云骥</td>     </tr>
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">学&emsp;&emsp;号</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">4211153047</td>     </tr>
        <tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">专&emsp;&emsp;业</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">软件工程</td>     </tr>
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">班&emsp;&emsp;级</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">J软件(嵌入)(专转本)2102</td>     </tr>
    	<tr style="font-weight:normal;"> 
    		<td style="width:5%;text-align:right;">日&emsp;&emsp;期</td>
    		<td style="width:2%">：</td> 
    		<td style="width:40%;font-weight:normal;border-bottom: 1px solid;text-align:center;font-family:华文仿宋">2023.12.10</td>     </tr>
    </tbody>              
    </table>
</div>
<!-- 导出PDF时会在这里分页 -->

# 实验四&emsp;驱动调度



## 实验目的

1. 熟悉典型的驱动调度算法
2. 能够仿真实现典型的驱动调度算法



## 实验设计

&emsp;&emsp;原始参考的案例代码均由 <img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/Language/C%23.svg" alt="C#" style="height:1em;margin-bottom:0.25em"> `C#` 编写，这里本人使用 <img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/Language/Python.svg" alt="Python" style="height:1em;margin-bottom:0.25em"> `Python` 实现，力求达到同样的效果。

&emsp;&emsp;**开发环境**：<img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/OperatingSystem/Windows11.svg" alt="Windows 11" style="height:1em;margin-bottom:0.25em"> `Windows 11 Pro 23H2`

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/Language/Python.svg" alt="Python" style="height:1em;margin-bottom:0.25em"> `Python 3.12`

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<img src="https://raw.githubusercontent.com/SlenderData/img/main/images/%E5%B8%B8%E7%94%A8/Logo/IDE/JetBrains/PyCharm.svg" alt="PyCharm" style="height:1em;margin-bottom:0.25em"> `PyCharm 2023.3`

>> **实验指导书实验内容**
>> 1. 运行实例中的 DriverScheduling 项目，了解其程序结构，并理解其中的驱动调度算法是采用了何种驱动调度算法，并在实验报告中回答。
>> 2. 在实例中的 DriverScheduling 项目实现按电梯调度算法。

&emsp;&emsp;先回答指导书中的问题，原实例模拟了 SSTF（最短寻道时间优先）的磁盘驱动调度算法。SSTF 算法的工作原理是选择磁盘请求队列中距离当前磁头位置最近的请求进行处理，这种方法减少了磁头的平均寻道时间，但可能导致饥饿问题。

&emsp;&emsp;下面是我的 Python 实现：

```python
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

```

&emsp;&emsp;我将本次实验需要模拟的两种磁盘驱动调度算法实现在了一个 Python 程序中，程序运行后可以根据需要，选择使用对应的算法进行模拟。

### SSTF（`sstf` 函数）

- **目的**：模拟最短寻道时间优先算法，选择距当前磁头位置最近的请求，以最小化磁头移动距离。
- **参数**：
  - `requests`：磁盘请求的列表。
  - `start`：磁头的起始位置。
- **过程**：
  - 循环处理所有请求，每次选择最近的请求。
  - 计算磁头移动距离并记录移动方向。
  - 更新当前磁头位置和处理顺序。

### SCAN（`scan` 函数）

- **目的**：模拟电梯算法（扫描算法），按一个方向移动磁头，处理所有请求，直到到达最远的请求，然后改变方向。
- **参数**：
  - `requests`：磁盘请求的列表。
  - `start`：磁头的起始位置。
  - `direction`：起始扫描方向（可选）。
- **过程**：
  - 确定初始扫描方向（如果未指定）。
  - 处理当前方向上的请求。
  - 到达最远端后改变方向，并处理剩余请求。

### 主函数（`main` 函数）

- **流程**：
  - 让用户选择算法（SSTF或SCAN）。
  - 获取磁头起始位置和磁盘请求序列。
  - 根据用户选择执行相应算法。
  - 打印算法执行的详细移动过程和结果。



## 实验结果

### SSTF（最短寻道时间优先）

![Snipaste_2023-12-10_20-06-16](https://raw.githubusercontent.com/SlenderData/img/main/images/2023/12/10/20-07-14-a5f25987c826309653ca4f3f8757aafe-Snipaste_2023-12-10_20-06-16-81ee89.png)

### SCAN（电梯算法）

![Snipaste_2023-12-10_20-06-37](https://raw.githubusercontent.com/SlenderData/img/main/images/2023/12/10/20-07-31-61da177645d3b19dc19a92dff3a06b13-Snipaste_2023-12-10_20-06-37-6b2a0a.png)



## 实验总结

&emsp;&emsp;本实验通过模拟两种常用的磁盘调度算法——最短寻道时间优先（SSTF）和电梯算法（SCAN），成功地展示了它们在处理磁盘请求时的行为模式和效率差异。

- **SSTF算法**：在该算法中，磁头总是移动到最近的请求位置。这种方法可以有效减少磁头移动距离，从而提高处理速度。然而，它也可能导致远离当前磁头位置的请求长时间得不到处理，造成“饥饿”现象。
- **SCAN算法**：通过模拟电梯运行方式的 SCAN 算法，更加公平地处理每个请求。它通过在一个方向上连续处理请求，直到到达最远端，然后改变方向继续处理其余请求。这种方式虽然可能增加磁头的总移动距离，但它避免了 SSTF 算法中的“饥饿”问题，保证了所有请求最终都会得到处理。

&emsp;&emsp;总体来看，这两种算法各有优劣。SSTF 算法适用于请求集中且较为均匀分布的情况，能有效提高处理速度。而 SCAN 算法则适用于请求分布较为广泛，且对响应时间公平性有较高要求的场景。通过本实验，我们不仅加深了对这些经典磁盘调度算法的理解，还为未来在实际系统中选择合适的调度策略提供了参考依据。
