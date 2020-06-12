MERGE INTO [dbo].[TransportSourceProviderUrls] AS Target
USING
(
	VALUES
	(1, N'?make%5B%5D=0&year%5B%5D=0&year%5B%5D=0&price%5B%5D=0&price%5B%5D=0&engine%5B%5D=0&engine%5B%5D=0&gear=0&fuel=0&drive=0&condition=0&saled=0&notcust=-1&sort=1&task=newresults&from=sform', 1, 1),
	(2, N'transport/legkovye-avtomobili/',1, 2)
) AS Source ([Id], [DataUrl], [VehicleTypeId], [SourceProviderId])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [DataUrl], [VehicleTypeId], [SourceProviderId])
	VALUES (Source.[Id], Source.[DataUrl], Source.[VehicleTypeId], Source.[SourceProviderId]);