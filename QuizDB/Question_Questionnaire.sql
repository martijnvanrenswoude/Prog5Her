CREATE TABLE [dbo].[Question_Questionnaire]
(
	[Questionnaire_ID] INT NOT NULL, 
    [QuestionID] INT NOT NULL
	Primary Key (Questionnaire_ID, QuestionID)
	FOREIGN KEY (Questionnaire_ID) REFERENCES Questionnaire(id)
	FOREIGN KEY (QuestionID) REFERENCES Question(ID)
)
