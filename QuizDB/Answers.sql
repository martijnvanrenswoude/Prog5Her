CREATE TABLE [dbo].[Answers]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [QuestionID] INT NOT NULL, 
    [IsCorrect] BIT NULL
	Foreign key (QuestionID) References Question(id), 
    [Answer] NVARCHAR(MAX) NULL
)
