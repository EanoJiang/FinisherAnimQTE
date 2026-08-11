> ContextualAnimationk教程参考：[vorixo.github.io/devtricks/contextual-anim](https://vorixo.github.io/devtricks/contextual-anim/)

确保动画序列开启Root Motion

设置动画蒙太奇的Montage Section

Attacker

![1786436858979](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180358341-1620957441.png)

Victim

![1786441042385](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180359233-990953543.png)

添加插件Motion Warping 和ContextualAnimation

![1786437004425](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180359641-1956571383.png)

![1786436975098](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400064-568891424.png)

Player和Enemy都设置Rotation.Z为-90

![1786439497166](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400274-1776141192.png)

创建DataAsset(Contextual Anim Roles Asset)

![1786439614743](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400525-1438180955.png)

![1786439794424](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180400827-370894633.png)

创建Contextual Anim Sequence

![1786440470870](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401069-783591626.png)

![1786440496052](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401329-522020442.png)

然后新建AnimSet

![1786440545062](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401573-1149026138.png)

![1786440394637](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180401869-139183247.png)

设置AM_Attacker的Mesh属性

![1786441203867](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180402251-358623294.png)

![1786441160124](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180402698-881139959.png)

设置MotionWarping点——Notify State

![1786441289714](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403134-1756808891.png)

让MotionWarping点处于Enter阶段

![1786441395992](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403349-61532613.png)

设置好WarpTargetName

> `Warp Target Name` 是 **Motion Warping（运动扭曲）** 中用于指定“要朝哪个目标进行根运动校正”的 **标识名** 。这是一个 `FName` 键。动画播放到这个带有 `Skew Warp` 的 Anim Notify State 区间时，系统会去角色的 `MotionWarpingComponent` 中查找名为 `Attacker` 的 Warp Target。找到后，会在该 Notify 的时间段内动态修正动画的 Root Motion，使角色尽量对齐到这个目标的位置和/或朝向。

![1786441501408](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403656-434809812.png)

BlendIn设置为Inertialization(带惯性)

![1786441652767](https://img2024.cnblogs.com/blog/3614909/202608/3614909-20260811180403893-857306379.png)
