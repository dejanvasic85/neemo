SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerReview](
	[CustomerReviewId] [int] IDENTITY(1,1) NOT NULL,
	[Score] decimal(18,2) NULL,
	[Comment] [nvarchar](MAX) NULL,
	[Active] [bit] NULL,
	[CreatedDateTime] [datetime] NULL,
	[CreatedByUser] [nvarchar](50) NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[LastModifiedByUser] [nvarchar](50) NULL,
	[DeletedDateTime] [datetime] NULL,
	[DeletedByUser] [nvarchar](50) NULL,
	[EffectiveDateFrom] [datetime] NULL,
	[EffectiveDateTo] [datetime] NULL,
 CONSTRAINT [PK_CustomerReviewId] PRIMARY KEY CLUSTERED 
(
	[CustomerReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO