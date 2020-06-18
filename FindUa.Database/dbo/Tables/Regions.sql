CREATE TABLE [dbo].[Regions]
(
	[Id]		INT					NOT NULL,
	[Title]		NVARCHAR(255)		NOT NULL,
	[CountryId]	INT					NOT NULL,
	[LocalizationKeyId]	INT			NOT NULL,
	[ShortTitle] NVARCHAR(255)		NOT NULL,
	[IsDeleted]	BIT					DEFAULT 0 NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_Regions]		PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT	[FK_Regions_CountryId]	FOREIGN KEY ([CountryId])	REFERENCES [dbo].[Countries] ([Id]),
	CONSTRAINT	[FK_Regions_LocalizationKeyId] FOREIGN KEY ([LocalizationKeyId])	REFERENCES [dbo].[LocalizationKeys] ([Id])
)
