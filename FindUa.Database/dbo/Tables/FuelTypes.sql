﻿CREATE TABLE [dbo].[FuelTypes]
(
	[Id]		INT				NOT NULL,
	[Name]		NVARCHAR(255)	NOT NULL,
	[IsDeleted]	BIT				DEFAULT 0 NOT NULL,
	[CreatedAt]	DATETIME		NULL, 
	[UpdatedAt]	DATETIME		NULL, 
	[DeletedAt]	DATETIME		NULL,
	CONSTRAINT [PK_FuelTypes] PRIMARY KEY CLUSTERED ([Id])
)
