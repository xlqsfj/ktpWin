@echo off
@echo off
set filename=LXServer.exe
set servicename=Service1
set Frameworkdc=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
 
if exist "%Frameworkdc%" goto netOld 
:DispError 
echo ���Ļ�����û�а�װ .net Framework 4.0,��װ������ֹ.
echo ���Ļ�����û�а�װ .net Framework 4.0,��װ������ֹ  >InstallService.log
goto LastEnd 
:netOld 
cd %Frameworkdc%
echo ���Ļ����ϰ�װ����Ӧ��.net Framework 4.0,���԰�װ������. 
echo ���Ļ����ϰ�װ����Ӧ��.net Framework 4.0,���԰�װ������ >InstallService.log
echo.
echo. >>InstallService.log

C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe %~dp0\KtpAcsMiddleware.WinServvice.exe
net start KtpAcsMiddlewareService
echo -----------------------------
echo         ����װ�ɹ�
echo -----------------------------
pause