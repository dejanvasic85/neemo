SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Provider_GetById]
       @ProviderId INT
 
	   /*
	   exec dbo.Provider_GetById 
			@ProviderId = 1
	   */
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT  p.*
	FROM	Provider p
	WHERE	p.active = 1
		AND	p.ProviderID = @ProviderId

END
