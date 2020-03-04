CREATE TABLE [dbo].[Phone]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	PhoneNumber char(12) NOT NULL,
	PhoneType int not NULL Foreign Key (PhoneType) References [dbo].[PhoneType] ([ID]),
	OtherDesc varchar(50)

)
