# GraphShot

**GraphShot** 是一个 Unreal Engine 5 编辑器插件，用于把**任意图表面板**（蓝图、动画蓝图、ControlRig、材质/Material 等）**完整截图**（包括滚动到屏幕外而看不到的节点）复制到剪贴板。

## 功能特性

- **全图截图**：默认把当前图表面板的**所有节点与注释**完整渲染成一张大图并复制到剪贴板。
- **按选区截图（新增）**：在面板中选中了一部分**节点和/或注释（Comment）**时，只截取这一片选中区域；**没有选区**则回退为全图截图，行为与旧版完全一致。
  - 选中的动画注释气泡（`FGraphNodeComment` 继承自 `FGraphNode`）会像普通节点一样被纳入区域计算。
  - 未被选中的节点/注释 widget 会在截图前被隐藏，因此不会出现在最终结果里。
- 注释（Comment）也参与：因为 `SGraphNodeComment` 派生自 `SGraphNode`，选中动画中的注释气泡会与节点一起被截取。

## 使用方法

在任意图编辑器（蓝图事件图、ControlRig、Material、动画蓝图等）里：

1. 打开 **GraphShot**（工具栏上的插件按钮，或绑定的快捷键）。
2. 如果你只想截取**某一块区域**：在图上用鼠标框选/选中需要的节点与注释。
3. 点击触发的命令 —— 插件会把图渲染成图片并复制到剪贴板。
4. 直接 `Ctrl+V` 粘贴到文档/聊天/图床即可。

> **选区/范围**：有选区时按选中范围截取；否则整张图。

## 颜色/亮度校正（Gamma）

由于 Slate 把顶点/纯色按 sRGB 字节打包、却按线性采样 texture，所以单个 `FWidgetRenderer` 的 gamma 开关无法让两者都精确匹配屏幕上的观感。GraphShot 提供两个控制台变量（cvar）供你微调：

- **`GraphShot.UseGamma 0|1`** —— 渲染目标 sRGB 基底：`0`=线性 RT（偏暗），`1`=sRGB RT（偏亮）。默认 `1`。
- **`GraphShot.Gamma <float>`** —— 读回后的后置 gamma：`out = pow(rgb, Gamma)`；`>1` 变暗，`<1` 变亮，`1.0` 关闭。默认 `2.0`（本工程在 `UseGamma=1` 时的编辑器观感）。

```
GraphShot.UseGamma 1    GraphShot.Gamma 2.0
```

如果截图整体过亮，试试：`GraphShot.Gamma 2.2`（稍暗）。
如果整体偏暗，试试：`GraphShot.Gamma 1.8`。
或者换基底：`GraphShot.UseGamma 0` 之后重新调 `GraphShot.Gamma`。

## 数据/描述

- 插件名：`GraphShot`（.uplugin：`GraphShot.uplugin`）
- 编辑器模块：`GraphShotEditor`（独立于 `Source/GraphShotEditor/`）
- 实时调参由 `TAutoConsoleVariable` 实现，无需重新编译。