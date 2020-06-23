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
	(12, N'GarageStorage'),
	(13, N'New'),
	(14, N'ForParts'),
	(15, N'NA')
) AS Source ([Id], [Title])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Title])
	VALUES (Source.[Id], Source.[Title]);