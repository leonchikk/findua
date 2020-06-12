CREATE TABLE [dbo].[TransportSourceProviders]
(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR(255)	NOT NULL,
	[BaseUrl]	NVARCHAR(2048)	NOT NULL,
	[CreatedAt]	DATETIME		NULL, 
	[UpdatedAt]	DATETIME		NULL, 
	[DeletedAt]	DATETIME		NULL,
	CONSTRAINT [PK_TransportSourceProviders] PRIMARY KEY CLUSTERED ([Id] ASC)
)
