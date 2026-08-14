> ContextualAnimationk教程参考：[vorixo.github.io/devtricks/contextual-anim](https://vorixo.github.io/devtricks/contextual-anim/)

# PART 01 处决动画

## 动画序列与蒙太奇

确保动画序列开启Root Motion

设置动画蒙太奇的Montage Section

Attacker

![1786436858979](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180358341-1620957441.png)

Victim

![1786441042385](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180359233-990953543.png)

## 插件

添加插件Motion Warping 和ContextualAnimation

![1786437004425](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180359641-1956571383.png)

![1786436975098](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400064-568891424.png)

## 角色蓝图Mesh

Player和Enemy都设置Rotation.Z为-90

![1786439497166](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400274-1776141192.png)

## Contextual Anim

创建DataAsset(Contextual Anim Roles Asset)

![1786439614743](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400525-1438180955.png)

![1786439794424](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400827-370894633.png)

创建Contextual Anim Scene

![1786440470870](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401069-783591626.png)

![1786440496052](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401329-522020442.png)

然后新建AnimSet

![1786440545062](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401573-1149026138.png)

![1786440394637](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401869-139183247.png)

设置AM_Attacker的Mesh属性

![1786441203867](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180402251-358623294.png)

![1786441160124](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180402698-881139959.png)

## 动画蒙太奇的MotionWarping点

设置MotionWarping点——Notify State

![1786441289714](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403134-1756808891.png)

让MotionWarping点处于AM_Attacker的Enter阶段

![1786441395992](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403349-61532613.png)

处于AM_Victim的Enter阶段稍微靠后

![1786503542192](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170956614-613559112.png)

设置好WarpTargetName

> `Warp Target Name` 是 **Motion Warping（运动扭曲）** 中用于指定“要朝哪个目标进行根运动校正”的 **标识名** 。这是一个 `FName` 键。动画播放到这个带有 `Skew Warp` 的 Anim Notify State 区间时，系统会去角色的 `MotionWarpingComponent` 中查找名为 `Attacker` 的 Warp Target。找到后，会在该 Notify 的时间段内动态修正动画的 Root Motion，使角色尽量对齐到这个目标的位置和/或朝向。

![1786441501408](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403656-434809812.png)

![1786503628628](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170957135-1321680809.png)

BlendIn设置为Inertialization(带惯性)

![1786503339808](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170957362-699271454.png)

记得在动画蓝图中添加Inertialization节点

![1786503466064](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170957609-1138187362.png)

回到Contextual Anim Scene，设置

![1786503888132](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170957814-435717190.png)

点击更新Warp点

![1786504318216](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170958034-1947277522.png)

## AnimNotifyBlueprint与触发事件

新建AnimNotifyBlueprint

![1786609671056](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162755635-402037637.png)

添加函数继承ReceivedNotify接收通知

![1786504432647](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170958451-1918275068.png)

在Enemy的角色蓝图中添加球形触发器

![1786505617504](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170958666-3376303.png)

![1786505660180](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170959026-69557496.png)

添加碰撞重叠触发事件

![1786523655182](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170959341-1005952997.png)

![1786523724255](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812170959635-1619963378.png)

![1786524987229](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812171000098-1495401037.png)

添加推开敌人事件和重置事件

![1786525086526](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812171000334-1056971255.png)

AnimNotifyBlueprint中的接收函数逻辑如下：

![1786525352832](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812171000925-979884728.png)

在AM_Attacker中的Exit阶段的末尾添加该AnimNotify

![1786609629488](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162756095-52989323.png)

## 交互键

在Player的角色蓝图中添加交互键触发事件

![1786525167068](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812171000553-638842482.png)

## 最终效果

不按推开交互键

![1786525857459](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812171318960-1038014782.gif)

按交互键

![1786525929243](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260812171321919-361371259.gif)

# PART 02 QTE处决动画

### WidgetBlueprint UI

![1786592308583](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162756355-1220360032.png)

元素

![1786592257923](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162756963-1384798732.png)

![1786676677260](image/ContextualAnim实现处决动画QTE/1786676677260.png)

UI动画

![1786592331618](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162757173-2034339289.png)

![1786592342145](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162757404-1597833602.png)

![1786592353735](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162757600-1464418102.png)

![1786676630678](image/ContextualAnim实现处决动画QTE/1786676630678.png)

函数

![1786592406972](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162757781-1060853541.png)

![1786592427118](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260813162758062-4220258.png)

![1786676647923](image/ContextualAnim实现处决动画QTE/1786676647923.png)

## BP_Player

![1786678211709](image/ContextualAnim实现处决动画QTE/1786678211709.png)

### WB_QTE_Setup

![1786677806261](image/ContextualAnim实现处决动画QTE/1786677806261.png)

### QTE_Events

![1786679629724](image/ContextualAnim实现处决动画QTE/1786679629724.png)

#### QTE_Start

![1786678171193](image/ContextualAnim实现处决动画QTE/1786678171193.png)

#### QTE_Update

![1786678406301](image/ContextualAnim实现处决动画QTE/1786678406301.png)

#### QTE_Successed

![1786678557955](image/ContextualAnim实现处决动画QTE/1786678557955.png)

#### QTE_Failed

![1786679618721](image/ContextualAnim实现处决动画QTE/1786679618721.png)

#### Hide_WB_QTE

![1786679656439](image/ContextualAnim实现处决动画QTE/1786679656439.png)

### QTE_Filling

![1786679864785](image/ContextualAnim实现处决动画QTE/1786679864785.png)
