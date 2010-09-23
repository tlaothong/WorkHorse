CREATE TABLE [dbo].[GamePlay](
	[RoundID] [int] NOT NULL,
	[PlayerID] [int] NOT NULL,
	[TotalAmountOfBlack] [float] NOT NULL,
	[TotalAmountOfWhite] [float] NOT NULL,
	[TrackingID] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
	[OnGoingTrackingID] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
	[Winner] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
	[LasteUpdate] [datetime] NOT NULL
)


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลโต๊ะเกมที่ player ลงเล่น' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'RoundID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส player ที่เล่นโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'PlayerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินทั้งหมดที่ลงเล่นสีดำ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'TotalAmountOfBlack'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินทั้งหมดที่ลงเล่นสีขาว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'TotalAmountOfWhite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสำหรับเช็คการร้องขอ Winner เดิม(Guid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'TrackingID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสำหรับเช็คการร้องขอ Winner ล่าสุด(Guid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'OnGoingTrackingID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล winner เมื่อจ่ายเงินเพื่อดูข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'Winner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ข้อดูข้อมูล winner' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'LasteUpdate'

