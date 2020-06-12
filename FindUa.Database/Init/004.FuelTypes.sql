﻿MERGE INTO [dbo].[FuelTypes] AS Target
USING
(
	VALUES
	(1, N'Mechanical'),
	(2, N'Automatic'),
	(3, N'VariableSpeedDrive'),
	(4, N'Adaptive'),
	(5, N'Tiptronic'),
	(6, N'Other')
) AS Source ([Id], [Name])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name])
	VALUES (Source.[Id], Source.[Name]);