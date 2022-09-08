CREATE TABLE [dbo].[PlayersInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(40) NULL, 
    [LastName] NVARCHAR(40) NULL, 
    [Email] CHAR(60) NULL, 
    [Username] NVARCHAR(30) NULL, 
    [Password] NVARCHAR(20),
    [Team_ID] INT NULL
);
