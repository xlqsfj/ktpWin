@echo off
@echo off
set filename=LXServer.exe
set servicename=Service1
set Frameworkdc=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
 
if exist "%Frameworkdc%" goto netOld 
:DispError 
echo 您的机器上没有安装 .net Framework 4.0,安装即将终止.
echo 您的机器上没有安装 .net Framework 4.0,安装即将终止  >InstallService.log
goto LastEnd 
:netOld 
cd %Frameworkdc%
echo 您的机器上安装了相应的.net Framework 4.0,可以安装本服务. 
echo 您的机器上安装了相应的.net Framework 4.0,可以安装本服务 >InstallService.log
echo.
echo. >>InstallService.log

C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe %~dp0\KtpAcsMiddleware.WinServvice.exe
net start KtpAcsMiddlewareService
echo -----------------------------
echo         服务安装成功
echo -----------------------------
pause