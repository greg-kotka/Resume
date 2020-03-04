CREATE TABLE [dbo].[JobDescription]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	EmployeeCompanyRel_ID INT NOT NULL Foreign KEY ([EmployeeCompanyRel_ID]) REFERENCES [dbo].[EmployeeCompanyRel]([ID]),
	Title varchar(50) NOT NULL,
	Job_Description varchar(MAX),
	[StartDate] Date,
	[EndDate] Date,
	

)
