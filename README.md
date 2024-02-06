# Azure-Function-Sql-Demo

Simple funcion to select data from Products table.


```sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Cost] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Sample Data******/
INSERT [dbo].[Products] ([ProductId], [Name], [Cost]) VALUES (1, N'Apple iPhone 13', 699)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Cost]) VALUES (2, N'Samsung Galaxy S21', 799)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Cost]) VALUES (3, N'Google Pixel 6', 599)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Cost]) VALUES (4, N'Microsoft Surface Pro 8', 1099)
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Cost]) VALUES (5, N'Dell XPS 13', 999)
GO
```

## Using Managed Identity of the function to connect to the DB

1. Enable Identity on the Function App (Sytem assigned or User Assigned)
2. Give the managed Identity permission on the SQL database

   ```sql
      CREATE USER [<<fnmid_name>>] FROM EXTERNAL PROVIDER;
      ALTER ROLE [db_datareader] ADD MEMBER [<<fnmid_name>>];
      ALTER ROLE [db_datawriter] ADD MEMBER [<<fnmid_name>>];
   ```

SQL Connection String to configure using MID:   ``` Server=<<ServerName>>; Authentication=Active Directory Managed Identity; Database=<<DBName>>;  ```
