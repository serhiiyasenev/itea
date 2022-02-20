CREATE TABLE [dbo].[Cars]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT(NEWID()),
	[RegistrationPlate] NVARCHAR(12) NOT NULL,
	[Brand] NVARCHAR(25) NOT NULL,
	[ReleaseDate] DATE NOT NULL
)
