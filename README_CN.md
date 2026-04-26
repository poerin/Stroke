# Stroke

**一款 Windows 鼠标手势引擎。**

Stroke 通过识别鼠标绘制的轨迹来触发自定义操作。它全局拦截鼠标输入，将轨迹与用户定义的模式进行匹配，并执行关联的 C# 脚本。引擎本身轻量、无界面，与配置工具完全解耦。

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)

[View English Documentation](README.md)

## 目录

- [核心特性](#核心特性)
- [快速入门](#快速入门)
    - [运行环境](#运行环境)
    - [安装步骤](#安装步骤)
- [默认手势](#默认手势)
- [核心概念](#核心概念)
    - [动作包](#动作包)
    - [手势识别与特殊手势](#手势识别与特殊手势)
    - [按键痕迹](#按键痕迹)
- [使用 Base 库编写脚本](#使用-base-库编写脚本)
    - [输入模拟](#输入模拟)
    - [窗口管理](#窗口管理)
    - [系统与进程](#系统与进程)
    - [画笔定制](#画笔定制)
    - [全局状态与实用工具](#全局状态与实用工具)
- [配置工具](#配置工具)
    - [画笔设置](#画笔设置)
    - [手势设置](#手势设置)
    - [动作树](#动作树)
    - [编译设置](#编译设置)
    - [过滤设置](#过滤设置)
    - [线程设置](#线程设置)
    - [本地化](#本地化)
- [常见问题解答](#常见问题解答)
- [参与贡献](#参与贡献)
- [许可证](#许可证)

## 核心特性

- **高效识别：** 基于距离的向量匹配算法，能够快速准确地处理任意连续轨迹的手势。
- **纯粹的设计：** 核心引擎无用户界面，静默运行于后台，与配置工具相互独立。完成配置后配置工具可被直接删除。
- **可编程动作：** 手势触发启动时编译的 C# 代码，可充分利用 .NET 运行时的全部能力。
- **上下文感知匹配：** 动作被组织在动作包中，仅当活动窗口进程路径匹配用户定义的正则表达式时对应的动作才会被考虑。
- **全局键盘钩子：** 脚本可直接访问底层键盘事件，实现复杂的输入拦截与自动化。

## 快速入门

### 运行环境
- Windows 7 或更高版本。
- .NET Framework 4.8 运行时。

### 安装步骤
1. 从 [Releases](https://github.com/poerin/Stroke/releases) 页面下载最新版。
2. 将压缩包解压至任一固定目录。
3. 运行 `Stroke.exe` 启用手势引擎。
4. 运行 `Stroke.Configure.exe` 自定义手势、动作及其他设置。

> 启动 `Stroke.Configure.exe` 时会自动结束正在运行的 `Stroke.exe` 进程，以避免冲突。

## 默认手势

Stroke 发行包内置一套预配置、开箱即用的默认手势，默认手势触发键为鼠标右键。该套手势针对 Windows 常用生产力场景优化，采用上下文感知作用域机制，动作按场景组织在对应动作包中，仅当手势起始点光标下的窗体所属进程匹配动作包规则时，对应动作才会生效。部分默认手势支持在绘制时按住鼠标左键触发替代动作，对应功能详见表格中「左键痕迹动作」栏，无对应功能则标注为“无”。

### 全局范围
适用于所有 Windows 应用程序及全系统场景。

| 手势 | 手势预览 | 默认动作 | 左键痕迹动作 |
|---|:---:|---|---|
| ↑（向上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↑.png" width="32" alt="↑" /> | 复制 | Home 键 |
| ↓（向下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↓.png" width="32" alt="↓" /> | 粘贴 | End 键 |
| ↓↑（向下再向上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↓↑.png" width="32" alt="↓↑" /> | 剪切 | 无 |
| ↑↓（向上再向下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↑↓.png" width="32" alt="↑↓" /> | 全选 | 无 |
| ↓←（向下再向左） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↓←.png" width="32" alt="↓←" /> | 撤销 | 无 |
| ↓→（向下再向右） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↓→.png" width="32" alt="↓→" /> | 重做 | 无 |
| ←（向左） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/←.png" width="32" alt="←" /> | 后退 | 切换至左侧已创建的虚拟桌面 |
| →（向右） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/→.png" width="32" alt="→" /> | 前进 | 切换至右侧已创建的虚拟桌面 |
| ←→（向左再向右） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/←→.png" width="32" alt="←→" /> | 播放/暂停 | 静音/恢复 |
| ←↑（向左再向上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/←↑.png" width="32" alt="←↑" /> | 上一曲 | 无 |
| ←↓（向左再向下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/←↓.png" width="32" alt="←↓" /> | 下一曲 | 无 |
| 滚轮向上 | 无 | 无 | 增大音量 |
| 滚轮向下 | 无 | 无 | 减小音量 |
| ↙（左下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↙.png" width="32" alt="↙" /> | 最小化窗口 | 取消窗口置顶 |
| ↗（右上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↗.png" width="32" alt="↗" /> | 最大化/恢复窗口 | 窗口置顶 |
| ↖（左上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↖.png" width="32" alt="↖" /> | 关闭窗口 | 无 |
| ↘（右下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↘.png" width="32" alt="↘" /> | 打开资源管理器（D盘） | 打开资源管理器（C盘） |
| 左键点击 | 无 | 回车键 | 无 |

### 标签页范围
适用于已预配置的带标签页界面的常用应用程序，您可根据使用需求自行添加适配的进程规则。

| 手势 | 手势预览 | 默认动作 | 左键痕迹动作 |
|---|:---:|---|---|
| ↖（左上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↖.png" width="32" alt="↖" /> | 关闭当前标签页 | 关闭窗口 |
| 滚轮向上 | 无 | 切换至上一标签页 | 增大音量 |
| 滚轮向下 | 无 | 切换至下一标签页 | 减小音量 |

### 适用范围：资源管理器与网页浏览器
适用于 Windows 资源管理器与主流网页浏览器。

| 手势 | 手势预览 | 默认动作 | 左键痕迹动作 |
|---|:---:|---|---|
| →←（向右再向左） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/→←.png" width="32" alt="→←" /> | 刷新 | 无 |
| →↑（向右再向上） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/→↑.png" width="32" alt="→↑" /> | 全屏 | 无 |

### 资源管理器专属范围
仅适用于 Windows 资源管理器。

| 手势 | 手势预览 | 默认动作 | 左键痕迹动作 |
|---|:---:|---|---|
| →↓（向右再向下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/→↓.png" width="32" alt="→↓" /> | 新建文件夹 | 无 |
| ↑←（向上再向左） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↑←.png" width="32" alt="↑←" /> | 向上一级 | 无 |
| ↑→（向上再向右） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↑→.png" width="32" alt="↑→" /> | 打开新资源管理器窗口 | 无 |

### 网页浏览器专属范围
仅适用于主流网页浏览器。

| 手势 | 手势预览 | 默认动作 | 左键痕迹动作 |
|---|:---:|---|---|
| →↓（向右再向下） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/→↓.png" width="32" alt="→↓" /> | 定位到地址栏 | 无 |
| ↑←（向上再向左） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↑←.png" width="32" alt="↑←" /> | 撤销关闭标签页 | 无 |
| ↑→（向上再向右） | <img src="https://raw.githubusercontent.com/poerin/Stroke/main/Material/GestureImages/↑→.png" width="32" alt="↑→" /> | 新建标签页 | 无 |

> 网页浏览器专属动作包默认仅适配 firefox、chrome、edge、zen 浏览器，您可根据使用需求自行添加其他浏览器进程规则。

## 核心概念

### 动作包
动作包是一组与特定应用程序绑定的动作集合。包内包含一组正则表达式模式，用于与光标下方窗口的进程完整路径进行匹配。模式匹配按从后向前的顺序进行，因此将具体程序的包放在列表下方可使其优先级高于通用包。全局包应置于列表顶部。

### 手势识别与特殊手势
按住设定的手势键时，Stroke 识别两类输入：

- **空间手势：** 鼠标轨迹被转换为一组方向向量，并与所有已存手势进行比较，相似度超过内部阈值时触发相应动作。算法天然支持任意连续轨迹。
- **特殊手势：** 在手势键保持按下状态的同时快速点击另一个鼠标按键或滚动滚轮，无需移动光标即可触发。

### 按键痕迹
绘制手势期间按下额外的鼠标按钮可为手势附加修饰信息。鼠标共有五个标准按键，其中一个被指定为手势键，其余四个可单独或组合按下，形成 16 种不同的按键痕迹状态。痕迹以整数形式传入脚本。每个按键对应唯一的位掩码，同时按下多个按键时通过位或运算得到组合值。每个动作的 C# 代码在启动时编译成方法，并接收该按键痕迹整数值作为参数。

| 按键 | 掩码 |
|---|---|
| Left（左键） | `0x00000001` |
| Right（右键） | `0x00000002` |
| XButton1 | `0x00000004` |
| XButton2 | `0x00000008` |
| Middle（中键） | `0x00000010` |

## 使用 Base 库编写脚本

`Base` 类提供了一组丰富的静态方法和属性，用于在动作代码中与系统交互。

### 输入模拟

- **`Base.PressKeys(string keys)`**: 用于模拟复杂按键序列的领域特定语言。  
    字面字符：`A`‑`Z`、`0`‑`9`。  
    修饰键：`(` 按下 Ctrl，`)` 释放 Ctrl，`[` 按下 Shift，`]` 释放 Shift，`{` 按下 Alt，`}` 释放 Alt，`<` 按下 Win，`>` 释放 Win。  
    特殊命令：`/T`（Tab）、`/R`（Enter）、`/E`（Escape）、`/S`（Space）、`/B`（Backspace）、`/I`（Insert）、`/D`（Delete）。  
    虚拟键码：`#` 后跟两位十六进制数，键码参考表见 [Keys.xlsx](https://github.com/poerin/Stroke/raw/main/Material/Keys.xlsx)。
- **`Base.PressKey(Keys key)`**: 按下并释放单个按键。
- **`Base.KeyDown(Keys key)`**、**`Base.KeyUp(Keys key)`**: 发送按键按下或释放事件。
- **`Base.IsKeyDown(Keys key)`**、**`Base.IsKeyToggled(Keys key)`**: 查询按键的物理状态。
- **`Base.MouseMove(int x, int y)`**、**`Base.MouseMoveRelative(int offsetX, int offsetY)`**: 将鼠标移动到绝对坐标或相对偏移位置。
- **`Base.MouseDown(MouseButtons button)`**、**`Base.MouseUp(MouseButtons button)`**、**`Base.MouseClick(MouseButtons button)`**、**`Base.MouseDoubleClick(MouseButtons button)`**: 模拟鼠标按键事件。
- **`Base.MouseWheel(int delta)`**、**`Base.MouseHorizontalWheel(int delta)`**: 发送垂直或水平滚轮事件。
- **`Base.GetMousePosition()`**: 获取当前鼠标位置。

### 窗口管理

所有窗口方法均接受一个可选的句柄参数；若省略，则默认操作手势起始点下方的根窗口。

- **`Base.Activate(IntPtr handle = default)`**: 激活窗口至前台。
- **`Base.SetWindowState(WindowState state, IntPtr handle = default)`**: 设置窗口状态（Normal、Minimized、Maximized、Closed）。
- **`Base.GetWindowState(IntPtr handle = default)`**: 查询窗口当前状态。
- **`Base.IsTopmost(IntPtr handle = default)`**、**`Base.TopmostOn(IntPtr handle = default)`**、**`Base.TopmostOff(IntPtr handle = default)`**: 检查或切换窗口的置顶属性。
- **`Base.GetWindowClassName(IntPtr handle = default)`**、**`Base.GetWindowText(IntPtr handle = default)`**: 获取窗口类名或标题。
- **`Base.GetWindowProcessId(IntPtr handle = default)`**: 获取创建该窗口的进程 ID。

### 系统与进程

- **`Base.Run(string fileName, string arguments = "", string workingDirectory = "")`**: 启动一个可执行文件或打开一个文档。若未提供工作目录，则默认使用可执行文件所在目录。

### 画笔定制

- **`Base.PenColor`**、**`Base.PenOpacity`**（0‑1）、**`Base.PenThickness`**（0‑10）：运行时读取或修改屏幕上绘制轨迹的外观。

### 全局状态与实用工具

- **`Base.Data`**: 一个可在多次脚本调用之间持久保存数据的共享字典。
- **`Base.KeyPoint`**: 手势起始点的屏幕坐标。
- **`Base.KeyboardHook`**: 通过 `KeyboardAction` 事件订阅全局键盘事件。使用 `StartHook()` 与 `StopHook()` 控制钩子。在事件处理函数中返回 `true` 可阻止按键继续传递。

## 配置工具

图形化配置程序提供便捷的设置管理。主窗口包含工具栏和工作区，工作区左侧为动作树，右侧为属性编辑器。工具栏可打开以下设置面板。

### 画笔设置
调整画笔的颜色、不透明度（0‑100 %）以及粗细（0‑10 像素）。将不透明度或粗细设为零即可完全隐藏手势轨迹。

### 手势设置
列出所有已存储的手势。在列表项上右键单击可添加或删除手势。选中某项后可编辑其名称。预览窗格显示手势形状；用鼠标左键或右键点击预览区域进入绘制状态，再使用手势键绘制手势即可对现有模式进行修正，新轨迹会与原有数据融合。在预览上使用中键单击可将手势重置为空白。

### 动作树
树形结构组织动作包及其下属动作。右键单击动作包节点可添加或移除动作包；右键单击动作节点可添加或移除动作。选中节点后，右侧编辑器将显示对应内容：
- 处于动作包节点时，可编辑包名称以及用于匹配进程路径的正则表达式（每行一个）。
- 处于动作节点时，可设置动作名称、选择触发该动作的普通手势或特殊手势，以及编写要执行的 C# 代码。编辑器旁边提供“添加路径”按钮：点击后按住并拖曳出现的十字准星至目标窗口，释放鼠标即可捕获进程路径并插入转义后的正则表达式。

### 编译设置
指定脚本所需的额外 .NET 程序集和命名空间。程序集将在代码编译时被引用；列出的命名空间会自动导入每个脚本。

### 过滤设置
定义 Stroke 应完全禁用的窗口进程路径模式（正则表达式）。同样提供“添加路径”按钮，便于快速捕获窗口路径。

### 线程设置
设定用于执行脚本的线程池大小。较大的值允许更多脚本同时运行，适用于包含较长延时或阻塞调用的动作。默认值为 8，有效范围 1 到 64。

### 本地化
配置工具支持通过 `Languages` 子目录下的 UTF‑8 文本文件进行界面翻译。文件命名采用语言代码或语言‑区域代码（如 `zh` 或 `ja‑JP`）。程序会根据当前系统区域选择最佳匹配的语言文件。

## 常见问题解答

**为什么重绘的手势没有完全按照新的轨迹改变？**  
为提高稳定性，新的绘制会与原有手势数据融合，每次重绘以 10% 的权重累加到现有模式中。如需完全重置，可在手势预览上使用中键单击。

**如何隐藏屏幕上的画笔痕迹？**  
在画笔设置中将不透明度或粗细设为 0 即可。

**为什么动作在某些应用中不触发？**  
首先确认该应用进程路径能匹配某一动作包中的模式。此外需确保 Stroke 以同等或更高权限运行；未提权的 Stroke 无法操作已提权的窗口。

**如何使用外部 DLL？**  
将自定义的 .NET DLL 放置到 `Stroke.exe` 所在目录，它们将在脚本编译时被自动引用。为辅助类型使用 `Stroke` 命名空间可使其无需额外导入即可直接使用。

**如何实现开机自启动？**  
使用 Windows 任务计划程序创建一个任务，触发器设为“登录时”，操作指定到 `Stroke.exe`，并将“起始于”填写为该执行文件所在的目录。如需操作已提权窗口，可勾选“使用最高权限运行”。

**线程数量有什么影响？**  
它决定了可同时执行脚本的最大数量。若动作中包含等待或长时间操作，增加线程数可改善响应能力。每增加一个线程会略微增加内存占用。

## 参与贡献

欢迎参与贡献。请通过 Issue 或 Pull Request 提出改进建议或问题修复。

## 许可证

本项目基于 MIT 许可证开源。详情请参阅 `LICENSE` 文件。
