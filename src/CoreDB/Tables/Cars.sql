CREATE TABLE [dbo].[Cars]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT(NEWID()),
	[RegistrationPlate] NVARCHAR(12) NOT NULL,
	[UserId] uniqueidentifier NOT NULL,
	CONSTRAINT [FK_Car_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] (Id) ON DELETE CASCADE
)
