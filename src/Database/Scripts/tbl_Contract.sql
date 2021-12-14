CREATE TABLE [dbo].[tbl_Contract](
	[ContractId] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[UpdateDatetime] [datetime] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Owner] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC,
	[CreatedDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]