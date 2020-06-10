CREATE TABLE [dbo].[BodyTypes]
(
	[Id]			INT					NOT NULL,
	[Name]			NVARCHAR(255)		NOT NULL,
	[VehicleTypeId]	INT					NOT NULL,
	[CreatedAt]		DATETIME			NULL, 
	[UpdatedAt]		DATETIME			NULL, 
	[DeletedAt]		DATETIME			NULL,
	CONSTRAINT		[PK_BodyTypes]		PRIMARY KEY CLUSTERED	([Id] ASC),
	CONSTRAINT		[FK_BodyTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [dbo].[VehicleTypes] ([Id])
)
