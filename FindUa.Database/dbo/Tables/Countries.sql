CREATE TABLE [dbo].[Countries]
(
	[Id]		INT					NOT NULL,
	[Title]		NVARCHAR(255)		NOT NULL,
	[LocalizationKeyId]	INT			NOT NULL,
	[IsDeleted]	BIT					DEFAULT 0 NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_Countries]		PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT	[FK_Countries_LocalizationKeyId] FOREIGN KEY ([LocalizationKeyId])	REFERENCES [dbo].[LocalizationKeys] ([Id])
)
