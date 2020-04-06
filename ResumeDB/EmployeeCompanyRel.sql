CREATE TABLE [dbo].[EmployeeCompanyRel]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[UserInfo_ID] INT NOT NULL Foreign KEY ([UserInfo_ID]) REFERENCES [dbo].[UserInfo]([ID]),
	Company_ID INT NOT NULL Foreign Key ([Company_ID]) REFERENCES [dbo].[Company]([ID]),
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	
)
