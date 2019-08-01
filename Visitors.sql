create table dbo.Visitors
(
 [Id] int primary key identity(1, 1),
 [Fullname] nvarchar(255),
 [Phone] nvarchar(20),
 [LastEnterDate] datetime,
 [CreateDate] datetime default(getutcdate()),
 [Comments] nvarchar(max)
)

INSERT INTO [dbo].[Visitors]
           ([Fullname]
           ,[Phone]
           ,[LastEnterDate]
           ,[CreateDate]
           ,[Comments])
     VALUES
           ('Vassea'
           ,'052341122'
           ,'01-01-2019 12:32:00'
           ,'01-01-2019 12:00:00'
           ,'Vassea Comments')
INSERT INTO [dbo].[Visitors]
           ([Fullname]
           ,[Phone]
           ,[LastEnterDate]
           ,[CreateDate]
           ,[Comments])
     VALUES
           ('Yura'
           ,'053332122'
           ,'01-01-2019 11:41:00'
           ,'01-01-2019 11:41:41'
           ,'Yura Comments')
INSERT INTO [dbo].[Visitors]
           ([Fullname]
           ,[Phone]
           ,[LastEnterDate]
           ,[CreateDate]
           ,[Comments])
     VALUES
           ('Shurik'
           ,'053332122'
           ,'01-02-2019 11:41:00'
           ,'01-02-2019 11:43:00'
           ,'Shurik Comments')
