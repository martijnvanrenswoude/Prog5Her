CREATE TABLE [dbo].[Questionnaire]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Name] NVARCHAR(MAX) NULL, 
    [Category] NVARCHAR(MAX) NULL
)
