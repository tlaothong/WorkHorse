
/****** Object:  Table [dbo].[GameConfiguration]    Script Date: 09/23/2010 14:59:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GameConfiguration]') AND type in (N'U'))
DROP TABLE [dbo].[GameConfiguration]
GO
/****** Object:  Table [dbo].[GamePlay]    Script Date: 09/23/2010 14:59:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GamePlay]') AND type in (N'U'))
DROP TABLE [dbo].[GamePlay]
GO
/****** Object:  Table [dbo].[GameRound]    Script Date: 09/23/2010 14:59:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GameRound]') AND type in (N'U'))
DROP TABLE [dbo].[GameRound]
GO
/****** Object:  Table [dbo].[PlayerActionLog]    Script Date: 09/23/2010 14:59:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerActionLog]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerActionLog]
GO
/****** Object:  Table [dbo].[PlayerInformation]    Script Date: 09/23/2010 14:59:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerInformation]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerInformation]
GO
/****** Object:  Table [dbo].[PlayerInformation]    Script Date: 09/23/2010 14:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerInformation]') AND type in (N'U'))
BEGIN
--The following statement was imported into the database project as a schema object and named dbo.PlayerInformation.
--CREATE TABLE [dbo].[PlayerInformation](
--	[PlayerID] [int] NOT NULL,
--	[Balance] [float] NOT NULL
--)

END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerInformation', N'COLUMN',N'PlayerID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส player เจ้าของข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerInformation', @level2type=N'COLUMN',@level2name=N'PlayerID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerInformation', N'COLUMN',N'Balance'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ยอดเงินของ player' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerInformation', @level2type=N'COLUMN',@level2name=N'Balance'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerInformation', NULL,NULL))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลของ Player' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerInformation'

GO
/****** Object:  Table [dbo].[PlayerActionLog]    Script Date: 09/23/2010 14:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerActionLog]') AND type in (N'U'))
BEGIN
--The following statement was imported into the database project as a schema object and named dbo.PlayerActionLog.
--CREATE TABLE [dbo].[PlayerActionLog](
--	[RoundID] [int] NOT NULL,
--	[PlayerID] [int] NOT NULL,
--	[Amount] [float] NOT NULL,
--	[ActionType] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
--	[DateTime] [datetime] NOT NULL,
--	[TrackingID] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
--	[LotNo] [int] NOT NULL
--)

END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'RoundID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของโต๊ะเกมที่ player ดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'RoundID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'PlayerID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส player ที่ดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'PlayerID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'Amount'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินที่ ลงพนัน/หักค่าดูข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'Amount'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'ActionType'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภทของการดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'ActionType'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'DateTime'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'DateTime'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'TrackingID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสำหรับเช็คการดำเนินการ (Guid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'TrackingID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', N'COLUMN',N'LotNo'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของ Lot ที่จัดเก็บการดำเนินการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog', @level2type=N'COLUMN',@level2name=N'LotNo'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'PlayerActionLog', NULL,NULL))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลการดำเนินการของ player' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlayerActionLog'

GO
/****** Object:  Table [dbo].[GameRound]    Script Date: 09/23/2010 14:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GameRound]') AND type in (N'U'))
BEGIN
--The following statement was imported into the database project as a schema object and named dbo.GameRound.
--CREATE TABLE [dbo].[GameRound](
--	[RoundID] [int] NOT NULL,
--	[StartTime] [datetime] NOT NULL,
--	[EndTime] [datetime] NOT NULL,
--	[CriticalTime] [datetime] NOT NULL,
--	[BlackPot] [float] NOT NULL,
--	[WhitePot] [float] NOT NULL,
--	[HandCount] [int] NOT NULL,
--	[Winner] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL
--)

END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'RoundID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'RoundID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'StartTime'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาเริ่มของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'StartTime'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'EndTime'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาจบของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'EndTime'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'CriticalTime'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาคริติคอลของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'CriticalTime'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'BlackPot'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินในกองสีดำ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'BlackPot'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'WhitePot'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินในกองสีขาว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'WhitePot'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'HandCount'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนครั้งการลงเงินทั้งหมด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'HandCount'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', N'COLUMN',N'Winner'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สีที่ชนะของโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound', @level2type=N'COLUMN',@level2name=N'Winner'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameRound', NULL,NULL))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameRound'

GO
/****** Object:  Table [dbo].[GamePlay]    Script Date: 09/23/2010 14:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GamePlay]') AND type in (N'U'))
BEGIN
--The following statement was imported into the database project as a schema object and named dbo.GamePlay.
--CREATE TABLE [dbo].[GamePlay](
--	[RoundID] [int] NOT NULL,
--	[PlayerID] [int] NOT NULL,
--	[TotalAmountOfBlack] [float] NOT NULL,
--	[TotalAmountOfWhite] [float] NOT NULL,
--	[TrackingID] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
--	[OnGoingTrackingID] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
--	[Winner] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
--	[LasteUpdate] [datetime] NOT NULL
--)

END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'RoundID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'RoundID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'PlayerID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส player ที่เล่นโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'PlayerID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'TotalAmountOfBlack'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินทั้งหมดที่ลงเล่นสีดำ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'TotalAmountOfBlack'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'TotalAmountOfWhite'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินทั้งหมดที่ลงเล่นสีขาว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'TotalAmountOfWhite'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'TrackingID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสำหรับเช็คการร้องขอ Winner เดิม(Guid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'TrackingID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'OnGoingTrackingID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสสำหรับเช็คการร้องขอ Winner ล่าสุด(Guid)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'OnGoingTrackingID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'Winner'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล winner เมื่อจ่ายเงินเพื่อดูข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'Winner'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', N'COLUMN',N'LasteUpdate'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ข้อดูข้อมูล winner' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay', @level2type=N'COLUMN',@level2name=N'LasteUpdate'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GamePlay', NULL,NULL))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลโต๊ะเกมที่ player ลงเล่น' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GamePlay'

GO
/****** Object:  Table [dbo].[GameConfiguration]    Script Date: 09/23/2010 14:59:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GameConfiguration]') AND type in (N'U'))
BEGIN
--The following statement was imported into the database project as a schema object and named dbo.GameConfiguration.
--CREATE TABLE [dbo].[GameConfiguration](
--	[ConfigID] [int] IDENTITY(1,1) NOT NULL,
--	[Name] [nvarchar](50) COLLATE Thai_CI_AS NOT NULL,
--	[TableAmount] [int] NOT NULL,
--	[BufferRounCount] [int] NOT NULL,
--	[GameDuration] [int] NOT NULL,
--	[Interval] [int] NOT NULL
--)

END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', N'COLUMN',N'ConfigID'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของ configuration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'ConfigID'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', N'COLUMN',N'Name'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อของ Configuration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'Name'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', N'COLUMN',N'TableAmount'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนโต๊ะเกมที่จะสร้าง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'TableAmount'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', N'COLUMN',N'BufferRounCount'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวน Buffer สำรอง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'BufferRounCount'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', N'COLUMN',N'GameDuration'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาของโต๊ะเกม(นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'GameDuration'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', N'COLUMN',N'Interval'))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาหน่วงสำหรับสร้างโต๊ะเกมถัดไป(นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration', @level2type=N'COLUMN',@level2name=N'Interval'

GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'GameConfiguration', NULL,NULL))
--The following statement was imported into the database project as a schema object and named unnamed.
--EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ค่า configuration ที่จะสร้างโต๊ะเกม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GameConfiguration'


GO
