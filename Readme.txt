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

����ʾ�����ܡ�
1��Demo����SDK��ʼ������½�豸���ǳ��豸���Ž���Ƭ���������Զ�̿��ſ��ơ�״̬��ѯ��������Ϣʵʱ�ϱ��ȹ��ܡ�
2��Demo��ʾ���Ž���Ƭ������ɾ�Ĳ�ĺ��Ĺ��ܣ���ѯ����״̬��Զ�̿��ŷ�ʽ��ʵʱ���տ�����Ϣ�ϱ��ȹ��ܡ�

���ӿ��б�
NETClient.Init SDK��ʼ��
NETClient.SetDVRMessCallBack ���ñ����ص�
NETClient.LoginWithHighLevelSecurity ��¼�豸
NETClient.Logout �ǳ��豸
NETClient.GetNewDevConfig ���û�ȡ,�Ž���������Ͽ��ţ�����Ǳ��ˢ��ʱ�䣬�����ã���������
NETClient.SetNewDevConfig �������ã��Ž���������Ͽ��ţ�����Ǳ��ˢ��ʱ�䣬�����ã���������
NETClient.GetDevConfig ��ȡʱ��
NETClient.RealPlay ʵʱ����
NETClient.StopRealPlay ֹͣ����
NETClient.RebootDev �����豸
NETClient.GetDevConfig ��ȡ�豸ʱ��
NETClient.SetDevConfig �����豸ʱ��
NETClient.ControlDevice �ɼ�ָ��
NETClient.StartQueryLog ��־��ѯ
NETClient.ControlDevice ���š����š����ӿ����޸Ŀ���ɾ��������տ���ָ�Ʋɼ�
NETClient.StartListen ��ʼ���������¼�
NETClient.StopListen ֹͣ���������¼�
NETClient.FindRecord ��ѯ��
NETClient.FindNextRecord ��ѯ����ϸ��Ϣ
NETClient.QueryDevState ��ȡָ����Ϣ
NETClient.FindRecordClose �رղ�ѯ
NETClient.FaceInfoOpreate �����������޸�������ɾ���������������
NETClient.Cleanup �ͷ�SDK��Դ

��ע�����
1�����뻷��ΪVS2010��NETSDKCS�����ֻ֧��.NET Framework 4.0,���û���Ҫ֧�ֵ���4.0�İ汾��Ҫ����NetSDK.cs�ļ���ʹ�õ�IntPtr.Add�ķ���,���ǲ��ṩ�޸ġ�
2�����General_NetSDK_ChnEng_CSharpXX_IS_VX.XXX.XXXXXXXX.X.R.XXXXXX��libsĿ¼�е������ļ����Ƶ���Ӧ����ʾ������binĿ¼�µ�����Ŀ¼�С�
