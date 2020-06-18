MERGE INTO [dbo].Regions AS Target
USING
(
	VALUES
	 (1, N'Vinnitskaya oblast''', N'Vinnitsa', 2, 1),
	 (2, N'Sevastopol'' gorod', N'Sevastopol''', 3, 1),
	 (3, N'Krym (ARK)', N'Krym (ARK)', 4, 1),
	 (4, N'Volynskaya oblast''', N'Volyn''', 5, 1),
	 (5, N'Dnepropetrovskaya oblast''', N'Dnepropetrovsk', 6, 1),
	 (6, N'Donetskaya oblast''', N'Donetsk', 7, 1),
	 (7, N'Zhitomirskaya oblast''', N'Zhitomir', 8, 1),
	 (8, N'Zakarpatskaya oblast''', N'Zakarpat''e', 9, 1),
	 (9, N'Zaporozhskaya oblast''', N'Zaporozh''e', 10, 1),
	 (10, N'Ivano-Frankovskaya oblast''', N'Ivano-Frankovsk', 11, 1),
	 (11, N'Kievskaya oblast''', N'Kiev', 12, 1),
	 (12, N'Kirovogradskaya oblast''', N'Kirovograd', 13, 1),
	 (13, N'Luganskaya oblast''', N'Lugansk', 14, 1),
	 (14, N'L''vovskaya oblast''', N'L''vov', 15, 1),
	 (15, N'Nikolaevskaya oblast''', N'Nikolaev', 16, 1),
	 (16, N'Odesskaya oblast''', N'Odessa', 17, 1),
	 (17, N'Poltavskaya oblast''', N'Poltava', 18, 1),
	 (18, N'Rovnenskaya oblast''', N'Rovno', 19, 1),
	 (19, N'Sumskaya oblast''', N'Sumy', 20, 1),
	 (20, N'Ternopol''skaya oblast''', N'Ternopol''', 21, 1),
	 (21, N'Khar''kovskaya oblast''', N'Khar''kov', 22, 1),
	 (22, N'Khersonskaya oblast''', N'Kherson', 23, 1),
	 (23, N'Khmel''nitskaya oblast''', N'Khmel''nitskiy', 24, 1),
	 (24, N'Cherkasskaya oblast''', N'Cherkassy', 25, 1),
	 (25, N'Chernigovskaya oblast''', N'Chernigov', 26, 1),
	 (26, N'Chernovitskaya oblast''', N'Chernovtsy', 27, 1)
) AS Source ([Id], [Title], [ShortTitle], [LocalizationKeyId], [CountryId])
ON (Target.[Id] = Source.[Id])
WHEN NOT MATCHED THEN
	INSERT ([Id], [Title], [ShortTitle], [LocalizationKeyId], [CountryId])
	VALUES (Source.[Id], Source.[Title], Source.[ShortTitle], Source.[LocalizationKeyId], Source.[CountryId]);