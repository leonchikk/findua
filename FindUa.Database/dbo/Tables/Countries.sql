CREATE TABLE [dbo].[Countries]
(
	[Id]		INT					NOT NULL,
	[Name]		NVARCHAR(255)		NOT NULL,
	[Code]		NVARCHAR(2)			NOT NULL,
	[Language]	NVARCHAR(3)			NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_Countries]		PRIMARY KEY CLUSTERED ([Id] ASC)
)
