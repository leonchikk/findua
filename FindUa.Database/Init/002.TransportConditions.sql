MERGE INTO [dbo].[TransportConditions] AS Target
USING
(
	VALUES
	(1, N'Good'),
	(2, N'AfterAccident'),
	(3, N'Unbeaten'),
	(4, N'NotOnTheMove'),
	(5, N'NotPainted'),
	(6, N'OnCredit'),
	(7, N'RequiresRepair'),
	(8, N'NotCustomsCleared'),
	(9, N'CustomsCleared'),
	(10, N'FirstRegistration'),
	(11, N'FirstOwner'),
	(12, N'GarageStorage')
) AS Source ([Id], [Name])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name])
	VALUES (Source.[Id], Source.[Name], Source.[Code], Source.[Language]);