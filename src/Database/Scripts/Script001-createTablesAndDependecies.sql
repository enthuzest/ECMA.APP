SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Contract](
	[ContractId] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[UpdateDatetime] [datetime] NULL,
	[Price] [decimal](18, 2) NULL,
	[Owner] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


