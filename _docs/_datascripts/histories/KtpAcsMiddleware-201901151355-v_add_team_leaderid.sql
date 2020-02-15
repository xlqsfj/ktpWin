use KtpAcsMiddleware;
------------------------------------------------------------
---Team
alter table [Team] add [LeaderId] nvarchar(50) null;
------------------------------------------------------------
---Worker
--alter table [Worker] add [BankCardTypeId] int null;
--alter table [Worker] add [BankCardCode] nvarchar(50) null;
