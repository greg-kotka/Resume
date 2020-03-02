CREATE TABLE [dbo].[Company]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[CanidateInfo_ID] INT NOT NULL Foreign KEY ([CanidateInfo_ID]) REFERENCES [dbo].[CanidateInfo]([ID]),
	CompanyName varchar(50) NOT NULL,
	StartDate datetime NOT NULL,
	EndDate datetime NOT NULL,
	Logo IMAGE, 

    
)
