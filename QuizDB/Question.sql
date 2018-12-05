CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Question] NVARCHAR(MAX) NOT NULL, 
    [Category] NVARCHAR(MAX) NULL, 
	Foreign Key (Category) References Category(Category)
)
