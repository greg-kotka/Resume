CREATE TABLE [dbo].[JobDescription]
(
	[ID] INT NOT NULL PRIMARY KEY,
	CanidateInfo_ID INT NOT NULL Foreign KEY ([CanidateInfo_ID]) REFERENCES [dbo].[CanidateInfo]([ID]),
	CompanyID int NOT NULL Foreign Key (CompanyID) REFERENCES [dbo].[Company] ([ID]),
	Title varchar(50) NOT NULL,
	Job_Description varchar(2000),
	StartDate datetime,
	EndDate datetime
)
