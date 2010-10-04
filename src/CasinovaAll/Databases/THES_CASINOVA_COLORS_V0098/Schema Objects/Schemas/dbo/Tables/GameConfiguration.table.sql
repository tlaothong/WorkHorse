CREATE TABLE [dbo].[GameConfiguration](
	[GameConfigurationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDisabled] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[TableCount] [int] NOT NULL,
	[BufferRoundCount] [int] NOT NULL,
	[GameDuration] [int] NOT NULL,
	[Interval] [int] NOT NULL
)


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ค่า configuration ที่จะสร้างโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของ configuration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'GameConfigurationID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อของ Configuration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ปิดการใช้งาน Configuration นี้ชั่วคราว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'IsDisabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วัน-เวลา ที่บันทึกการแก้ไขครั้งสุดท้าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'LastUpdate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนโต๊ะเกมที่จะสร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'TableCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวน Buffer สำรอง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'BufferRoundCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาของโต๊ะเกม(นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'GameDuration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาหน่วงสำหรับสร้างโต๊ะเกมถัดไป(นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'Interval'

