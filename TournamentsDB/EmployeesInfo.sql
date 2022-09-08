CREATE TABLE [dbo].[EmployeesInfo] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (40) NULL,
    [LastName]  NVARCHAR (40) NULL,
    [Username] NVARCHAR(40) NOT NULL,
    [Password]  NCHAR (20)    NULL,
);
