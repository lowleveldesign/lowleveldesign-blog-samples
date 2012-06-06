CREATE TABLE PaymentRouters_Trace(
	TraceId INT NOT NULL AUTO_INCREMENT,
	ApplicationName VARCHAR(256) NOT NULL,
	Source VARCHAR(64) NULL,
	Id INT NOT NULL,
	EventType VARCHAR(32) NOT NULL,
	UtcDateTime DATETIME NOT NULL,
	MachineName VARCHAR(32) NOT NULL,
	AppDomainFriendlyName VARCHAR(512) NOT NULL,
	ProcessId INT NOT NULL,
	ThreadName VARCHAR(512) NULL,
	Message VARCHAR(1500) NULL,
	ActivityId CHAR(36) NULL,
	RelatedActivityId CHAR(36) NULL,
	LogicalOperationStack VARCHAR(512) NULL,
	DATA TEXT NULL,
	PRIMARY KEY (TraceId)
  )
go


CREATE PROCEDURE diagnostics_Trace_AddEntry(
  `ApplicationName` VARCHAR(256),
  `Source` VARCHAR(64),
  `Id` INT,
  `EventType` VARCHAR(32),
  `UtcDateTime` DATETIME,
  `MachineName` VARCHAR(32),
  `AppDomainFriendlyName` VARCHAR(512),
  `ProcessId` INT,
  `ThreadName` VARCHAR(512),
  `Message` VARCHAR(1500),
  `ActivityId` CHAR(36),
  `RelatedActivityId` CHAR(36),
  `LogicalOperationStack` VARCHAR(512),
  `Data` TEXT
)
INSERT INTO PaymentRouters_Trace(
	`ApplicationName`, 
	`Source`, 
	`Id`, 
	`EventType`, 
	`UtcDateTime`, 
	`MachineName`, 
	`AppDomainFriendlyName`, 
	`ProcessId`, 
	`ThreadName`, 
	`Message`, 
	`ActivityId`, 
	`RelatedActivityId`, 
	`LogicalOperationStack`, 
	`Data`
) VALUES (
	`ApplicationName`, 
	`Source`, 
	`Id`, 
	`EventType`, 
	`UtcDateTime`, 
	`MachineName`, 
	`AppDomainFriendlyName`, 
	`ProcessId`, 
	`ThreadName`, 
	`Message`, 
	`ActivityId`, 
	`RelatedActivityId`, 
	`LogicalOperationStack`, 
	`Data`
)