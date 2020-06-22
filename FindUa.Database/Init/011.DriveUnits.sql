MERGE INTO [dbo].[DriveUnits] AS Target
USING
(
	VALUES
	(1, N'FrontWheel'),
	(2, N'RearWheel'),
	(3, N'AllWheel'),
	(4, N'NA')
) AS Source ([Id], [Title])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Title])
	VALUES (Source.[Id], Source.[Title]);