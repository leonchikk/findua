﻿CREATE TABLE [dbo].[Regions]
(
	[Id]		INT					NOT NULL,
	[Name]		NVARCHAR(255)		NOT NULL,
	[CountryId]	INT					NOT NULL,
	[CreatedAt]	DATETIME			NULL, 
	[UpdatedAt]	DATETIME			NULL, 
	[DeletedAt]	DATETIME			NULL,
	CONSTRAINT	[PK_Regions]		PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT	[FK_Regions_CountryId]	FOREIGN KEY ([CountryId])	REFERENCES [dbo].[Countries] ([Id])
)
