IF OBJECT_ID(N'[dbo].[BusinessAudit]') IS NOT NULL
    DROP TABLE [dbo].[BusinessAudit]
GO
IF OBJECT_ID(N'[dbo].[DiagnosticAudit]') IS NOT NULL
    DROP TABLE [dbo].[DiagnosticAudit]
GO
IF OBJECT_ID(N'[dbo].[InsertBusinessAudit]') IS NOT NULL
    DROP PROCEDURE [dbo].[InsertBusinessAudit]
GO
IF OBJECT_ID(N'[dbo].[InsertDiagnosticAudit]') IS NOT NULL
    DROP PROCEDURE [dbo].[InsertDiagnosticAudit]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BusinessAudit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[When] [datetime] NOT NULL,
	[User] [varchar](50) NOT NULL,
	[EventId] [int] NOT NULL,
	[EventDesc] [nvarchar](256) NOT NULL,
	[Level] [varchar](10) NOT NULL,
	[Success] [bit] NOT NULL,
	[Machine] [varchar](16) NOT NULL,
	[Class] [varchar](100) NOT NULL,
	[Method] [varchar](50) NOT NULL,
	[Details] [xml] NULL,
	[CorrelationToken] [uniqueidentifier] NOT NULL,
	[TestIntValue] [int] NULL,
	[TestStringValue] [varchar](50) NULL,
 CONSTRAINT [PK_BusinessAudit] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE [dbo].[DiagnosticAudit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[When] [datetime] NOT NULL,
	[User] [varchar](50) NOT NULL,
	[EventType] [varchar](10) NOT NULL,
	[Level] [varchar](10) NOT NULL,
	[Machine] [varchar](16) NOT NULL,
	[Class] [varchar](100) NOT NULL,
	[Method] [varchar](50) NOT NULL,
	[ExceptionType] [varchar](100) NULL,
	[Message] [varchar](2048) NOT NULL,
	[StackTrace] [varchar](max) NOT NULL,
	[CorrelationToken] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DiagnosticAudit] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO


CREATE PROCEDURE [dbo].[InsertBusinessAudit](
	@When datetime
	,@User varchar(50)
	,@EventId int
	,@EventDesc nvarchar(256)
	,@Level varchar(10)
	,@Success bit
	,@Machine varchar(16)
	,@Class varchar(100)
	,@Method varchar(50)
	,@Details xml
	,@CorrelationToken uniqueidentifier
	,@TestIntValue int
	,@TestStringValue varchar(50)
)
AS
	INSERT INTO [dbo].[BusinessAudit](
		[When]
        ,[User]
        ,[EventId]
        ,[EventDesc]
		,[Level]
        ,[Success]
        ,[Machine]
        ,[Class]
        ,[Method]
        ,[Details]
		,[CorrelationToken]
        ,[TestIntValue]
        ,[TestStringValue])
     VALUES
        (@When
		,@User
		,@EventId
		,@EventDesc
		,@Level
		,@Success
		,@Machine
		,@Class
		,@Method
		,@Details
		,@CorrelationToken
		,@TestIntValue
		,@TestStringValue)
GO

CREATE PROCEDURE [dbo].[InsertDiagnosticAudit](
	@When datetime
    ,@User varchar(50)
    ,@EventType varchar(10)
	,@Level varchar(10)
    ,@Machine varchar(16)
    ,@Class varchar(100)
    ,@Method varchar(50)
    ,@ExceptionType varchar(100)
    ,@Message varchar(2048)
    ,@StackTrace varchar(max)
	,@CorrelationToken uniqueidentifier)
AS
	INSERT INTO [dbo].[DiagnosticAudit](
		[When]
        ,[User]
        ,[EventType]
		,[Level]
        ,[Machine]
        ,[Class]
        ,[Method]
        ,[ExceptionType]
        ,[Message]
        ,[StackTrace]
		,[CorrelationToken])
     VALUES
        (@When
        ,@User
        ,@EventType
		,@Level
        ,@Machine
        ,@Class
        ,@Method
        ,@ExceptionType
        ,@Message
        ,@StackTrace
		,@CorrelationToken)
GO

