CREATE TABLE [dbo].[Cars]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT(NEWID()),
	[RegistrationPlate] NVARCHAR(10) NOT NULL,
	[Brand] NVARCHAR(25) NOT NULL,
	[ReleaseYear] DATE NOT NULL
)
