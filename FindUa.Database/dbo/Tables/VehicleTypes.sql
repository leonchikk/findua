CREATE TABLE [dbo].[VehicleTypes]
(
	[Id]		INT			  NOT NULL,
	[Name]		NVARCHAR(255) NOT NULL,
	[CreatedAt]	DATETIME	  NULL, 
	[UpdatedAt]	DATETIME	  NULL, 
	[DeletedAt]	DATETIME	  NULL,
	CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
)
