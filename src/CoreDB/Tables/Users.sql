CREATE TABLE [dbo].[Users]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT(NEWID()),
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	[Birthday] DATE NOT NULL
)
