[Introduction]
1.Demo SDK initialization,login device,logout device, control the card password, open door, query status,receive real-time information about open door function.
2.Demo how to add,delete and edit the card information, query the door status,open door mode,show receive the information.

[Interfaces]
NETClient.Init Initialize SDK
NETClient.SetDVRMessCallBack Set alarm callback
NETClient.LoginWithHighLevelSecurity Login
NETClient.Logout Logout
NETClient.GetNewDevConfig configuration get,Access control, multi-person combination to open the door, Repeat Enter Route, card time, door configuration, holiday configuration
NETClient.SetNewDevConfig configuration set,Access control, multi-person combination to open the door, Repeat Enter Route, card time, door configuration, holiday configuration
NETClient.GetDevConfig Get the time zone
NETClient.RealPlay Start real time monitor
NETClient.StopRealPlay Stop monitor
NETClient.RebootDev Reboot device
NETClient.GetDevConfig Get device time
NETClient.SetDevConfig Set device time
NETClient.ControlDevice Collect fingerprint
NETClient.StartQueryLog query log
NETClient.ControlDevice Open door, close door, add card, modify card, delete card, clear card, and collect fingerprint
NETClient.StartListen Start listening event
NETClient.StopListen Stop listening event
NETClient.FindRecord  Query card
NETClient.FindNextRecord Query the details of the card
NETClient.QueryDevState Get fingerprint
NETClient.FindRecordClose Close query
NETClient.FaceInfoOpreate Add, modify, delete and clear face
NETClient.Cleanup Release SDK resources

[Notice]
When the compiling environment is VS2010, NETSDKCS library can support the version of .NET Framework 4.0 or newer. If you want to use the version older than .NET Framework 4.0, change the method of using NetSDK.cs in IntPtr.Add. We will not support the modification.
Copy all file in the libs directory of General_NetSDK_ChnEng_CSharpXX_IS_VX.XXX.XXXXXXXX.X.R.XXXXXX to the build directory of bin directory of the corresponding demo programs.

【演示程序功能】
1、Demo介绍SDK初始化、登陆设备、登出设备、门禁卡片密码操作、远程开门控制、状态查询、开门信息实时上报等功能。
2、Demo演示了门禁卡片密码增删改查的核心功能，查询开门状态，远程开门方式，实时接收开门信息上报等功能。

【接口列表】
NETClient.Init SDK初始化
NETClient.SetDVRMessCallBack 设置报警回调
NETClient.LoginWithHighLevelSecurity 登录设备
NETClient.Logout 登出设备
NETClient.GetNewDevConfig 配置获取,门禁，多人组合开门，防反潜，刷卡时间，门配置，假期配置
NETClient.SetNewDevConfig 配置设置，门禁，多人组合开门，防反潜，刷卡时间，门配置，假期配置
NETClient.GetDevConfig 获取时区
NETClient.RealPlay 实时监视
NETClient.StopRealPlay 停止监视
NETClient.RebootDev 重启设备
NETClient.GetDevConfig 获取设备时间
NETClient.SetDevConfig 设置设备时间
NETClient.ControlDevice 采集指纹
NETClient.StartQueryLog 日志查询
NETClient.ControlDevice 开门、关门、增加卡、修改卡、删除卡、清空卡、指纹采集
NETClient.StartListen 开始监听报警事件
NETClient.StopListen 停止监听报警事件
NETClient.FindRecord 查询卡
NETClient.FindNextRecord 查询卡详细信息
NETClient.QueryDevState 获取指纹信息
NETClient.FindRecordClose 关闭查询
NETClient.FaceInfoOpreate 增加人脸、修改人脸、删除人脸、清空人脸
NETClient.Cleanup 释放SDK资源

【注意事项】
1、编译环境为VS2010，NETSDKCS库最低只支持.NET Framework 4.0,如用户需要支持低于4.0的版本需要更改NetSDK.cs文件中使用到IntPtr.Add的方法,我们不提供修改。
2、请把General_NetSDK_ChnEng_CSharpXX_IS_VX.XXX.XXXXXXXX.X.R.XXXXXX中libs目录中的所有文件复制到对应该演示程序中bin目录下的生成目录中。
