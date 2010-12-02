CREATE TABLE [dbo].[GameRound](
	[RoundID] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[CriticalTime] [datetime] NOT NULL,
	[BlackPot] [float] NOT NULL,
	[WhitePot] [float] NOT NULL,
	[HandCount] [int] NOT NULL,
	[Winner] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL
)


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'RoundID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาเริ่มของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาจบของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาคริติคอลของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'CriticalTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินในกองสีดำ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'BlackPot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินในกองสีขาว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'WhitePot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนครั้งการลงเงินทั้งหมด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'HandCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สีที่ชนะของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'Winner'

