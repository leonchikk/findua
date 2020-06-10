CREATE TABLE [dbo].[Cities]
(
	[Id]		INT					NOT NULL,
	[RegionId]	INT					NOT NULL,
	[Name]		NVARCHAR(255)		NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_Cities]			PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT	[FK_Cities_RegionId] FOREIGN KEY ([RegionId])	REFERENCES [dbo].[Regions] ([Id])
)
