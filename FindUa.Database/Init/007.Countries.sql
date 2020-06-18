MERGE INTO [dbo].Countries AS Target
USING
(
	VALUES
	(1, N'Ukraine', 1)
) AS Source ([Id], [Title], [LocalizationKeyId])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Title], [LocalizationKeyId])
	VALUES (Source.[Id], Source.[Title], Source.[LocalizationKeyId]);