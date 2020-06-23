CREATE TABLE [dbo].[TransportConditions]
(
	[Id]		INT					NOT NULL,
	[Title]		NVARCHAR(255)		NOT NULL,
	[IsDeleted]	BIT					DEFAULT 0 NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,

	CONSTRAINT	[PK_TransportConditions]	PRIMARY KEY CLUSTERED	([Id] ASC)
)
