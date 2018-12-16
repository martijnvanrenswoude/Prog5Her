CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Question] NVARCHAR(MAX) NOT NULL, 
    [CategoryID] INT NOT NULL, 
	[AmountOfAnswers] INT NOT NULL, 
    Foreign Key ([CategoryID]) References Categories([ID])
)
