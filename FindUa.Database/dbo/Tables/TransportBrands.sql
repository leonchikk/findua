CREATE TABLE [dbo].[TransportBrands]
(
	[Id]			INT				NOT NULL,
	[Name]			NVARCHAR(255)	NOT NULL,
	[VehicleTypeId]	INT				NOT NULL,
	[IsDeleted]		BIT				DEFAULT 0 NOT NULL,
	[CreatedAt]		DATETIME		NULL, 
	[UpdatedAt]		DATETIME		NULL, 
	[DeletedAt]		DATETIME		NULL,
	CONSTRAINT [PK_TransportBrands] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TransportBrands_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [dbo].[VehicleTypes] ([Id])
)
