SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (
	SELECT * 
	FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[dbo].[Provider_UpdateRating]') 
		AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[Provider_UpdateRating]
       @ProviderId	INT,
	   @Rating		DECIMAL (18,2),
	   @User		VARCHAR (100)

AS
BEGIN
	UPDATE Provider
	SET		Rating = @Rating,
			LastModifiedByUser = @User
	WHERE	ProviderID = @ProviderId
END
' 
END
