GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderCustomerReview](
	[ProviderCustomerReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ProviderId] [int] NOT NULL,
	[CustomerReviewId] [int] NOT NULL,
 CONSTRAINT [PK_ProviderCustomerReviewId] PRIMARY KEY CLUSTERED 
(
	[ProviderCustomerReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProviderCustomerReview_Provider]') AND parent_object_id = OBJECT_ID(N'[dbo].[Provider]'))
ALTER TABLE [dbo].[ProviderCustomerReview]  WITH CHECK ADD  CONSTRAINT [FK_ProviderCustomerReview_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([ProviderId])
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProviderCustomerReview_CustomerReview]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerReview]'))
ALTER TABLE [dbo].[ProviderCustomerReview]  WITH CHECK ADD  CONSTRAINT [FK_ProviderCustomerReview_CustomerReview] FOREIGN KEY([CustomerReviewId])
REFERENCES [dbo].[CustomerReview] ([CustomerReviewID])
GO