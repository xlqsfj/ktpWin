-- 创建文件名
declare @database_name varchar(1024)
declare @backupset_name varchar(1024)
declare @filename_initial varchar(1024)
declare @filename varchar(1024)
declare @path varchar(1024)
set @path = N'D:\mymssqlbak\';--此路径必须已存在,也可换成别的路径
declare @extension_name varchar(16)
set @extension_name = N'bak';
set @filename = convert(varchar(1024), getdate(), 120)
set @filename = replace(@filename, ':', '')
set @filename = replace(@filename, '-', '')
set @filename = replace(@filename, ' ', '')
set @filename =@filename + '_' + convert (varchar(3), datepart(ms, getdate())) + N'.' + @extension_name
set @filename_initial=@filename
---数据库---------------------------------------------------------------------------------------------------------------------------
-- 得到完整目标文件，数据库将备份到这个(@filename)中
set @database_name = N'KtpAcsMiddleware';
set @backupset_name =@database_name + N'-完整 数据库 备份'
set @filename = @path + @database_name+ '_' + @filename_initial
--select @filename
 
-- 开始备份, KtpAcsMiddleware 是需要备份的数据库, COMPRESSION 参数表示压缩，可节省磁盘空间
backup database [KtpAcsMiddleware] to disk = @filename with noformat, noinit, 
name = @backupset_name, skip, norewind, nounload,  stats = 10