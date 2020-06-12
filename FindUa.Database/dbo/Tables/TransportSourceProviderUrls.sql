CREATE TABLE [dbo].[TransportSourceProviderUrls]
(
	[Id]				INT				NOT NULL,
	[DataUrl]			NVARCHAR(2048)	NOT NULL,
	[VehicleTypeId]		INT				NOT NULL,
	[SourceProviderId]	INT				NOT NULL,
	CONSTRAINT [PK_TransportSourceProviderUrls] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TransportSourceProviderUrls_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [dbo].[VehicleTypes] ([Id]),
	CONSTRAINT [FK_TransportSourceProviderUrls_SourceProviderId] FOREIGN KEY ([SourceProviderId]) REFERENCES [dbo].[TransportSourceProviders] ([Id])
)
