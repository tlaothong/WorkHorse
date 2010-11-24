CREATE TABLE [dbo].[PlayerInformation](
	[PlayerID] [int] NOT NULL,
	[Balance] [float] NOT NULL
)


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลของ Player' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerInformation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส player เจ้าของข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerInformation', @level2type=N'COLUMN',@level2name=N'PlayerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ยอดเงินของ player' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerInformation', @level2type=N'COLUMN',@level2name=N'Balance'

