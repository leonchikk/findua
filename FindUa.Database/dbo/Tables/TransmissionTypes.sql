CREATE TABLE [dbo].[TransmissionTypes]
(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR(255)	NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_TransmissionTypes] PRIMARY KEY CLUSTERED ([Id] ASC)	
)
