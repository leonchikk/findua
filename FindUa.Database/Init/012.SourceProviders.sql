MERGE INTO [dbo].[SourceProviders] AS Target
USING
(
	VALUES
	(1, N'RST')
) AS Source ([Id], [Name])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name])
	VALUES (Source.[Id], Source.[Name]);