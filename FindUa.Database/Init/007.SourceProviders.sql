MERGE INTO [dbo].[TransportSourceProviders] AS Target
USING
(
	VALUES
	(1, N'RST', 'https://rst.ua/'),
	(2, N'OLX', 'https://www.olx.ua/')
) AS Source ([Id], [Name], [BaseUrl])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name], [BaseUrl])
	VALUES (Source.[Id], Source.[Name], Source.[BaseUrl]);