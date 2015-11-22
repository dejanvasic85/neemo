GO

/****** Object:  Table [dbo].[ProviderMake]    Script Date: 31/08/2015 11:15:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProviderMake](
	[ProviderMakeID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderID] [int] NULL,
	[MakeID] [int] NULL,
	[Image] [nvarchar](100) NULL,
	[Active] [bit] NULL,
	[CreatedDateTime] [datetime] NULL,
	[CreatedByUser] [nvarchar](50) NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[LastModifiedByUser] [nvarchar](50) NULL,
	[DeletedDateTime] [datetime] NULL,
	[DeletedByUser] [nvarchar](50) NULL,
	[EffectiveDateFrom] [datetime] NULL,
	[EffectiveDateTo] [datetime] NULL,
 CONSTRAINT [PK_ProviderMake] PRIMARY KEY CLUSTERED 
(
	[ProviderMakeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProviderMake] ADD  CONSTRAINT [DF_ProviderMake_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [dbo].[ProviderMake] ADD  CONSTRAINT [DF_ProviderMake_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[ProviderMake] ADD  CONSTRAINT [DF_ProviderMake_LastModifiedDateTime]  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO

ALTER TABLE [dbo].[ProviderMake]  WITH CHECK ADD  CONSTRAINT [FK_ProviderMake_Provider] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[Provider] ([ProviderID])
GO

ALTER TABLE [dbo].[ProviderMake] CHECK CONSTRAINT [FK_ProviderMake_Provider]
GO

ALTER TABLE [dbo].[ProviderMake]  WITH CHECK ADD  CONSTRAINT [FK_ProviderMake_Make] FOREIGN KEY([MakeID])
REFERENCES [dbo].[Make] ([MakeID])
GO

ALTER TABLE [dbo].[ProviderMake] CHECK CONSTRAINT [FK_ProviderMake_Make]
GO


