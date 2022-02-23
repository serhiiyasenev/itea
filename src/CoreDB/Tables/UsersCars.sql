CREATE TABLE [dbo].[UsersCars]
(
	[UserId] uniqueidentifier NOT NULL,
	[CarId] uniqueidentifier NOT NULL,
	CONSTRAINT FK_Users_Id_UserId FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Cars_Id_CarId FOREIGN KEY(CarId) REFERENCES Cars(Id) ON DELETE CASCADE,
    CONSTRAINT PK_UserCar PRIMARY KEY(UserId,CarId)
)