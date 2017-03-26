USE [Products]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 3/26/2017 2:41:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemNumber] [int] NOT NULL,
	[ItemDescription] [nvarchar](1000) NULL,
	[ItemPrice] [float] NOT NULL,
	[ItemQuantity] [int] NOT NULL,
	[ItemValue] [float] NOT NULL,
	[ItemCost] [float] NOT NULL,
	[ItemCreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ItemCreatedDate]  DEFAULT (getdate()) FOR [ItemCreatedDate]
GO


