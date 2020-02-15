use KtpAcsMiddleware;
 
declare @hasItem int;
--�½�WorkerAuth��------------------------------------------------------------------------
set @hasItem= (SELECT COUNT(*) FROM information_schema.TABLES WHERE table_name ='WorkerAuth')
if (@hasItem=0)
begin
CREATE TABLE [dbo].[WorkerAuth](
	[Id] [nvarchar](50) NOT NULL,
	[WorkerId] [nvarchar](50) NOT NULL,
	[TeamId] [nvarchar](50) NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[ClockType] [int] NOT NULL,
	[ClockTime] [datetime] NOT NULL,
	[SimilarDegree] [decimal](18, 3) NOT NULL,
	[IsPass] [bit] NOT NULL,
	[ClockPicId] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[AuthId] [nvarchar](50) NULL,
	[ClientCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WorkerAuth] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[WorkerAuth]  WITH CHECK ADD  CONSTRAINT [FK_WorkerAuth_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
ALTER TABLE [dbo].[WorkerAuth] CHECK CONSTRAINT [FK_WorkerAuth_Worker]
ALTER TABLE [dbo].[WorkerAuth] ADD  CONSTRAINT [DF_WorkerAuth_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
select '�½�WorkerAuth==���'
end
else
begin
select 'WorkerAuth���Ѵ���'
end
--�½�Team.LeaderId�ֶ�------------------------------------------------------------------------
set @hasItem = (select count(*) from information_schema.columns where table_name = 'Team' and column_name = 'LeaderId')
if (@hasItem=0)
begin
alter table [Team] add [LeaderId] nvarchar(50) null;
end
else
begin
select 'Team.LeaderId�ֶ��Ѵ���'
end