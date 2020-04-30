CREATE TABLE [dbo].[Patent]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserInfo_ID] INT NOT NULL Foreign KEY ([UserInfo_ID]) REFERENCES [dbo].[UserInfo]([ID]),
	[Number] INT NOT NULL,
	[Link] VARCHAR(300), 
    [DateOfPatent] DATE NULL
)
