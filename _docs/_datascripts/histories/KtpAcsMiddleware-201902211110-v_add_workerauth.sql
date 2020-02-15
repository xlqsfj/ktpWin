USE [KtpAcsMiddleware]
GO

/****** Object:  Table [dbo].[WorkerAuth]    Script Date: 02/21/2019 11:22:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

GO

ALTER TABLE [dbo].[WorkerAuth]  WITH CHECK ADD  CONSTRAINT [FK_WorkerAuth_Worker] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WorkerAuth] CHECK CONSTRAINT [FK_WorkerAuth_Worker]
GO

ALTER TABLE [dbo].[WorkerAuth] ADD  CONSTRAINT [DF_WorkerAuth_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO


