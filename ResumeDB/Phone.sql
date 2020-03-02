CREATE TABLE [dbo].[Phone]
(
	[Id] INT NOT NULL PRIMARY KEY,
	PhoneNumber char(12) NOT NULL,
	PhoneType int not NULL Foreign Key (PhoneType) References [dbo].[PhoneType] ([ID]),
	OtherDesc varchar(50)

)
