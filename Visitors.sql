IF OBJECT_ID(N'[dbo].[Visitors]') IS NOT NULL
	DROP TABLE [dbo].[Visitors]

CREATE TABLE [dbo].[Visitors]
(
    [Id] int IDENTITY(1, 1),
    [Fullname] nvarchar(255),
    [Phone] nvarchar(20),
    [LastEnterDate] datetime,
    [CreateDate] datetime default(getutcdate()),
    [Comments] nvarchar(max),
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id])
)

CREATE NONCLUSTERED INDEX [IX_Visitors_LastEnterDate] ON [dbo].[Visitors] ([LastEnterDate])

CREATE FULLTEXT CATALOG FTC_Visitors

CREATE FULLTEXT INDEX ON [dbo].[Visitors] ([Comments]) KEY INDEX [PK_Visitors] ON FTC_Visitors

SET IDENTITY_INSERT [dbo].[Visitors] ON

INSERT INTO [dbo].[Visitors]
           ([Id]
           ,[Fullname]
           ,[Phone]
           ,[LastEnterDate]
           ,[CreateDate]
           ,[Comments])
     VALUES
           (1
           ,'Vassea'
           ,'052341122'
           ,'01-01-2019 12:32:00'
           ,'01-01-2019 12:00:00'
           ,'Vassea Comments')

INSERT INTO [dbo].[Visitors]
           ([Id]
           ,[Fullname]
           ,[Phone]
           ,[LastEnterDate]
           ,[CreateDate]
           ,[Comments])
     VALUES
           (2
           ,'Yura'
           ,'053332122'
           ,'01-01-2019 11:41:41'
           ,'01-01-2019 11:41:00'
           ,'Yura Comments')

INSERT INTO [dbo].[Visitors]
           ([Id]
           ,[Fullname]
           ,[Phone]
           ,[LastEnterDate]
           ,[CreateDate]
           ,[Comments])
     VALUES
           (3
           ,'Shurik'
           ,'053332122'
           ,'01-02-2019 11:43:00'
           ,'01-02-2019 11:41:00'
           ,'Shurik Comments')

SET IDENTITY_INSERT [dbo].[Visitors] OFF
