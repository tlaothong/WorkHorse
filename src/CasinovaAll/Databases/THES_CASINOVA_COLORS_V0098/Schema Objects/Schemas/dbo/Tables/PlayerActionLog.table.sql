CREATE TABLE [dbo].[PlayerActionLog](
	[RoundID] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[ActionType] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[TrackingID] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
	[LotNo] [int] NOT NULL
)


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลการดำเนินการของ player' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของโต๊ะเกมที่ player ดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'RoundID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส player ที่ดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'PlayerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินที่ ลงพนัน/หักค่าดูข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทของการดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'ActionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'DateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสำหรับเช็คการดำเนินการ (Guid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'TrackingID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของ Lot ที่จัดเก็บการดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'LotNo'

