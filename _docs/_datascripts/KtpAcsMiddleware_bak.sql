-- �����ļ���
declare @database_name varchar(1024)
declare @backupset_name varchar(1024)
declare @filename_initial varchar(1024)
declare @filename varchar(1024)
declare @path varchar(1024)
set @path = N'D:\mymssqlbak\';--��·�������Ѵ���,Ҳ�ɻ��ɱ��·��
declare @extension_name varchar(16)
set @extension_name = N'bak';
set @filename = convert(varchar(1024), getdate(), 120)
set @filename = replace(@filename, ':', '')
set @filename = replace(@filename, '-', '')
set @filename = replace(@filename, ' ', '')
set @filename =@filename + '_' + convert (varchar(3), datepart(ms, getdate())) + N'.' + @extension_name
set @filename_initial=@filename
---���ݿ�---------------------------------------------------------------------------------------------------------------------------
-- �õ�����Ŀ���ļ������ݿ⽫���ݵ����(@filename)��
set @database_name = N'KtpAcsMiddleware';
set @backupset_name =@database_name + N'-���� ���ݿ� ����'
set @filename = @path + @database_name+ '_' + @filename_initial
--select @filename
 
-- ��ʼ����, KtpAcsMiddleware ����Ҫ���ݵ����ݿ�, COMPRESSION ������ʾѹ�����ɽ�ʡ���̿ռ�
backup database [KtpAcsMiddleware] to disk = @filename with noformat, noinit, 
name = @backupset_name, skip, norewind, nounload,  stats = 10