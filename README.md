Stroke 是一款鼠标手势程序。它允许你通过划动鼠标来执行特定的操作。你可以使用 Stroke.Configure 来帮助你轻松地完成相关的设定。

首先你需要了解的是“动作”和“动作包”的概念，动作包是若干动作的集合，这里的动作指的是通过特定的手势执行特定的操作，这些操作需要你编写 C# 代码来实现，你的代码最终会在程序运行时插入到一个临时创建的方法体中。为了方便使用，你可以自行编写动态链接库（dll），其命名空间建议使用“Stroke”，否则在编写脚本的时候你需要指定其所在的命名空间。另外，大多数常用的 .NET Framework 的命名空间已经被引入，你可以在脚本中直接使用。动作包主要是为了匹配操作环境而设计的，这里的操作环境指的是当前被操作的窗体（位于手势起点下方的窗体），你需要在动作包的代码区域填写正则表达式来匹配窗体所属程序的路径，每行填写一条模式字符串，若路径与某条模式字符串之间存在匹配成功的部分则动作包里的动作才有可能被触发。每次使用鼠标划出手势最多只能触发一个动作，且动作包的匹配顺序是从后往前的，换句话说，如果在后面的动作包中有动作匹配成功了，那么其他的所有在它前面动作包内的动作都将不会再被触发。因此，建议将全局类动作包放在靠前的位置，这样就不会影响特定程序的动作匹配了。  
按键痕迹：当你按下手势鼠标键后，其余的鼠标键在被按下时将被记录，从而你可以根据痕迹的不同来使得动作具有不同的含义。痕迹在脚本中使用标识符“_”来获取，根据不同的按键，痕迹中相应的位将被置成“1”，因此除去被设置为手势鼠标键的按键外，还有 4 个按键可能被记录痕迹，你可以根据它们来区分 16 种不同的情况：
- Left：0x00000001
- Right：0x00000002
- XButton1：0x00000004
- XButton2：0x00000008
- Middle：0x00000010

## Base 库

为了方便你编写实用的脚本，我提供了 Base.dll，以下介绍这个库所提供的功能：

- Base.Data：是一个 Dictionary<string, object> 类型的对象，它能够解决脚本中只能声明局部变量的问题。
- Base.KeyPoint：是一个 Point 类型的对象，它能够获取当前手势的起点。
- Base.PenColor：是一个 Color 类型的对象，它能够获取或设置当前画笔的颜色。
- Base.PenOpacity：是一个 double 类型的对象（取值范围为 \[0,1\]），它能够获取或设置当前画笔的不透明度。
- Base.PenThickness：是一个 byte 类型的对象（取值范围为 \[0,10\]），它能够获取或设置当前画笔的粗细。
- Base.KeyDown(Keys key)：按下键盘上的某个键。Keys 定义在 [System.Windows.Forms.Keys](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys) 中。
- Base.KeyUp(Keys key)：弹起键盘上的某个键。
- Base.PressKeys(string keys)：允许你执行一串按键序列操作。以下列出该函数所支持的所有字符（不区分大小写）及其含义：
  - 所有英文字母和数字：按下并弹起对应的键。
  - 修饰键：
    - (：按下 Ctrl 键。
    - )：弹起 Ctrl 键。
    - \[：按下 Shift 键。
    - \]：弹起 Shift 键。
    - {：按下 Alt 键。
    - }：弹起 Alt 键。
    - \<：按下 Win 键。
    - \>：弹起 Win 键。
  - 转义：
    - /t：Tab 键。
    - /r：Return (Enter) 键。
    - /e：Escape 键。
    - /s：Space 键。
    - /b：Backspace 键。
    - /i：Insert 键。
    - /d：Delete 键。
  - 键码：使用`#FF`的形式输入 Windows 虚拟键。`#`符号后接受两位十六进制数，具体请查看 [Keys.xlsx](https://github.com/poerin/Stroke/raw/master/Material/Keys.xlsx)。
- Base.IsKeyDown(Keys key)：某个键是否按下。
- Base.IsKeyToggled(Keys key)：某个键是否开启（例如：CapsLock）。
- Base.Activate(IntPtr handle = default)：激活窗体。
- Base.WindowState：它是关于窗体的状态的枚举类型，有以下四种：
  - Normal：正常。
  - Minimize：最小化。
  - Maximize：最大化。
  - Close：关闭。
- Base.SetWindowState(WindowState state, IntPtr handle = default)：设置窗体的状态。
- Base.GetWindowState(IntPtr handle = default)：获取窗体的状态，返回类型为 Base.WindowState。
- Base.GetWindowClassName(IntPtr handle = default)：获取窗体的类名。
- Base.GetWindowText(IntPtr handle = default)：获取窗体的标题。
- Base.GetWindowProcessId(IntPtr handle = default)：获取创建窗体的进程的 ID。
- Base.IsTopmost(IntPtr handle = default)：判断窗体是否置顶。
- Base.TopmostOn(IntPtr handle = default)：置顶窗体。
- Base.TopmostOff(IntPtr handle = default)：取消置顶窗体。
- Base.Run(string fileName, string arguments = "", string workingDirectory = "")：启动指定的应用程序或文件。
- Base.KeyboardHook：键盘钩子工具类，它能够获取用户当前的键盘状态，成员如下：
  - KeyStates：它是关于按键状态的枚举类型，有以下三种：
    - None：没有按任何键。
    - Down：按下某键。
    - Up：弹起某键。
  - KeyboardActionArgs：键盘事件参数的类型，成员如下：
    - Key：它是一个 Keys 类型的对象，表示该事件相关的按键。
    - KeyState：它是一个 KeyStates 类型的对象，表示该事件相关的按键状态。
  - KeyboardActionHandler：事件处理函数的委托类型，它含有一个 KeyboardActionArgs 类型的参数以及 bool 类型的返回值。当返回值为 True 时，表示该事件已经被处理不再传递。
  - KeyboardAction：键盘事件，你应当将处理函数订阅到该事件。
  - StartHook()：启用键盘钩子。
  - StopHook()：停用键盘钩子。


## 常见问题

- 为什么我不能操作某些窗体（例如：任务管理器）？
由于 Stroke 选择了 uiAccess="false" 设置，你需要使用管理员权限运行 Stroke 时才能与这些界面交互。

- 我想开机就运行 Stroke，我该怎么做？
我推荐以下两种方式，可以根据你的需求进行选择。
第一种，使用任务计划程序，在常规选项卡勾选“使用最高权限运行”，触发器选择“登录时”，操作选择“启动程序”（注意：起始位置必须填写 Stroke.exe 所在的目录）。
第二种，将配置文件“Stroke/app.manifest”内的 uiAccess 属性设置为 true，编译并对程序进行签名，然后将整个目录放入“C:\Program Files”内，最后将 Stroke.exe 的快捷方式放入启动目录（shell:startup）。

- 我应该将写好的 dll 放在哪里？
请放在 Stroke.exe 所在的同一目录内。

- 我在写 dll 时需要知道当前操作的窗体的句柄，如何获取到它？
将 Stroke 引入你的项目，Stroke.CurrentWindow 就是当前窗体的句柄。

- 为什么我修改后的手势和我画的不一样？
当你重画已有手势的时候，Stroke.Configure 不会直接覆盖原有的手势，而是使用你新画的手势来修正它。你可以不断地重画已有的手势，这样能让它变得更一般化。

- 如何隐藏屏幕上的画笔？
在 Stroke.Configure 中将画笔的“不透明度”或“粗细”调至零即可。

- 为什么我每次打开 Stroke.Configure 时 Stroke 都会退出？
由于 Stroke 会影响 Stroke.Configure 进行手势设置，因此 Stroke.Configure 在启动时会结束 Stroke 的进程。请在完成设置之后自行启动 Stroke。
