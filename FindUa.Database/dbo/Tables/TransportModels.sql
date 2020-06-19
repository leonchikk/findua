CREATE TABLE [dbo].[TransportModels]
(
	[Id]		INT				NOT NULL IDENTITY(1, 1),
	[BrandId]	INT				NOT NULL,
	[Name]		NVARCHAR(255)	NOT NULL,
	[IsDeleted]	BIT				DEFAULT 0 NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT [PK_TransportModels] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TransportModels_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[TransportBrands] ([Id])
)
