
SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON         -- We don't want (NULL = NULL) == TRUE
GO
SET ANSI_PADDING ON
GO
SET ANSI_NULL_DFLT_ON ON
GO

DECLARE @dbname nvarchar(128)
DECLARE @dboptions nvarchar(1024)

SET @dboptions = N'/**/'
SET @dbname = N'ordersdb'

IF (NOT EXISTS (SELECT name
                FROM master.dbo.sysdatabases
                WHERE name = @dbname))
BEGIN
  PRINT 'Creating the ' + @dbname + ' database...'
  DECLARE @cmd nvarchar(500)
  SET @cmd = 'CREATE DATABASE [' + @dbname + '] ' + @dboptions
  EXEC(@cmd)
END
GO

use ordersdb

create table Orders(
    Id int identity(1,1) primary key,
    Username varchar(200) not null,
    Product varchar(200) not null,
    Cash money not null,
    CreatedOn datetime not null,
    Status char(4) not null,
    StatusMessage varchar(2000) null,
    ActivityId uniqueidentifier null
)
go
