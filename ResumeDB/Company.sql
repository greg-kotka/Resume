CREATE TABLE [dbo].[Company]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	CompanyName varchar(50) NOT NULL,
	City varchar(50) NOT NULL,
	[State] varchar(50) NOT NULL,
	Logo NVARCHAR(MAX), 
    [Link] VARCHAR(300) NULL, 

    
)
