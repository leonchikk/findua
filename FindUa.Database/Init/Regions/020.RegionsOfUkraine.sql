MERGE INTO [dbo].Regions AS Target
USING
(
	VALUES
	(3525, N'Krym', 212),
	(3526, N'Odes''ka Oblast''', 212),
	(3527, N'Kharkivs''ka Oblast''', 212),
	(3528, N'Poltavs''ka Oblast''', 212),
	(3529, N'Kyyivs''ka Oblast''', 212),
	(3530, N'Zakarpats''ka Oblast''', 212),
	(3531, N'Sums''ka Oblast''', 212),
	(3532, N'Donets''ka Oblast''', 212),
	(3533, N'Khersons''ka Oblast''', 212),
	(3534, N'L''vivs''ka Oblast''', 212),
	(3535, N'Cherkas''ka Oblast''', 212),
	(3536, N'Vinnyts''ka Oblast''', 212),
	(3537, N'Rivnens''ka Oblast''', 212),
	(3538, N'Khmel''nyts''ka Oblast''', 212),
	(3539, N'Chernihivs''ka Oblast''', 212),
	(3540, N'Dnipropetrovs''ka Oblast''', 212),
	(3541, N'Mykolayivs''ka Oblast''', 212),
	(3542, N'Ternopil''s''ka Oblast''', 212),
	(3543, N'Zhytomyrs''ka Oblast''', 212),
	(3544, N'Chernivets''ka Oblast''', 212),
	(3545, N'Luhans''ka Oblast''', 212),
	(3546, N'Sevastopol''', 212),
	(3547, N'Kirovohrads''ka Oblast''', 212),
	(3548, N'Ivano-Frankivs''ka Oblast''', 212),
	(3549, N'Zaporiz''ka Oblast''', 212),
	(3550, N'Volyns''ka Oblast''', 212),
	(3551, N'', 212)
) AS Source ([Id], [Name], [CountryId])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name], [CountryId])
	VALUES (Source.[Id], Source.[Name], Source.[CountryId]);