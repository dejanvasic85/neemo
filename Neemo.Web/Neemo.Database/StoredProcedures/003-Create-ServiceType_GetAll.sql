SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ServiceType_GetAll]           
AS

/*
	e.g.
	exec ServiceType_GetAll
*/

SELECT [ServiceTypeID]
      ,[ServiceType]
      ,[Image]
      ,[Active]
      ,[CreatedDateTime]
      ,[CreatedByUser]
      ,[LastModifiedDateTime]
      ,[LastModifiedByUser]
      ,[DeletedDateTime]
      ,[DeletedByUser]
      ,[EffectiveDateFrom]
      ,[EffectiveDateTo]
  FROM [ServiceType]
GO

