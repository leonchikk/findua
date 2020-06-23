CREATE TABLE [dbo].[Cities]
(
	[Id]		INT					NOT NULL,
	[RegionId]	INT					NOT NULL,
	[Title]		NVARCHAR(255)		NOT NULL,
	[IsRegionalCenter]	BIT			DEFAULT 0 NOT NULL,
	[LocalizationKeyId]	INT			NOT NULL,
	[IsDeleted]	BIT					DEFAULT 0 NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_Cities]			PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT	[FK_Cities_RegionId] FOREIGN KEY ([RegionId])	REFERENCES [dbo].[Regions] ([Id]),
	CONSTRAINT	[FK_Cities_LocalizationKeyId] FOREIGN KEY ([LocalizationKeyId])	REFERENCES [dbo].[LocalizationKeys] ([Id])
)
